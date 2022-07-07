using System.Runtime.InteropServices;

namespace ChaosPrism.Bindings;

public static partial class SDL2
{
    public enum BlendMode : int
    {
        None = 0x00000000,
        Blend = 0x00000001,
        Add = 0x00000002,
        Mod = 0x00000004,
        Mul = 0x00000008,
        Invalid = 0x7FFFFFFF
    }

    public enum BlendOperation : int
    {
        Add = 0x1,
        Subtract = 0x2,
        RevSubtract = 0x3,
        Minimum = 0x4,
        Maximum = 0x5
    }

    public enum BlendFactor : int
    {
        Zero = 0x1,
        One = 0x2,
        SrcColor = 0x3,
        OneMinusSrcColor = 0x4,
        SrcAlpha = 0x5,
        OneMinusSrcAlpha = 0x6,
        DstColor = 0x7,
        OneMinusDstColor = 0x8,
        DstAlpha = 0x9,
        OneMinusDstAlpha = 0xA
    }

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ComposeCustomBlendMode")]
    public static extern BlendMode ComposeCustomBlendMode(BlendFactor srcColorFactor, BlendFactor dstColorFactor,
        BlendOperation colorOperation, BlendFactor srcAlphaFactor, BlendFactor dstAlphaFactor,
        BlendOperation alphaOperation);
}