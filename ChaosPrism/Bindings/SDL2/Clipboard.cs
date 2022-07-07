using System.Runtime.InteropServices;

namespace ChaosPrism.Bindings;

public static partial class SDL2
{
    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetClipboardText")]
    public static extern int SetClipboardText([MarshalAs(UnmanagedType.LPStr)] String text);

    [return: MarshalAs(UnmanagedType.LPStr)]
    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetClipboardText")]
    public static extern String GetClipboardText();

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasClipboardText")]
    public static extern bool HasClipboardText();
}