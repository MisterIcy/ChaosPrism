using System.Runtime.InteropServices;

namespace ChaosPrism.Bindings;

public static partial class SDL2
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DisplayMode
    {
        public uint Format;
        public int W;
        public int H;
        public int RefreshRate;
        public IntPtr DriverData;
    }

    public enum WindowFlags : uint
    {
        Fullscreen = 0x00000001,
        OpenGL = 0x00000002,
        Shown = 0x00000004,
        Hidden = 0x00000008,
        Borderless = 0x00000010,
        Resizable = 0x00000020,
        Minimized = 0x00000040,
        Maximized = 0x00000080,
        MouseGrabbed = 0x00000100,
        InputFocus = 0x00000200,
        MouseFocus = 0x00000400,
        FullscreenDesktop = (Fullscreen | 0x00001000),
        Foreign = 0x00000800,
        AllowHighDpi = 0x00002000,
        MouseCapture = 0x00004000,
        AlwaysOnTop = 0x00008000,
        SkipTaskbar = 0x00010000,
        Utility = 0x00020000,
        ToolTip = 0x00040000,
        PopupMenu = 0x00080000,
        KeyboardGrabbed = 0x00100000,
        Vulkan = 0x10000000,
        Metal = 0x20000000,
        InputGrabbed = MouseGrabbed
    }

    public const uint WindowPosUndefinedMask = 0x1FFF0000u;
    public const uint WindowPosCenteredMask = 0x2FFF0000u;

    public enum WindowEventID
    {
        None,
        Shown,
        Hidden,
        Exposed,
        Moved,
        Resized,
        SizeChanged,
        Minimized,
        Maximized,
        Restored,
        Enter,
        Leave,
        FocusGained,
        FocusLost,
        Close,
        TakeFocus,
        HitTest,
        IccProfileChanged,
        DisplayChanged
    }

    public enum DisplayEventID
    {
        None,
        Orientation,
        Connected,
        Disconnected
    }

    public enum DisplayOrientation
    {
        Unknown,
        Landscape,
        LandscapeFlipped,
        Portrait,
        PortraitFlipped
    }

    public enum FlashOperation
    {
        Cancel,
        Briefly,
        UntilFocused
    }

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetNumVideoDrivers")]
    public static extern int GetNumVideoDrivers();

    [return: MarshalAs(UnmanagedType.LPStr)]
    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetVideoDriver")]
    public static extern String GetVideoDriver(int index);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_VideoInit")]
    public static extern int VideoInit([MarshalAs(UnmanagedType.LPStr)] String driverName);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_VideoQuit")]
    public static extern void VideoQuit();

    [return: MarshalAs(UnmanagedType.LPStr)]
    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetCurrentVideoDriver")]
    public static extern String GetCurrentVideoDriver();

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetNumVideoDisplays")]
    public static extern int GetNumVideoDisplays();

    [return: MarshalAs(UnmanagedType.LPStr)]
    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetDisplayName")]
    public static extern String GetDisplayName(int displayIndex);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetDisplayBounds")]
    public static extern int GetDisplayBounds(int displayIndex, out Rect rect);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetDisplayUsableBounds")]
    public static extern int GetDisplayUsableBounds(int displayIndex, out Rect rect);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetDisplayDPI")]
    public static extern int GetDisplayDPI(int displayIndex, out float ddpi, out float hdpi, out float vdpi);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetDisplayOrientation")]
    public static extern DisplayOrientation GetDisplayOrientation(int displayIndex);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetNumDisplayModes")]
    public static extern int GetNumDisplayModes(int displayIndex);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetDisplayMode")]
    public static extern int GetDisplayMode(int displayIndex, int modeIndex, out DisplayMode mode);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetDesktopDisplayMode")]
    public static extern int GetDesktopDisplayMode(int displayIndex, out DisplayMode mode);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetCurrentDisplayMode")]
    public static extern int GetCurrentDisplayMode(int displayIndex, out DisplayMode mode);

    [return: MarshalAs(UnmanagedType.LPStruct)]
    public static extern DisplayMode? SDL_GetClosestDisplayMode(int displayIndex, ref DisplayMode closest);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowDisplayIndex")]
    public static extern int GetWindowDisplayIndex(IntPtr window);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowDisplayMode")]
    public static extern int SetWindowDisplayMode(IntPtr window, in DisplayMode? mode);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowDisplayMode")]
    public static extern int GetWindowDisplayMode(IntPtr window, out DisplayMode mode);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowICCProfile")]
    public static extern IntPtr GetWindowICCProfile(IntPtr window, out ulong size);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowPixelFormat")]
    public static extern uint GetWindowPixelFormat(IntPtr window);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CreateWindow")]
    public static extern IntPtr CreateWindow([MarshalAs(UnmanagedType.LPStr)] String title, int x, int y, int w,
        int h, uint flags);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CreateWindowFrom")]
    public static extern IntPtr CreateWindowFrom(IntPtr data);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowID")]
    public static extern uint GetWindowID(IntPtr window);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowFromID")]
    public static extern IntPtr GetWindowFromID(uint windowId);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowFlags")]
    public static extern uint GetWindowFlags(IntPtr window);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowTitle")]
    public static extern void SetWindowTitle(IntPtr window, [MarshalAs(UnmanagedType.LPStr)] String title);

    [return: MarshalAs(UnmanagedType.LPStr)]
    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowTitle")]
    public static extern String GetWindowTitle(IntPtr window);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowIcon")]
    public static extern void SetWindowIcon(IntPtr window, IntPtr iconSurface);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowData")]
    public static extern IntPtr SetWindowData(IntPtr window, [MarshalAs(UnmanagedType.LPStr)] String name,
        IntPtr userData);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowData")]
    public static extern IntPtr GetWindowData(IntPtr window, [MarshalAs(UnmanagedType.LPStr)] String name);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowPosition")]
    public static extern void SetWindowPosition(IntPtr window, int x, int y);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowPosition")]
    public static extern void GetWindowPosition(IntPtr window, out int x, out int y);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowSize")]
    public static extern void SetWindowSize(IntPtr window, int w, int h);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowSize")]
    public static extern void GetWindowSize(IntPtr window, out int w, out int h);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowBordersSize")]
    public static extern int GetWindowBordersSize(IntPtr window, out int top, out int left, out int bottom,
        out int right);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowMinimumSize")]
    public static extern void SetWindowMinimumSize(IntPtr window, int minW, int minH);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowMinimumSize")]
    public static extern void GetWindowMinimumSize(IntPtr window, out int minW, out int minH);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowMaximumSize")]
    public static extern void SetWindowMaximumSize(IntPtr window, int maxW, int maxH);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowMaximumSize")]
    public static extern void GetWindowMaximumSize(IntPtr window, out int maxW, out int maxH);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowBordered")]
    public static extern void SetWindowBordered(IntPtr window, bool bordered);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowResizable")]
    public static extern void SetWindowResizable(IntPtr window, bool resizable);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowAlwaysOnTop")]
    public static extern void SetWindowAlwaysOnTop(IntPtr window, bool onTop);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_ShowWindow")]
    public static extern void ShowWindow(IntPtr window);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HideWindow")]
    public static extern void HideWindow(IntPtr window);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RaiseWindow")]
    public static extern void RaiseWindow(IntPtr window);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_MaximizeWindow")]
    public static extern void MaximizeWindow(IntPtr window);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_MinimizeWindow")]
    public static extern void MinimizeWindow(IntPtr window);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RestoreWindow")]
    public static extern void RestoreWindow(IntPtr window);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowFullscreen")]
    public static extern int SetWindowFullscreen(IntPtr window, uint flags);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowSurface")]
    public static extern IntPtr GetWindowSurface(IntPtr window);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UpdateWindowSurface")]
    public static extern int UpdateWindowSurface(IntPtr window);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UpdateWindowSurfaceRects")]
    public static extern int UpdateWindowSurfaceRects(IntPtr window, [In] Rect[] rects, int numRects);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowGrab")]
    public static extern void SetWindowGrab(IntPtr window, bool grabbed);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowKeyboardGrab")]
    public static extern void SetWindowKeyboardGrab(IntPtr window, bool grabbed);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowMouseGrab")]
    public static extern void SetWindowMouseGrab(IntPtr window, bool grabbed);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowGrab")]
    public static extern bool GetWindowGrab(IntPtr window);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowKeyboardGrab")]
    public static extern bool GetWindowKeyboardGrab(IntPtr window);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowMouseGrab")]
    public static extern bool GetWindowMouseGrab(IntPtr window);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetGrabbedWindow")]
    public static extern IntPtr GetGrabbedWindow();

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowMouseRect")]
    public static extern int SetWindowMouseRect(IntPtr window, in Rect? rect);

    [return: MarshalAs(UnmanagedType.LPStruct)]
    public static extern Rect? SDL_GetWindowMouseRect(IntPtr window);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowBrightness")]
    public static extern int SetWindowBrightness(IntPtr window, float brightness);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowBrightness")]
    public static extern float GetWindowBrightness(IntPtr window);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowOpacity")]
    public static extern int SetWindowOpacity(IntPtr window, float opacity);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowOpacity")]
    public static extern int GetWindowOpacity(IntPtr window, out float opacity);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowModalFor")]
    public static extern int SetWindowModalFor(IntPtr modalWindow, IntPtr parentWindow);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowInputFocus")]
    public static extern int SetWindowInputFocus(IntPtr window);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowGammaRamp")]
    public static extern int SetWindowGammaRamp(IntPtr window, [In] ushort[] red, [In] ushort green,
        [In] ushort[] blue);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetWindowGammaRamp")]
    public static extern int GetWindowGammaRamp(IntPtr window, [Out] ushort[] red, [Out] ushort[] green,
        [Out] ushort[] blue);

    public enum HitTestResult
    {
        Normal,
        Draggable,
        TopLeft,
        Top,
        TopRight,
        Right,
        BottomRight,
        Bottom,
        BottomLeft,
        Left
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate HitTestResult HitTest(IntPtr window, [In] Point[] area, IntPtr data);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetWindowHitTest")]
    public static extern int SetWindowHitTest(IntPtr window, HitTest callback, IntPtr callbackData);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_FlashWindow")]
    public static extern int FlashWindow(IntPtr window, FlashOperation operation);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_DestroyWindow")]
    public static extern void DestroyWindow(IntPtr window);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_IsScreenSaverEnabled")]
    public static extern bool IsScreenSaverEnabled();

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_EnableScreenSaver")]
    public static extern void EnableScreenSaver();

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_DisableScreenSaver")]
    public static extern void DisableScreenSaver();
}