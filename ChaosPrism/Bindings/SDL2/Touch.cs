using System.Reflection.Metadata;
using System.Runtime.InteropServices;

namespace ChaosPrism.Bindings;

public static partial class SDL2
{
    public enum TouchDeviceType
    {
        Invalid = -1,
        Direct,
        IndirectAbsolute,
        IndirectRelative
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Finger
    {
        public long Id;
        public float X;
        public float Y;
        public float Pressure;
    }

    public const int TouchMouseId = -1;
    public const long MouseTouchId = -1;

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetNumTouchDevices")]
    public static extern int GetNumTouchDevices();

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetTouchDevice")]
    public static extern long GetTouchDevice(int index);

    [return: MarshalAs(UnmanagedType.LPStr)]
    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetTouchName")]
    public static extern String GetTouchName(int index);


    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetTouchDeviceType")]
    public static extern TouchDeviceType GetTouchDeviceType(long touchId);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetNumTouchFingers")]
    public static extern int GetNumTouchFingers(long touchId);

    [return: MarshalAs(UnmanagedType.LPStruct)]
    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetTouchFinger")]
    public static extern Finger? GetTouchFinger(long touchId, int index);
}