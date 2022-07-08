using System.Runtime.InteropServices;

namespace ChaosPrism.Bindings;

public static partial class SDL2
{
    /// <summary>
    /// Puts text into the clipboard
    /// </summary>
    /// <param name="text">The text to store in the clipboard</param>
    /// <returns>0 on success, or a negative error code on failure</returns>
    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetClipboardText")]
    public static extern int SetClipboardText([MarshalAs(UnmanagedType.LPStr)] String text);

    /// <summary>
    /// Gets the text from clipboard
    /// </summary>
    /// <returns>The clipboard text on success, or an empty string on failure</returns>
    [return: MarshalAs(UnmanagedType.LPStr)]
    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetClipboardText")]
    public static extern String GetClipboardText();

    /// <summary>
    /// Checks if the clipboard exists and contains a non-empty text string.
    /// </summary>
    /// <returns>True if the clipboard has text, otherwise false</returns>
    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasClipboardText")]
    public static extern bool HasClipboardText();
}