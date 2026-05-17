// This file is part of the CataCraft project, which is published under the MIT license.

using System.Buffers;
using System.IO.Pipelines;
using System.Net.Sockets;
using System.Threading.Channels;
using CataCraft.Core.Enums;
using CataCraft.Core.Server.Protocol.Packets;

namespace CataCraft.Core.Server.Networking;

public abstract class WowSession
{
    private readonly struct ServerPacketData
    {
        public ServerPacketData(byte[] buffer, int payloadLength, int opcode)
        {
            Buffer = buffer;
            PayloadLength = payloadLength;
            Opcode = opcode;
        }

        public byte[] Buffer { get; }
        public int PayloadLength { get; }
        public int Opcode { get; }
    }

    // Internal fields
    private static readonly ArrayPool<byte> s_bufferPool = ArrayPool<byte>.Shared;
    private readonly TcpClient _client;
    private readonly CancellationTokenSource _cancellationTokenSource = new();
    private readonly Channel<ServerPacketData> _packetQueue = Channel.CreateUnbounded<ServerPacketData>();
    private bool _closeSessionAfterSendingPackets;

    // Protected properties
    protected abstract int ClientPacketHeaderSize { get; }
    protected abstract int ServerPacketHeaderSize { get; }

    public string AccountName { get; set; } = string.Empty;
    public long GameAccountId { get; set; }
    public ClientLocale Locale { get; set; } = ClientLocale.enUS;
    public bool IsOpen => !_cancellationTokenSource.IsCancellationRequested;

    protected WowSession(TcpClient client)
    {
        _client = client;
        _ = ReadFromStreamAsync(_cancellationTokenSource.Token);
        _ = WriteToStreamAsync(_cancellationTokenSource.Token);
    }

    private async Task ReadFromStreamAsync(CancellationToken cancellationToken = default)
    {
        StreamPipeReaderOptions options = new();

        PipeReader reader = PipeReader.Create(_client.GetStream(), options);

        try
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                ReadResult result = await reader.ReadAsync(cancellationToken);
                if (result.IsCanceled)
                {
                    Close();
                    return;
                }

                ReadOnlySequence<byte> buffer = result.Buffer;
                SequenceReader<byte> sequenceReader = new(buffer);
                SequencePosition currentPosition = buffer.Start;

                while (sequenceReader.TryReadExact(ClientPacketHeaderSize, out ReadOnlySequence<byte> headerBuffer))
                {
                    // Try to parse the header first. Attempt to extract the opcode and payload length from it
                    if (!ReadHeader(ref headerBuffer, out int opcode, out int payloadLength))
                    {
                        Close();
                        return;
                    }

                    // If the payload length is marked as -1, we expect the entire remaining buffer to be the payload.
                    // This behavior applies for Grunt packets
                    if (payloadLength == -1)
                        payloadLength = (int)sequenceReader.Remaining;

                    // Try to extract the payload buffer if enough data is available
                    if (payloadLength >= 0)
                    {
                        if (!sequenceReader.TryReadExact(payloadLength, out ReadOnlySequence<byte> payloadBuffer))
                            break;

                        // Parse the payload and handle the packet
                        ReadPayload(ref payloadBuffer, opcode);
                    }

                    // Packet has been successfully parsed. Mark the buffer chunk as processed
                    currentPosition = sequenceReader.Position;
                }

                // Advance the reader and mark the entire buffer as examined so that we can receive new data
                reader.AdvanceTo(currentPosition, buffer.End);

                if (result.IsCompleted)
                {
                    Close();
                    return;
                }
            }
        }
        catch (OperationCanceledException)
        {
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            Close();
        }
        finally
        {
            await reader.CompleteAsync();
        }
    }

    private async Task WriteToStreamAsync(CancellationToken cancellationToken = default)
    {
        PipeWriter writer = PipeWriter.Create(_client.GetStream());

        try
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await _packetQueue.Reader.WaitToReadAsync(cancellationToken);

                while (_packetQueue.Reader.TryRead(out ServerPacketData packetData))
                {
                    try
                    {
                        WriteHeader(writer, packetData.Opcode, packetData.PayloadLength);
                        if (packetData.Buffer.Length > 0)
                            writer.Write(packetData.Buffer.AsSpan(0, packetData.PayloadLength));
                    }
                    finally
                    {
                        s_bufferPool.Return(packetData.Buffer);
                    }
                }

                FlushResult result = await writer.FlushAsync(cancellationToken);
                if (result.IsCompleted || _closeSessionAfterSendingPackets)
                {
                    Close();
                    return;
                }
            }
        }
        catch (OperationCanceledException)
        {
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            Close();
        }
        finally
        {
            await writer.CompleteAsync();
        }
    }

    protected abstract bool ReadHeader(ref ReadOnlySequence<byte> headerBuffer, out int opcode, out int payloadLength);

    protected abstract void ReadPayload(ref ReadOnlySequence<byte> payloadBuffer, int opcode);

    protected abstract void WriteHeader(IBufferWriter<byte> writer, int opcode, int payloadSize);

    public void Close()
    {
        if (_cancellationTokenSource.IsCancellationRequested)
            return;

        _cancellationTokenSource.Cancel();
        _cancellationTokenSource.Dispose();
        _client.Dispose();

        Console.WriteLine("Closed session");
    }

    public void EnqueuePacket<TPacket>(ref TPacket packet, bool closeAfterSend = false) where TPacket : struct, IServerPacket, allows ref struct
    {
        packet.Serialize(out byte[] buffer, out int payloadLength);

        _packetQueue.Writer.TryWrite(new ServerPacketData(buffer, payloadLength, packet.Opcode));

        // Mark the session to be closed after sending the next batch of packets
        if (closeAfterSend)
            _closeSessionAfterSendingPackets = closeAfterSend;
    }
}
