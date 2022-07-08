using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ChaosPrism.Bindings;

public static partial class SDL2
{
    /// <summary>
    /// Get the number of CPU cores available.
    /// </summary>
    /// <returns>The total number of logical cpu cores</returns>
    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetCPUCount")]
    public static extern int GetCPUCount();

    /// <summary>
    /// Determine the L1 cache size of the CPU.
    /// </summary>
    /// <returns>The L1 cache size of the CPU in bytes</returns>
    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetCPUCacheLineSize")]
    public static extern int GetCPUCacheLineSize();

    /// <summary>
    /// Determine whether the CPU has the RDTSC instruction
    /// </summary>
    /// <returns></returns>
    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasRDTSC")]
    public static extern bool HasRDTSC();

    /// <summary>
    /// Determine whether the CPU has Altivec features.
    /// </summary>
    /// <returns></returns>
    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasAltiVec")]
    public static extern bool HasAltiVec();

    /// <summary>
    /// Determine whether the CPU has MMX features.
    /// </summary>
    /// <returns></returns>
    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasMMX")]
    public static extern bool HasMMX();

    /// <summary>
    /// Determine whether the CPU has 3DNow! features
    /// </summary>
    /// <returns></returns>
    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_Has3DNow")]
    public static extern bool Has3DNow();

    /// <summary>
    /// Determine whether the CPU has SSE features.
    /// </summary>
    /// <returns></returns>
    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasSSE")]
    public static extern bool HasSSE();

    /// <summary>
    /// Determine whether the CPU has SSE2 features
    /// </summary>
    /// <returns></returns>
    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasSSE2")]
    public static extern bool HasSSE2();

    /// <summary>
    /// Determine whether the CPU has SSE3 features
    /// </summary>
    /// <returns></returns>
    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasSSE3")]
    public static extern bool HasSSE3();

    /// <summary>
    /// Determine whether the CPU has SSE4.1 features
    /// </summary>
    /// <returns></returns>
    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasSSE41")]
    public static extern bool HasSSE41();

    /// <summary>
    /// Determine whether the CPU has SSE4.2 features
    /// </summary>
    /// <returns></returns>
    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasSSE42")]
    public static extern bool HasSSE42();

    /// <summary>
    /// Determine whether the CPU has AVX features
    /// </summary>
    /// <returns></returns>
    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasAVX")]
    public static extern bool HasAVX();

    /// <summary>
    /// Determine whether the CPU has AVX2 features
    /// </summary>
    /// <returns></returns>
    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasAVX2")]
    public static extern bool HasAVX2();

    /// <summary>
    /// Determine whether the CPU has AVX-512 features
    /// </summary>
    /// <returns></returns>
    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasAVX512F")]
    public static extern bool HasAVX512F();

    /// <summary>
    /// Determine whether the CPU has ARM SIMD features
    /// </summary>
    /// <returns></returns>
    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasARMSIMD")]
    public static extern bool HasARMSIMD();

    /// <summary>
    /// Determine whether the CPU has NEON (ARM SIMD) features
    /// </summary>
    /// <returns></returns>
    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasNEON")]
    public static extern bool HasNEON();

    /// <summary>
    /// Determine whether the CPU has LSX (LOONGARCH SIMD) features
    /// </summary>
    /// <returns></returns>
    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasLSX")]
    public static extern bool HasLSX();

    /// <summary>
    /// Determine whether the CPU has LASX (LOONGARCH SIMD) features
    /// </summary>
    /// <returns></returns>
    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_HasLASX")]
    public static extern bool HasLASX();

    /// <summary>
    /// Gets the amount of RAM in the system
    /// </summary>
    /// <returns>The amount of RAM configured in the system in MB</returns>
    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetSystemRAM")]
    public static extern int GetSystemRAM();

    /// <summary>
    /// Report the alignment this system needs for SIMD allocations
    /// </summary>
    /// <returns></returns>
    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SIMDGetAlignment")]
    public static extern ulong SIMDGetAlignment();

    /// <summary>
    /// Allocate memory in a SIMD-friendly way
    /// </summary>
    /// <param name="length">The length in bytes to be allocated</param>
    /// <returns></returns>
    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SIMDAlloc")]
    public static extern IntPtr SIMDAlloc(ulong length);

    /// <summary>
    /// Reallocate memory obtained from SIMDAlloc
    /// </summary>
    /// <param name="memory">The pointer obtained from SIMDAlloc</param>
    /// <param name="length">The length, in bytes, of the block to be allocated</param>
    /// <returns></returns>
    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SIMDRealloc")]
    public static extern IntPtr SIMDRealloc(IntPtr memory, ulong length);

    /// <summary>
    /// Deallocate memory obtained from SIMDAlloc
    /// </summary>
    /// <param name="memory">The pointer returned from SIMDAlloc</param>
    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SIMDFree")]
    public static extern void SIMDFree(IntPtr memory);
}