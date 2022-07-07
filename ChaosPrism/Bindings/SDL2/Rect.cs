using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ChaosPrism.Bindings;

public static partial class SDL2
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Point
    {
        public int X;
        public int Y;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FPoint
    {
        public float X;
        public float Y;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Rect
    {
        public int X;
        public int Y;
        public int W;
        public int H;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FRect
    {
        public float X;
        public float Y;
        public float W;
        public float H;
    }

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasIntersection")]
    public static extern bool HasIntersection(in Rect a, in Rect b);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_IntersectRect")]
    public static extern bool IntersectRect(in Rect a, in Rect b, out Rect result);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UnionRect")]
    public static extern void UnionRect(in Rect a, in Rect b, out Rect result);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_EnclosePoints")]
    public static extern bool EnclosePoints([In] Point[] points, int count, in Rect clip, out Rect result);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_IntersectRectAndLine")]
    public static extern bool IntersectRectAndLine(in Rect rect, ref int x1, ref int y1, ref int x2, ref int y2);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasIntersectionF")]
    public static extern bool HasIntersectionF(in FRect a, in FRect b);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_IntersectFRect")]
    public static extern bool IntersectFRect(in FRect a, in FRect b, out FRect result);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UnionFRect")]
    public static extern void UnionFRect(in FRect a, in FRect b, out FRect result);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_EncloseFPoints")]
    public static extern bool EncloseFPoints([In] FPoint[] points, int count, in FRect clip, out FRect result);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_IntersectFRectAndLine")]
    public static extern bool IntersectFRectAndLine(in FRect rect, ref float x1, ref float y1, ref float x2,
        ref float y2);
}