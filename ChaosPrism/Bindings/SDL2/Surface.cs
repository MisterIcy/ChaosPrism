using System.IO.Pipes;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

namespace ChaosPrism.Bindings;

public static partial class SDL2
{
    public const int SwSurface = 0;
    public const int SurfacePreAlloc = 0x00000001;
    public const int SurfaceRleAccel = 0x00000002;
    public const int SurfaceDontFree = 0x00000004;
    public const int SurfaceSimdAligned = 0x00000008;

    public static bool MustLockSurface(Surface s)
    {
        return (s.Flags & SurfaceRleAccel) != 0;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Surface
    {
        public uint Flags;
        public IntPtr PixelFormat;
        public int W;
        public int H;
        public int Pitch;
        public IntPtr Pixels;
        public IntPtr UserData;
        public int Locked;
        public IntPtr ListBlitMap;
        public Rect ClipRect;
        public IntPtr BlitMap;
        public int RefCount;
    }

    public enum YuvConversionMode
    {
        Jpeg,
        Bt601,
        Bt709,
        Automatic
    }

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CreateRGBSurface")]
    public static extern IntPtr CreateRGBSurface(uint flags, int width, int height, int depth, uint rMask,
        uint gMask, uint bMask, uint aMask);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CreateRGBSurfaceWithFormat")]
    public static extern IntPtr CreateRGBSurfaceWithFormat(uint flags, int width, int height, int depth,
        uint format);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CreateRGBSurfaceFrom")]
    public static extern IntPtr CreateRGBSurfaceFrom(IntPtr pixels, int width, int height, int depth, int pitch,
        uint rMask, uint gMask, uint bMask, uint aMask);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "SDL_CreateRGBSurfaceWithFormatFrom")]
    public static extern IntPtr CreateRGBSurfaceWithFormatFrom(IntPtr pixels, int width, int height, int depth,
        int pitch, uint format);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_FreeSurface")]
    public static extern void FreeSurface();

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetSurfacePalette")]
    public static extern int SetSurfacePalette(IntPtr surface, IntPtr palette);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LockSurface")]
    public static extern int LockSurface(IntPtr surface);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UnlockSurface")]
    public static extern void UnlockSurface(IntPtr surface);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LoadBMP_RW")]
    public static extern IntPtr LoadBMP_RW(IntPtr src, int freeSrc);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SaveBMP_RW")]
    public static extern int SaveBMP_RW(IntPtr surface, IntPtr dst, int freeDst);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetSurfaceRLE")]
    public static extern int SetSurfaceRLE(IntPtr surface, int flag);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasSurfaceRLE")]
    public static extern bool HasSurfaceRLE(IntPtr surface);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetColorKey")]
    public static extern int SetColorKey(IntPtr surface, int flag, uint key);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasColorKey")]
    public static extern bool HasColorKey(IntPtr surface);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetColorKey")]
    public static extern int GetColorKey(IntPtr surface, out uint key);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetSurfaceColorMod")]
    public static extern int SetSurfaceColorMod(IntPtr surface, byte r, byte g, byte b);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetSurfaceColorMod")]
    public static extern int GetSurfaceColorMod(IntPtr surface, out byte r, out byte g, out byte b);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetSurfaceAlphaMod")]
    public static extern int SetSurfaceAlphaMod(IntPtr surface, byte alpha);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetSurfaceAlphaMod")]
    public static extern int GetSurfaceAlphaMod(IntPtr surface, out byte alpha);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetSurfaceBlendMode")]
    public static extern int SetSurfaceBlendMode(IntPtr surface, BlendMode blendMode);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetSurfaceBlendMode")]
    public static extern int GetSurfaceBlendMode(IntPtr surface, out BlendMode mode);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetClipRect")]
    public static extern bool SetClipRect(IntPtr surface, in Rect? rect);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetClipRect")]
    public static extern void GetClipRect(IntPtr surface, out Rect? rect);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_DuplicateSurface")]
    public static extern IntPtr DuplicateSurface(IntPtr surface);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ConvertSurface")]
    public static extern IntPtr ConvertSurface(IntPtr surface, in PixelFormat format, uint flags);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ConvertSurfaceFormat")]
    public static extern IntPtr ConvertSurfaceFormat(IntPtr surface, uint pixelFormat, uint flags);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ConvertPixels")]
    public static extern int ConvertPixels(int width, int height, uint srcFormat, IntPtr src, int srcPitch,
        uint dstFormat, IntPtr dst, int dstPitch);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_PremultiplyAlpha")]
    public static extern int PremultiplyAlpha(int width, int height, uint srcFormat, IntPtr src, int srcPitch,
        uint dstFormat, IntPtr dst, int dstPitch);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_FillRect")]
    public static extern int FillRect(IntPtr surface, in Rect? rect, uint color);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_FillRects")]
    public static extern int FillRects(IntPtr surface, [In] Rect[] rects, int count, uint color);

    public static int BlitSurface(IntPtr src, in Rect? srcRect, IntPtr dst, ref Rect? dstRect)
    {
        return UpperBlit(src, in srcRect, dst, ref dstRect);
    }

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UpperBlit")]
    public static extern int UpperBlit(IntPtr src, in Rect? srcRect, IntPtr dst, ref Rect? dstRect);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LowerBlit")]
    public static extern int LowerBlit(IntPtr src, ref Rect? srcRect, IntPtr dst, ref Rect? dstRect);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SoftStretch")]
    public static extern int SoftStretch(IntPtr src, in Rect? srcRect, IntPtr dst, in Rect? dstRect);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SoftStretchLinear")]
    public static extern int SoftStretchLinear(IntPtr src, in Rect? srcRect, IntPtr dst, in Rect? dstRect);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UpperBlitScaled")]
    public static extern int UpperBlitScaled(IntPtr src, in Rect? srcRect, IntPtr dst, ref Rect? dstRect);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LowerBlitScaled")]
    public static extern int LowerBlitScaled(IntPtr src, ref Rect? srcRect, IntPtr dst, ref Rect? dstRect);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetYUVConversionMode")]
    public static extern void SetYUVConversionMode(YuvConversionMode mode);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetYUVConversionMode")]
    public static extern YuvConversionMode GetYUVConversionMode();

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "SDL_GetYUVConversionModeForResolution")]
    public static extern YuvConversionMode GetYUVConversionModeForResolution(int width, int height);
}