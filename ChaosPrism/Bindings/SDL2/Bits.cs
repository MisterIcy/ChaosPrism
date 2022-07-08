using System.Reflection.Metadata.Ecma335;

namespace ChaosPrism.Bindings;

public static partial class SDL2
{
    public static bool HasExactlyOneBitSet32(uint x)
    {
        return x != 0 && (x & (x - 1)) != 0;
    }
}