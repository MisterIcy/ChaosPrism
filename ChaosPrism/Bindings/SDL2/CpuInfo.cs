using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ChaosPrism.Bindings;

public static partial class SDL2
{
    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetCPUCount")]
    public static extern int GetCPUCount();

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetCPUCacheLineSize")]
    public static extern int GetCPUCacheLineSize();

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasRDTSC")]
    public static extern bool HasRDTSC();

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasAltiVec")]
    public static extern bool HasAltiVec();

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasMMX")]
    public static extern bool HasMMX();

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_Has3DNow")]
    public static extern bool Has3DNow();

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasSSE")]
    public static extern bool HasSSE();

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasSSE2")]
    public static extern bool HasSSE2();

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasSSE3")]
    public static extern bool HasSSE3();

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasSSE41")]
    public static extern bool HasSSE41();

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasSSE42")]
    public static extern bool HasSSE42();

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasAVX")]
    public static extern bool HasAVX();

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasAVX2")]
    public static extern bool HasAVX2();

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasAVX512F")]
    public static extern bool HasAVX512F();

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasARMSIMD")]
    public static extern bool HasARMSIMD();

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasNEON")]
    public static extern bool HasNEON();

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasLSX")]
    public static extern bool HasLSX();

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasLASX")]
    public static extern bool HasLASX();

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetSystemRAM")]
    public static extern int GetSystemRAM();

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SIMDGetAlignment")]
    public static extern ulong SIMDGetAlignment();

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SIMDAlloc")]
    public static extern IntPtr SIMDAlloc(ulong length);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SIMDRealloc")]
    public static extern IntPtr SIMDRealloc(IntPtr memory, ulong length);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SIMDFree")]
    public static extern void SIMDFree(IntPtr memory);
}