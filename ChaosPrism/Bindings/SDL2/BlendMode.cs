using System.Runtime.InteropServices;

namespace ChaosPrism.Bindings;

public static partial class SDL2
{
    /// <summary>
    /// The blend mode used in drawing operations
    /// </summary>
    public enum BlendMode : int
    {
        /// <summary>
        /// No blending
        /// </summary>
        None = 0x00000000,

        /// <summary>
        /// Alpha blending
        /// </summary>
        Blend = 0x00000001,

        /// <summary>
        /// Additive blending
        /// </summary>
        Add = 0x00000002,

        /// <summary>
        /// Color modulate
        /// </summary>
        Mod = 0x00000004,

        /// <summary>
        /// Color multiply
        /// </summary>
        Mul = 0x00000008,

        /// <summary>
        /// Invalid mode
        /// </summary>
        Invalid = 0x7FFFFFFF
    }

    /// <summary>
    /// The blend operation when combining source and destination pixel components
    /// </summary>
    public enum BlendOperation : int
    {
        /// <summary>
        /// Destination + Source
        /// </summary>
        Add = 0x1,

        /// <summary>
        /// Destination - Source
        /// </summary>
        Subtract = 0x2,

        /// <summary>
        /// Source - Destination
        /// </summary>
        RevSubtract = 0x3,

        /// <summary>
        /// Min(Destination, Source)
        /// </summary>
        Minimum = 0x4,

        /// <summary>
        /// Max(Destination, Source)
        /// </summary>
        Maximum = 0x5
    }

    /// <summary>
    /// The normalized factor used to multiply pixel components
    /// </summary>
    public enum BlendFactor : int
    {
        /// <summary>
        /// 0, 0, 0, 0
        /// </summary>
        Zero = 0x1,

        /// <summary>
        /// 1, 1, 1, 1
        /// </summary>
        One = 0x2,

        /// <summary>
        /// srcR, srcG, srcB, srcA
        /// </summary>
        SrcColor = 0x3,

        /// <summary>
        /// 1-srcR, 1-srcG, 1-srcB, 1-srcA
        /// </summary>
        OneMinusSrcColor = 0x4,

        /// <summary>
        /// srcA, srcA, srcA, srcA
        /// </summary>
        SrcAlpha = 0x5,

        /// <summary>
        /// 1-srcA, 1-srcA, 1-srcA, 1-srcA
        /// </summary>
        OneMinusSrcAlpha = 0x6,

        /// <summary>
        /// dstR, dstG, dstB, dstA
        /// </summary>
        DstColor = 0x7,

        /// <summary>
        /// 1-dstR, 1-dstG, 1-dstB, 1-dstA
        /// </summary>
        OneMinusDstColor = 0x8,

        /// <summary>
        /// dstA, dstA, dstA, dstA
        /// </summary>
        DstAlpha = 0x9,

        /// <summary>
        /// 1-dstA, 1-dstA, 1-dstA, 1-dstA
        /// </summary>
        OneMinusDstAlpha = 0xA
    }

    /// <summary>
    /// Compose a custom blend mode for renderers
    /// </summary>
    /// <param name="srcColorFactor">The blend factor applied to the r,g,b components of the source pixels</param>
    /// <param name="dstColorFactor">The blend factor applied to the r,g,b components of the destination pixels</param>
    /// <param name="colorOperation">The Blend operation used to combine the r,g,b components of the source and destination pixels</param>
    /// <param name="srcAlphaFactor">The blend factor applied to the alpha component of the source pixels</param>
    /// <param name="dstAlphaFactor">The blend factor applied to the alpha component of the destination pixels</param>
    /// <param name="alphaOperation">The Blend operation used to combine the alpha component of the source and destination pixels</param>
    /// <returns>A BlendMode that represents the chosen factors and operations</returns>
    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ComposeCustomBlendMode")]
    public static extern BlendMode ComposeCustomBlendMode(BlendFactor srcColorFactor, BlendFactor dstColorFactor,
        BlendOperation colorOperation, BlendFactor srcAlphaFactor, BlendFactor dstAlphaFactor,
        BlendOperation alphaOperation);
}