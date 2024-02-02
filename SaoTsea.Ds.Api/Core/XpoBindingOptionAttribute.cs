using System;

namespace SaoTsea.Ds.Api.Core
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Method)]
    public class XpoBindingOptionAttribute : Attribute
    {
        public XpoBindingOptionAttribute(bool useSameSession)
        {
            UseSameSession = useSameSession;
        }

        public bool UseSameSession { get; }
    }
}
