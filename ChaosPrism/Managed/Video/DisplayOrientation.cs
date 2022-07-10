namespace ChaosPrism.Managed;

/// <summary>
/// Enumeration of display orientations
/// </summary>
public enum DisplayOrientation
{
    Unknown = Bindings.SDL2.DisplayOrientation.Unknown,
    Landscape = Bindings.SDL2.DisplayOrientation.Landscape,
    LandscapeFlipped = Bindings.SDL2.DisplayOrientation.LandscapeFlipped,
    Portrait = Bindings.SDL2.DisplayOrientation.Portrait,
    PortraitFlipped  = Bindings.SDL2.DisplayOrientation.PortraitFlipped
}