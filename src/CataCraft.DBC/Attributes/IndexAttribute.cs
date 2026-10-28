// This file is part of the CataCraft project, which is published under the MIT license.

namespace CataCraft.DBC.Attributes;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property,  AllowMultiple = true)]
public class IndexAttribute : Attribute
{
    public readonly bool NonInline;

    public IndexAttribute(bool noninline)
    {
        NonInline = noninline;
    }
}
