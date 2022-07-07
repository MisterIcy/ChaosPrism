using System.Runtime.InteropServices;

namespace ChaosPrism.Bindings;

public static partial class SDL2
{
    [return: MarshalAs(UnmanagedType.LPStr)]
    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetBasePath")]
    public static extern String GetBasePath();

    [return: MarshalAs(UnmanagedType.LPStr)]
    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetPrefPath")]
    public static extern String GetPrefPath(
        [MarshalAs(UnmanagedType.LPStr)] String org,
        [MarshalAs(UnmanagedType.LPStr)] String app);
}