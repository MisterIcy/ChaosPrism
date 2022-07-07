using System.Runtime.InteropServices;

namespace ChaosPrism.Bindings;

public static partial class SDL2
{
    public enum MessageBoxFlags : uint
    {
        Error = 0x00000010,
        Warning = 0x00000020,
        Information = 0x00000040,
        ButtonsLeftToRight = 0x00000080,
        ButtonsRightToLeft = 0x00000100,
    }

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ShowSimpleMessageBox")]
    public static extern int ShowSimpleMessageBox(
        uint flags,
        [MarshalAs(UnmanagedType.LPStr)] String title,
        [MarshalAs(UnmanagedType.LPStr)] String message,
        IntPtr window
    );
}