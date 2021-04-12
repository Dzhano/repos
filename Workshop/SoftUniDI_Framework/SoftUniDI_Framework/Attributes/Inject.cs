using System;

namespace SoftUniDI_Framework.Attributes
{
    [AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Field)]
    public class Inject : Attribute
    {
    }
}
