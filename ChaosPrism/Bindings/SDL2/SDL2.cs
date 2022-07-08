using System.Runtime.InteropServices;

namespace ChaosPrism.Bindings;

/// <summary>
/// Bindings for SDL2
/// </summary>
public static partial class SDL2
{
    /**
     * Library name used for DllImport
     */
    private const string LibraryName = "SDL2";

    /// <summary>
    /// Timer Subsystem Flag
    /// </summary>
    public const uint InitTimer = 0x00000001u;

    /// <summary>
    /// Audio Subsystem Flag
    /// </summary>
    public const uint InitAudio = 0x00000010u;

    /// <summary>
    /// Video Subsystem Flag
    /// </summary>
    public const uint InitVideo = 0x00000020u;

    /// <summary>
    /// Joystick Subsystem Flag; initializes the Events Subsystem.
    /// </summary>
    public const uint InitJoystick = 0x00000200u;

    /// <summary>
    /// Haptic Subsystem Flag
    /// </summary>
    public const uint InitHaptic = 0x00001000u;

    /// <summary>
    /// Controller Subsystem Flag; initializes the Joystick Subsystem.
    /// </summary>
    public const uint InitGameController = 0x00002000u;

    /// <summary>
    /// Event Subsystem Flag.
    /// </summary>
    public const uint InitEvents = 0x00004000u;

    /// <summary>
    /// Sensor Subsystem Flag.
    /// </summary>
    public const uint InitSensor = 0x00008000u;

    [Obsolete("This flag is kept in SDL for BC, and is not used", true)]
    public const uint InitNoParachute = 0x00100000u;

    public const uint InitEverything = (
        InitTimer | InitAudio | InitVideo | InitJoystick |
        InitHaptic | InitGameController | InitEvents |
        InitSensor);

    /// <summary>
    /// Initializes the SDL Library
    /// </summary>
    /// <param name="flags">One or more of Init_flags, OR'd together </param>
    /// <returns>0 on success, a negative error code on failure</returns>
    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_Init")]
    public static extern int Init(uint flags);

    /// <summary>
    /// Initializes specific SDL subsystems.
    /// </summary>
    /// <param name="flags">One or more of Init_flags, OR'd together </param>
    /// <returns>0 on success, or a negative error code on failure</returns>
    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_InitSubSystem")]
    public static extern int InitSubSystem(uint flags);

    /// <summary>
    /// Shuts down specific SDL subsystem
    /// </summary>
    /// <param name="flags">One or more of Init_flags, OR'd together</param>
    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_QuitSubSystem")]
    public static extern void QuitSubSystem(uint flags);

    /// <summary>
    /// Gets a mask of the specified subsystems which are currently initialized
    /// </summary>
    /// <param name="flags">One or more of Init_flags, OR'd together</param>
    /// <returns>A mask of all initialized subsystems, if flags is 0, otherwise it returns the initialization status of the specified subsystems</returns>
    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_WasInit")]
    public static extern uint WasInit(uint flags);

    /// <summary>
    /// Shuts down all initialized subsystems.
    /// </summary>
    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_Quit")]
    public static extern void Quit();
}