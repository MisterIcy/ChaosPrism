using System.Runtime.InteropServices;

namespace ChaosPrism.Bindings;

public static partial class SDL2
{
    public const uint RwOpsUnknown = 0;
    public const uint RwOpsWinFile = 1;
    public const uint RwOpsStdFile = 2;
    public const uint RwOpsJniFile = 3;
    public const uint RwOpsMemory = 4;
    public const uint RwOpsMemoryRo = 5;

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RWFromFile")]
    public static extern IntPtr RWFromFile(
        [MarshalAs(UnmanagedType.LPStr)] String file,
        [MarshalAs(UnmanagedType.LPStr)] String mode);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RWFromMem")]
    public static extern IntPtr RWFromMem(IntPtr mem, int size);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_AllocRW")]
    public static extern IntPtr AllocRW();

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_FreeRW")]
    public static extern void FreeRW(IntPtr area);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RWsize")]
    public static extern long RWsize(IntPtr context);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RWseek")]
    public static extern long RWseek(IntPtr context, long offset, int whence);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RWtell")]
    public static extern long RWtell(IntPtr context);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RWread")]
    public static extern long RWread(IntPtr context, IntPtr ptr, long size, long maxNum);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RWwrite")]
    public static extern long RWwrite(IntPtr context, IntPtr ptr, long size, long num);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RWclose")]
    public static extern int RWclose(IntPtr context);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LoadFile_RW")]
    public static extern IntPtr LoadFile_RW(IntPtr src, out long dataSize, int freeSrc);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LoadFile")]
    public static extern IntPtr LoadFile([MarshalAs(UnmanagedType.LPStr)] String file, out long dataSize);
}