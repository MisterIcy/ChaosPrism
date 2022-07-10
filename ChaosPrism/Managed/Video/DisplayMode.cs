namespace ChaosPrism.Managed;

/// <summary>
/// Defines a Display Mode
/// </summary>
public class DisplayMode
{
    /// <summary>
    /// Gets the Pixel Format.
    /// </summary>
    public uint Format { get; }
    
    /// <summary>
    /// Gets the Width
    /// </summary>
    public int Width { get; }
    
    /// <summary>
    /// Gets the Height
    /// </summary>
    public int Height { get; }
    
    /// <summary>
    /// Gets the Refresh Rate
    /// </summary>
    public int RefreshRate { get; }

    /// <summary>
    /// Gets the Pixel format in Human Readable format.
    /// </summary>
    public string HumanReadableFormat
    {
        get => Bindings.SDL2.GetPixelFormatName(Format);
    } 

    /// <summary>
    /// Creates a new object from display mode information
    /// </summary>
    /// <param name="format"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <param name="refreshRate"></param>
    public DisplayMode(uint format, int width, int height, int refreshRate)
    {
        Format = format;
        Width = width;
        Height = height;
        RefreshRate = refreshRate;
    }

    /// <summary>
    /// Creates a new object from an SDL Display Mode
    /// </summary>
    /// <param name="dispMode"></param>
    public DisplayMode(Bindings.SDL2.DisplayMode dispMode) : this(dispMode.Format, dispMode.W, dispMode.H,
        dispMode.RefreshRate)
    {
    }

    /// <summary>
    /// Converts an SDL Display mode to a DisplayMode
    /// </summary>
    /// <param name="mode"></param>
    /// <returns></returns>
    public static explicit operator DisplayMode(Bindings.SDL2.DisplayMode mode)
    {
        return new DisplayMode(mode);
    }

    /// <summary>
    /// Converts a display mode to SDL_DisplayMode
    /// </summary>
    /// <param name="mode"></param>
    /// <returns></returns>
    public static explicit operator Bindings.SDL2.DisplayMode(DisplayMode mode)
    {
        Bindings.SDL2.DisplayMode dispMode = default;
        dispMode.Format = mode.Format;
        dispMode.W = mode.Width;
        dispMode.H = mode.Height;
        dispMode.RefreshRate = mode.RefreshRate;

        return dispMode;
    }
}