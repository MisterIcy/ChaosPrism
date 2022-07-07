using System.Runtime.InteropServices;

namespace ChaosPrism.Bindings;

public static partial class SDL2
{
    public enum PowerState
    {
        Unknown,
        OnBattery,
        NoBattery,
        Charging,
        Charged
    }

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetPowerInfo")]
    public static extern PowerState GetPowerInfo(out int seconds, out int percentage);
}