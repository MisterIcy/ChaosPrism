namespace ChaosPrism.Managed.Graphics;

public class Point
{
    protected bool Equals(Point other)
    {
        return _x == other._x && _y == other._y;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Point) obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_x, _y);
    }

    private int _x;
    private int _y;

    /// <summary>
    /// Gets or sets the X coordinate of the point.
    /// </summary>
    public int X
    {
        get => _x;
        set => _x = value;
    }

    /// <summary>
    /// Gets or sets the Y coordinate of the point
    /// </summary>
    public int Y
    {
        get => _y;
        set => _y = value;
    }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public Point(int v) : this(v, v)
    {
    }

    public Point() : this(0)
    {
    }

    public bool IsZero => (X == 0 && Y == 0);

    public static bool operator ==(Point left, Point right)
    {
        return left.X == right.X && left.Y == right.Y;
    }

    public static bool operator !=(Point left, Point right)
    {
        return !(left == right);
    }

    public static Point operator +(Point point)
    {
        if (point.X < 0)
        {
            point.X = Math.Abs(point.X);
        }

        if (point.Y < 0)
        {
            point.Y = Math.Abs(point.Y);
        }

        return point;
    }

    public static Point operator -(Point point)
    {
        point.X *= -1;
        point.Y *= -1;
        return point;
    }

    public static explicit operator Bindings.SDL2.Point(Point point)
    {
        Bindings.SDL2.Point pt;
        pt.X = point.X;
        pt.Y = point.Y;
        return pt;
    }

    public static explicit operator Point(Bindings.SDL2.Point point)
    {
        return new Point(point.X, point.Y);
    }

    public static Point operator +(Point left, Point right)
    {
        return new Point(left.X + right.X, left.Y + right.Y);
    }

    public static Point operator +(Point left, int right)
    {
        return left + new Point(right);
    }

    public static Point operator +(int left, Point right)
    {
        return new Point(left) + right;
    }

    public static Point operator -(Point left, Point right)
    {
        return new Point(left.X - right.X, left.Y - right.Y);
    }

    public static Point operator -(Point left, int right)
    {
        return left - new Point(right);
    }

    public static Point operator -(int left, Point right)
    {
        return new Point(left) - right;
    }

    public static Point operator *(Point left, Point right)
    {
        return new Point(left.X * right.X, left.Y * right.Y);
    }

    public static Point operator *(Point left, int right)
    {
        return left * new Point(right);
    }

    public static Point operator *(int left, Point right)
    {
        return new Point(left) * right;
    }

    public static Point operator /(Point left, Point right)
    {
        if (right.X == 0 || right.Y == 0)
        {
            throw new DivideByZeroException("The Point's coordinates cannot be zero");
        }

        return new Point(left.X / right.X, left.Y / right.Y);
    }

    public static Point operator /(Point left, int right)
    {
        return left / new Point(right);
    }

    public static Point operator /(int left, Point right)
    {
        return new Point(left) / right;
    }
}