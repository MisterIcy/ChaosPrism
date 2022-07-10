namespace ChaosPrism.Managed;

/// <summary>
/// Describes the information of a render driver
/// </summary>
public class RendererDriverInfo
{
    /// <summary>
    /// The index of the driver in SDL
    /// </summary>
    public readonly int DriverIndex;

    /// <summary>
    /// Gets the driver's name
    /// </summary>
    public string Name { get; private set; } = "";

    /// <summary>
    /// Gets the driver's flags
    /// </summary>
    /// <see cref="Bindings.SDL2.RendererFlags"/>
    public uint Flags { get; private set; }

    /// <summary>
    /// Gets the number of texture formats supported by the driver
    /// </summary>
    public uint NumTextureFormats { get; private set; }

    /// <summary>
    /// Gets a list of texture formats supported by the driver
    /// </summary>
    public List<uint> TextureFormats { get; private set; } = new List<uint>();

    /// <summary>
    /// Gets the maximum texture width supported by the driver
    /// </summary>
    public int MaxTextureWidth { get; private set; }

    /// <summary>
    /// Gets the maximum texture height supported by the driver.
    /// </summary>
    public int MaxTextureHeight { get; private set; }

    /// <summary>
    /// Creates a new object based on SDL's driver index
    /// </summary>
    /// <param name="driverIndex">The renderer's driver index</param>
    /// <exception cref="SDLException">Thrown when we cannot get the renderer's information</exception>
    public RendererDriverInfo(int driverIndex)
    {
        DriverIndex = driverIndex;
        var result = Bindings.SDL2.GetRenderDriverInfo(driverIndex, out var info);

        if (result != 0)
        {
            throw new SDLException("Could not get the renderer's information");
        }

        Initialize(info);
    }

    /// <summary>
    /// Initializes the object
    /// </summary>
    /// <param name="info">A RendererInfo struct to initialize the object from</param>
    private void Initialize(Bindings.SDL2.RendererInfo info)
    {
        Name = Bindings.SDL2.CharToManagedString(info.Name);
        Flags = info.Flags;
        NumTextureFormats = info.NumTextureFormats;
        TextureFormats = new List<uint>();
        for (int i = 0; i < NumTextureFormats; i++)
        {
            unsafe
            {
                TextureFormats.Add(info.TextureFormats[i]);
            }
        }

        MaxTextureWidth = info.MaxTextureWidth;
        MaxTextureHeight = info.MaxTextureHeight;
    }

    /// <summary>
    /// Creates a new object from a RendererInfo structure
    /// </summary>
    /// <param name="info">The RendererInfo structure to initialize the object from</param>
    public RendererDriverInfo(Bindings.SDL2.RendererInfo info)
    {
        Initialize(info);
    }

    /// <summary>
    /// Gets a value that defines whether the driver supports hardware acceleration
    /// </summary>
    public bool IsAccelerated =>
        (Flags & (uint) Bindings.SDL2.RendererFlags.Accelerated) == (uint) Bindings.SDL2.RendererFlags.Accelerated;

    /// <summary>
    /// Gets a value that defines whether the driver supports software acceleration
    /// </summary>
    public bool IsSoftware =>
        (Flags & (uint) Bindings.SDL2.RendererFlags.Software) == (uint) Bindings.SDL2.RendererFlags.Software;

    /// <summary>
    /// Gets a value that defines whether the driver supports rendering in textures
    /// </summary>
    public bool TargetsTexture =>
        (Flags & (uint) Bindings.SDL2.RendererFlags.TargetTexture) == (uint) Bindings.SDL2.RendererFlags.TargetTexture;

    /// <summary>
    /// Gets a value that defines whether the driver can synchronize presenting with VSync
    /// </summary>
    public bool PresentVSync =>
        (Flags & (uint) Bindings.SDL2.RendererFlags.PresentVSync) == (uint) Bindings.SDL2.RendererFlags.PresentVSync;
}