using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;

namespace ChaosPrism.Managed.Graphics;

public class Rectangle
{
    protected bool Equals(Rectangle other)
    {
        return _x == other._x && _y == other._y && _width == other._width && _height == other._height;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Rectangle) obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_x, _y, _width, _height);
    }

    private int _x;
    private int _y;
    private int _width;
    private int _height;

    public int X
    {
        get => _x;
        set => _x = value;
    }

    public int Y
    {
        get => _y;
        set => _y = value;
    }

    public int Width
    {
        get => _width;
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(Width),
                    value,
                    "A rectangle's width must be greater than or equal to zero"
                );
            }

            _width = value;
        }
    }

    public int Height
    {
        get => _height;
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(Height),
                    value,
                    "A rectangle's height must be greater than or equal to zero"
                );
            }

            _height = value;
        }
    }

    public Rectangle(int x, int y, int width, int height)
    {
        X = x;
        Y = y;
        Width = width;
        Height = height;
    }

    public static Rectangle FromLTRB(int left, int top, int right, int bottom)
    {
        return new Rectangle(
            left,
            top,
            right - left,
            bottom - top
        );
    }

    public static explicit operator Bindings.SDL2.Rect(Rectangle rect)
    {
        Bindings.SDL2.Rect sdlRect;
        sdlRect.X = rect.X;
        sdlRect.Y = rect.Y;
        sdlRect.W = rect.Width;
        sdlRect.H = rect.Height;

        return sdlRect;
    }

    public static explicit operator Rectangle(Bindings.SDL2.Rect sdlRect)
    {
        return new Rectangle(sdlRect.X, sdlRect.Y, sdlRect.W, sdlRect.H);
    }

    public int Top
    {
        get => Y;
    }

    public int Left
    {
        get => X;
    }

    public int Right
    {
        get => X + Width;
    }

    public int Bottom
    {
        get => Y + Height;
    }

    public bool IsEmpty => (Width == 0 && Height == 0);
    public bool IsLine => ((Width == 0) || (Height == 0)) && !IsEmpty;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Contains(Point point) => point.X >= Left && point.X <= Right && point.Y >= Top && point.Y <= Bottom;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Contains(Rectangle rectangle) => rectangle.Left >= Left && rectangle.Right <= Right &&
                                                 rectangle.Top >= Top && rectangle.Bottom <= Bottom;

    public static bool operator ==(Rectangle left, Rectangle right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Rectangle left, Rectangle right)
    {
        return !(left == right);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Intersects(Rectangle other)
    {
        return (Math.Max(Left, other.Left) < Math.Min(Right, other.Right)) &&
               (Math.Max(Top, other.Top) < Math.Min(Bottom, other.Bottom));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IntersectWith(Rectangle left, Rectangle right)
    {
        return left.Intersects(right);
    }

    public void Inflate(int val)
    {
        int halfVal = val / 2;
        X -= halfVal;
        Y -= halfVal;
        Width += val;
        Height += val;
    }

    public Rectangle IntersectionWith(Rectangle other)
    {
        if (!this.Intersects(other))
        {
            return new Rectangle(0, 0, 0, 0);
        }

        return Rectangle.FromLTRB(
            Math.Max(Left, other.Left),
            Math.Max(Top, other.Top),
            Math.Min(Right, other.Right),
            Math.Min(Bottom, other.Bottom)
        );
    }

    public void Offset(Point pt)
    {
        X += pt.X;
        Y += pt.Y;
    }

    public void Offset(int v)
    {
        X += v;
        Y += v;
    }
}