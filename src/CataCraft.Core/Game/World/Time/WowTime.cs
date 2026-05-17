// This file is part of the CataCraft project, which is published under the MIT license.

namespace CataCraft.Core.Game.World.Time;

public struct WowTime
{
    public int Year { get; set; } = -1;
    public int Month { get; set; } = -1;
    public int MonthDay { get; set; } = -1;
    public int WeekDay { get; set; } = -1;
    public int Hour { get; set; }  = -1;
    public int Minute { get; set; } = -1;
    public int Flags { get; set; } = -1;

    public uint PackedTime => (uint)(((Year % 100) & 0x1F) << 24
                       | (Month & 0xF) << 20
                       | (MonthDay & 0x3F) << 14
                       | (WeekDay & 0x7) << 11
                       | (Hour & 0x1F) << 6
                       | (Minute & 0x3F)
                       | (Flags & 0x3) << 29);

    public WowTime(DateTimeOffset dateTimeOffset)
    {
        Year = dateTimeOffset.Year - 2000;
        Month = dateTimeOffset.Month - 1;
        MonthDay = dateTimeOffset.Day - 1;
        WeekDay = (int)dateTimeOffset.DayOfWeek;
        Hour = dateTimeOffset.Hour;
        Minute = dateTimeOffset.Minute;
    }
}
