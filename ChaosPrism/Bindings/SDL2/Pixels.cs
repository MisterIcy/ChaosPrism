using System.Runtime.InteropServices;

namespace ChaosPrism.Bindings;

public static partial class SDL2
{
    public const byte AlphaOpaque = 255;
    public const byte AlphaTransparent = 0;

    [StructLayout(LayoutKind.Sequential)]
    public struct Color
    {
        public byte R;
        public byte G;
        public byte B;
        public byte A;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Palette
    {
        public int NumColors;
        public IntPtr Colors;
        public uint Version;
        public int RefCount;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct PixelFormat
    {
        public uint Format;
        public IntPtr Palette;
        public byte BitsPerPixel;
        public byte BytesPerPixel;
        private byte padding1;
        private byte padding2;
        public uint RMask;
        public uint GMask;
        public uint BMask;
        public uint AMask;
        public byte RLoss;
        public byte GLoss;
        public byte BLoss;
        public byte ALoss;
        public byte RShift;
        public byte GShift;
        public byte BShift;
        public byte AShift;
        public int RefCount;
        public IntPtr Next;
    }

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetPixelFormatName")]
    private static extern IntPtr SDL_GetPixelFormatName(uint format);

    public static string GetPixelFormatName(uint format)
    {
        return CharToManagedString(SDL_GetPixelFormatName(format));
    }

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_PixelFormatEnumToMasks")]
    public static extern bool PixelFormatEnumToMasks(
        uint format,
        ref int bpp,
        out uint rMask,
        out uint gMask,
        out uint bMask,
        out uint aMask
    );

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_MasksToPixelFormatEnum")]
    public static extern uint MasksToPixelFormatEnum(int bpp, uint rMask, uint gMask, uint bMask, uint aMask);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_AllocFormat")]
    public static extern IntPtr AllocFormat(uint pixelFormat);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_FreeFormat")]
    public static extern void FreeFormat(IntPtr format);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_AllocPalette")]
    public static extern IntPtr AllocPalette(int numColors);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetPixelFormatPalette")]
    public static extern int SetPixelFormatPalette(IntPtr format, IntPtr palette);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetPaletteColors")]
    public static extern int SetPaletteColors(IntPtr palette, [In] Color[] colors, int firstColor,
        int numColors);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_FreePalette")]
    public static extern void FreePalette(IntPtr palette);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_MapRGB")]
    public static extern uint MapRGB(IntPtr format, byte r, byte g, byte b);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_MapRGBA")]
    public static extern uint MapRGBA(IntPtr format, byte r, byte g, byte b, byte a);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetRGB")]
    public static extern void GetRGB(uint pixel, IntPtr format, out byte r, out byte g, out byte b);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetRGBA")]
    public static extern void GetRGBA(uint pixel, IntPtr format, out byte r, out byte g, out byte b, out byte a);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CalculateGammaRamp")]
    public static extern void CalculateGammaRamp(float gamma, [Out] ushort[] ramp);
}