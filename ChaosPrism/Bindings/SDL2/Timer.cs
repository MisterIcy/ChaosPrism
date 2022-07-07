using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

namespace ChaosPrism.Bindings;

public static partial class SDL2
{
    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetTicks")]
    public static extern uint GetTicks();

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetTicks64")]
    public static extern ulong GetTicks64();

    public static bool TicksPassed(ulong a, ulong b)
    {
        return ((b - a) <= 0);
    }

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetPerformanceCounter")]
    public static extern ulong GetPerformanceCounter();

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetPerformanceFrequency")]
    public static extern ulong GetPerformanceFrequency();

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_Delay")]
    public static extern void Delay(uint ms);
}