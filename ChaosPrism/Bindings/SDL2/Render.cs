using System.Drawing;
using System.Runtime.InteropServices;

namespace ChaosPrism.Bindings;

public static partial class SDL2
{
    public enum RendererFlags
    {
        Software = 0x00000001,
        Accelerated = 0x00000002,
        PresentVSync = 0x00000004,
        TargetTexture = 0x00000008
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct RendererInfo
    {
        public IntPtr Name;
        public uint Flags;
        public uint NumTextureFormats;
        public fixed uint TextureFormats[16];
        public int MaxTextureWidth;
        public int MaxTextureHeight;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Vertex
    {
        public FPoint Position;
        public Color Color;
        public FPoint TexCoord;
    }

    public enum ScaleMode
    {
        Nearest,
        Linear,
        Best
    }

    public enum TextureAccess
    {
        Static,
        Streaming,
        Target
    }

    public enum TextureModulate
    {
        None = 0x00000000,
        Color = 0x00000001,
        Alpha = 0x00000002
    }

    public enum RendererFlip
    {
        None = 0x00000000,
        Horizontal = 0x00000001,
        Vertical = 0x00000002,
    }

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetNumRenderDrivers")]
    public static extern int GetNumRenderDrivers();

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetRenderDriverInfo")]
    public static extern int GetRenderDriverInfo(int index, out RendererInfo info);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CreateWindowAndRenderer")]
    public static extern int CreateWindowAndRenderer(int width, int height, uint windowFlags, out IntPtr window,
        out IntPtr renderer);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CreateRenderer")]
    public static extern IntPtr CreateRenderer(IntPtr window, int index, uint flags);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CreateSoftwareRenderer")]
    public static extern IntPtr CreateSoftwareRenderer(IntPtr surface);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetRenderer")]
    public static extern IntPtr GetRenderer(IntPtr window);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderGetWindow")]
    public static extern IntPtr RenderGetWindow(IntPtr renderer);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetRendererInfo")]
    public static extern int GetRendererInfo(IntPtr renderer, out RendererInfo info);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetRendererOutputSize")]
    public static extern int GetRendererOutputSize(IntPtr renderer, out int w, out int h);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CreateTexture")]
    public static extern IntPtr CreateTexture(IntPtr renderer, uint format, int access, int w, int h);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_CreateTextureFromSurface")]
    public static extern IntPtr CreateTextureFromSurface(IntPtr renderer, IntPtr surface);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_QueryTexture")]
    public static extern int QueryTexture(IntPtr texture, out uint format, out int access, out int w, out int h);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetTextureColorMod")]
    public static extern int SetTextureColorMod(IntPtr texture, byte r, byte g, byte b);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetTextureColorMod")]
    public static extern int GetTextureColorMod(IntPtr texture, out byte r, out byte g, out byte b);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetTextureAlphaMod")]
    public static extern int SetTextureAlphaMod(IntPtr texture, byte alpha);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetTextureAlphaMod")]
    public static extern int GetTextureAlphaMod(IntPtr texture, out byte alpha);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetTextureBlendMode")]
    public static extern int SetTextureBlendMode(IntPtr texture, BlendMode blendMode);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetTextureBlendMode")]
    public static extern int GetTextureBlendMode(IntPtr texture, out BlendMode blendMode);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetTextureScaleMode")]
    public static extern int SetTextureScaleMode(IntPtr texture, ScaleMode scaleMode);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetTextureScaleMode")]
    public static extern int GetTextureScaleMode(IntPtr texture, out ScaleMode scaleMode);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetTextureUserData")]
    public static extern int SetTextureUserData(IntPtr texture, IntPtr userData);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetTextureUserData")]
    public static extern IntPtr GetTextureUserData(IntPtr texture);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UpdateTexture")]
    public static extern int UpdateTexture(IntPtr texture, in Rect? rect, IntPtr pixels, int pitch);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UpdateYUVTexture")]
    public static extern int UpdateYUVTexture(IntPtr texture, in Rect? rect, in byte yPlane, in int yPitch,
        in byte uPlane, in int uPitch, in byte vPlane, in int vPitch);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UpdateNVTexture")]
    public static extern int UpdateNVTexture(IntPtr texture, in Rect? rect, in byte yPlane, int yPitch,
        in byte uvPlane, int uvPitch);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LockTexture")]
    public static extern int LockTexture(IntPtr texture, in Rect? rect, out IntPtr pixels, out int pitch);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_LockTextureToSurface")]
    public static extern int LockTextureToSurface(IntPtr texture, in Rect? rect, out IntPtr surface);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_UnlockTexture")]
    public static extern void UnlockTexture(IntPtr texture);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderTargetSupported")]
    public static extern bool RenderTargetSupported(IntPtr renderer);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetRenderTarget")]
    public static extern int SetRenderTarget(IntPtr renderer, IntPtr texture);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetRenderTarget")]
    public static extern IntPtr GetRenderTarget(IntPtr renderer);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderSetLogicalSize")]
    public static extern int RenderSetLogicalSize(IntPtr renderer, int w, int h);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderGetLogicalSize")]
    public static extern void RenderGetLogicalSize(IntPtr renderer, out int w, out int h);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderSetIntegerScale")]
    public static extern int RenderSetIntegerScale(IntPtr renderer, bool enable);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderGetIntegerScale")]
    public static extern bool RenderGetIntegerScale(IntPtr renderer);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderSetViewport")]
    public static extern int RenderSetViewport(IntPtr renderer, in Rect? rect);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderGetViewport")]
    public static extern void RenderGetViewport(IntPtr renderer, out Rect? rect);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderSetClipRect")]
    public static extern int RenderSetClipRect(IntPtr renderer, in Rect? rect);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderGetClipRect")]
    public static extern void RenderGetClipRect(IntPtr renderer, out Rect? rect);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderIsClipEnabled")]
    public static extern bool RenderIsClipEnabled(IntPtr renderer);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderSetScale")]
    public static extern int RenderSetScale(IntPtr renderer, float scaleX, float scaleY);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderGetScale")]
    public static extern void RenderGetScale(IntPtr renderer, out float scaleX, out float scaleY);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderWindowToLogical")]
    public static extern void RenderWindowToLogical(IntPtr renderer, int windowX, int windowY, out float logicalX,
        out float logicalY);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderLogicalToWindow")]
    public static extern void RenderLogicalToWindow(IntPtr renderer, float logicalX, float logicalY,
        out int windowX, out int windowY);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetRenderDrawColor")]
    public static extern int SetRenderDrawColor(IntPtr renderer, byte r, byte g, byte b, byte a);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetRenderDrawColor")]
    public static extern int GetRenderDrawColor(IntPtr renderer, out byte r, out byte g, out byte b, out byte a);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_SetRenderDrawBlendMode")]
    public static extern int SetRenderDrawBlendMode(IntPtr renderer, BlendMode blendMode);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GetRenderDrawBlendMode")]
    public static extern int GetRenderDrawBlendMode(IntPtr renderer, out BlendMode blendMode);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderClear")]
    public static extern int RenderClear(IntPtr renderer);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderDrawPoint")]
    public static extern int RenderDrawPoint(IntPtr renderer, int x, int y);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderDrawPoints")]
    public static extern int RenderDrawPoints(IntPtr renderer, [In] Point[] points, int count);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderDrawLine")]
    public static extern int RenderDrawLine(IntPtr renderer, int x1, int y1, int x2, int y2);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderDrawLines")]
    public static extern int RenderDrawLines(IntPtr renderer, [In] Point[] points, int count);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderDrawRect")]
    public static extern int RenderDrawRect(IntPtr renderer, in Rect rect);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderDrawRects")]
    public static extern int RenderDrawRects(IntPtr renderer, [In] Rect[] rects, int count);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderFillRect")]
    public static extern int RenderFillRect(IntPtr renderer, in Rect rect);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderFillRects")]
    public static extern int RenderFillRects(IntPtr renderer, [In] Rect[] rects, int count);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderCopy")]
    public static extern int RenderCopy(IntPtr renderer, IntPtr texture, in Rect? srcRect, in Rect? dstRect)

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderCopyEx")]
    public static extern int RenderCopyEx(IntPtr renderer, IntPtr texture, in Rect? srcRect, in Rect? dstRect,
        double angle, in Point? center, RendererFlip flip);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderDrawPointF")]
    public static extern int RenderDrawPointF(IntPtr renderer, float x, float y);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderDrawPointsF")]
    public static extern int RenderDrawPointsF(IntPtr renderer, [In] PointF[] points, int count);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderDrawLineF")]
    public static extern int RenderDrawLineF(IntPtr renderer, float x1, float y1, float x2, float y2);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderDrawLinesF")]
    public static extern int RenderDrawLinesF(IntPtr renderer, [In] PointF[] points, int count);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderDrawRectF")]
    public static extern int RenderDrawRectF(IntPtr renderer, in FRect? rect);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderDrawRectsF")]
    public static extern int RenderDrawRectsF(IntPtr renderer, [In] FRect[] rects, int count);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderFillRectF")]
    public static extern int RenderFillRectF(IntPtr renderer, in FRect? rect);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderFillRectsF")]
    public static extern int RenderFillRectsF(IntPtr renderer, [In] FRect[] rects, int count);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderCopyF")]
    public static extern int RenderCopyF(IntPtr renderer, IntPtr texture, in Rect? srcRect, in FRect? dstRect);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderCopyExF")]
    public static extern int RenderCopyExF(IntPtr renderer, IntPtr texture, in Rect? srcRect, in FRect? dstRect,
        double angle, in FPoint? center, RendererFlip flip);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderGeometry")]
    public static extern int RenderGeometry(IntPtr renderer, IntPtr teture, [In] Vertex[] vertices, int numVertices,
        [In] int[] indices, int numIndices);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderGeometryRaw")]
    public static extern int RenderGeometryRaw(IntPtr renderer, IntPtr texture, in float xy, int xyStride,
        in Color color, int colorStride, in float uv, int uvStride, int numVertices, [In] int[] indices,
        int numIndices);

    public static extern int
        SDL_RenderReadPixels(IntPtr renderer, in Rect? rect, uint format, IntPtr pixels, int pitch);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderPresent")]
    public static extern void RenderPresent(IntPtr renderer);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_DestroyTexture")]
    public static extern void DestroyTexture(IntPtr texture);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_DestroyRenderer")]
    public static extern void DestroyRenderer(IntPtr renderer);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderFlush")]
    public static extern int RenderFlush(IntPtr renderer);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_BindTexture")]
    public static extern int GL_BindTexture(IntPtr renderer, out float texW, out float texH);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_GL_UnbindTexture")]
    public static extern int GL_UnbindTexture(IntPtr texture);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderGetMetalLayer")]
    public static extern IntPtr RenderGetMetalLayer(IntPtr renderer);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "SDL_RenderGetMetalCommandEncoder")]
    public static extern IntPtr RenderGetMetalCommandEncoder(IntPtr renderer);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, EntryPoint = "SDL_RenderSetVSync")]
    public static extern int RenderSetVSync(IntPtr renderer, int vsyncOnOff);
}