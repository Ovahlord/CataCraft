namespace CataCraft.DBC.Attributes;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property,  AllowMultiple = true)]
public sealed class CardinalityAttribute : Attribute
{
    public int Count { get; }

    public CardinalityAttribute(int count)
    {
        Count = count;
    }
}
