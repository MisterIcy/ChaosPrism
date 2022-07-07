using System.Runtime.InteropServices;

namespace ChaosPrism.Bindings;

public static partial class SDL2
{
    public unsafe struct Guid
    {
        public fixed byte Data[16];
    }

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GUIDToString")]
    public static extern void GUIDToString(
        Guid guid,
        [MarshalAs(UnmanagedType.LPStr)] String buffer,
        int bufferLength);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GUIDFromString")]
    public static extern Guid GUIDFromString([MarshalAs(UnmanagedType.LPStr)] String guid);
}