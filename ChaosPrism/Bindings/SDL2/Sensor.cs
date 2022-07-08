using System.Runtime.InteropServices;

namespace ChaosPrism.Bindings;

public static partial class SDL2
{
    public enum SensorType
    {
        Invalid = -1,
        Unknown,
        Accel,
        Gyro
    }

    public const float StandardGravity = 9.80665f;

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LockSensors")]
    public static extern void LockSensors();

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UnlockSensors")]
    public static extern void UnlockSensors();

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_NumSensors")]
    public static extern int NumSensors();

    [return: MarshalAs(UnmanagedType.LPStr)]
    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SensorGetDeviceName")]
    public static extern String SensorGetDeviceName(int deviceIndex);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SensorGetDeviceType")]
    public static extern SensorType SensorGetDeviceType(int deviceIndex);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "SDL_SensorGetDeviceNonPortableType")]
    public static extern int SensorGetDeviceNonPortableType(int deviceIndex);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SensorGetDeviceInstanceID")]
    public static extern int SensorGetDeviceInstanceID(int deviceIndex);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SensorOpen")]
    public static extern IntPtr SensorOpen(int deviceIndex);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SensorFromInstanceID")]
    public static extern IntPtr SensorFromInstanceID(int instanceId);

    [return: MarshalAs(UnmanagedType.LPStr)]
    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SensorGetName")]
    public static extern String SensorGetName(IntPtr sensor);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SensorGetType")]
    public static extern SensorType SensorGetType(IntPtr sensor);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SensorGetNonPortableType")]
    public static extern int SensorGetNonPortableType(IntPtr sensor);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SensorGetInstanceID")]
    public static extern int SensorGetInstanceID(IntPtr sensor);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SensorGetData")]
    public static extern int SensorGetData(IntPtr sensor, [Out] float[] data, int numValues);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SensorClose")]
    public static extern void SensorClose(IntPtr sensor);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SensorUpdate")]
    public static extern void SensorUpdate();
}