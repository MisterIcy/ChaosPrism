using System.Runtime.InteropServices;

namespace ChaosPrism.Bindings;

public static partial class SDL2
{
    public const int NonShapeableWindow = -1;
    public const int InvalidShapeArgument = -2;
    public const int WindowLacksShape = -3;

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CreateShapedWindow")]
    public static extern IntPtr CreateShapedWindow(
        [MarshalAs(UnmanagedType.LPStr)] String title,
        uint x, uint y, uint w, uint h, uint flags);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_IsShapedWindow")]
    public static extern bool IsShapedWindow(IntPtr window);

    public enum WindowShapeModes
    {
        Default,
        BinarizeAlpha,
        ReverseBinarizeAlpha,
        ColorKey
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct WindowShapeParams
    {
        [FieldOffset(0)] public byte BinarizationCutoff;
        [FieldOffset(0)] public Color ColorKey;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct WindowShapeMode
    {
        public WindowShapeModes Mode;
        public WindowShapeParams Parameters;
    }

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowShape")]
    public static extern int SetWindowShape(IntPtr window, IntPtr surface, ref WindowShapeMode mode);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetShapedWindowMode")]
    public static extern int GetShapedWindowMode(IntPtr window, out WindowShapeMode mode);
}