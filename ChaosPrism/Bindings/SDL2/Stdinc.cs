using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

namespace ChaosPrism.Bindings;

public static partial class SDL2
{
    public static uint FourCC(uint a, uint b, uint c, uint d)
    {
        return (uint) ((a << 0) | (b << 8) | (c << 16) | (d << 24));
    }

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_malloc")]
    public static extern IntPtr malloc(ulong size);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_calloc")]
    public static extern IntPtr calloc(ulong nmemb, ulong size);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_realloc")]
    public static extern IntPtr realloc(IntPtr mem, ulong size);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_free")]
    public static extern void free(IntPtr mem);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetNumAllocations")]
    public static extern int GetNumAllocations();

    [return: MarshalAs(UnmanagedType.LPStr)]
    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetNumAllocations")]
    public static extern String GetNumAllocations([MarshalAs(UnmanagedType.LPStr)] String name);
}