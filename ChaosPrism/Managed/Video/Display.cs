using ChaosPrism.Managed.Graphics;

namespace ChaosPrism.Managed;

public class Display
{
    /// <summary>
    /// Gets the number of displays detected by SDL
    /// </summary>
    public static int NumDisplays
    {
        get => Bindings.SDL2.GetNumVideoDisplays();
    }

    /// <summary>
    /// Fetches a list of displays detected by SDL
    /// </summary>
    public static Dictionary<int, string> Displays
    {
        get
        {
            var dictionary = new Dictionary<int, string>();

            for (int i = 0; i < NumDisplays; i++)
            {
                dictionary.Add(i, Bindings.SDL2.GetDisplayName(i));
            }

            return dictionary;
        }
    }

    /// <summary>
    /// Gets the display's Index.
    /// </summary>
    public int Index { get; protected set; }

    /// <summary>
    /// Gets the display's name
    /// </summary>
    public string Name { get; protected set; } = "";

    /// <summary>
    /// Creates a new Display object by SDL's displayIndex
    /// </summary>
    /// <param name="displayIndex"></param>
    public Display(int displayIndex)
    {
        Index = displayIndex;
        Name = Bindings.SDL2.GetDisplayName(Index);
    }

    /// <summary>
    /// Gets the number of video modes supported by the display
    /// </summary>
    public int NumVideoModes => Bindings.SDL2.GetNumDisplayModes(Index);

    /// <summary>
    /// Gets a list of video modes supported by the display
    /// </summary>
    /// <returns></returns>
    public List<DisplayMode> GetDisplayModes()
    {
        var displayModes = new List<DisplayMode>();
        for (int i = 0; i < NumVideoModes; i++)
        {
            var result = Bindings.SDL2.GetDisplayMode(Index, i, out var mode);
            
            displayModes.Add(new DisplayMode(mode));
        }

        return displayModes;
    }
    /// <summary>
    /// Gets the display's Horizontal DPI
    /// </summary>
    public float HorizontalDpi
    {
        get
        {
            var result = Bindings.SDL2.GetDisplayDPI(Index, out var ddpi, out var hdpi, out var vdpi);

            return hdpi;
        }
    }

    /// <summary>
    /// Gets the display's Vertical DPI
    /// </summary>
    public float VerticalDpi
    {
        get
        {
            var result = Bindings.SDL2.GetDisplayDPI(Index, out var ddpi, out var hdpi, out var vdpi);

            return vdpi;
        }
    }

    /// <summary>
    /// Gets the display's Diagonal DPI
    /// </summary>
    public float DiagonalDpi
    {
        get
        {
            var result = Bindings.SDL2.GetDisplayDPI(Index, out var ddpi, out var hdpi, out var vdpi);

            return ddpi;
        }
    }

    /// <summary>
    /// Gets the display mode of the desktop
    /// </summary>
    public DisplayMode DesktopDisplayMode
    {
        get
        {
            var result = Bindings.SDL2.GetDesktopDisplayMode(Index, out var dispMode);

            return (DisplayMode) dispMode;
        }
    }

    /// <summary>
    /// Gets the current display mode
    /// </summary>
    public DisplayMode CurrentDisplayMode
    {
        get
        {
            var result = Bindings.SDL2.GetCurrentDisplayMode(Index, out var mode);

            return (DisplayMode) mode;
        }
    }

    /// <summary>
    /// Gets the display's bounds.
    /// </summary>
    public Rectangle Bounds
    {
        get
        {
            var result = Bindings.SDL2.GetDisplayBounds(Index, out var rect);

            return (Rectangle) rect;
        }
    }

    /// <summary>
    /// Gets the display's usable bounds
    /// </summary>
    public Rectangle UsableBounds
    {
        get
        {
            var result = Bindings.SDL2.GetDisplayUsableBounds(Index, out var rect);

            return (Rectangle) rect;
        }
    }

    /// <summary>
    /// Gets the display's orientation
    /// </summary>
    public DisplayOrientation Orientation => (DisplayOrientation) Bindings.SDL2.GetDisplayOrientation(Index);

    /// <summary>
    /// Gets the display associated with a window 
    /// </summary>
    /// <returns></returns>
    public static Display FromWindow(Window window)
    {
        return window.GetDisplay();
    }
}
