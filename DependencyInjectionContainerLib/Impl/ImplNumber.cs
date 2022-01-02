using System;

namespace DependencyInjectionContainerLib
{
    [Flags]
    public enum ImplNumber
    {
        None,
        First,
        Second,
        Any = None | First | Second,
    }
}