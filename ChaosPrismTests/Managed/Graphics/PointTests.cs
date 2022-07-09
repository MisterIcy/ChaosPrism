using System;
using System.IO.Pipes;
using ChaosPrism.Bindings;
using ChaosPrism.Managed.Graphics;
using Xunit;

namespace ChaosPrismTests.Managed.Graphics;

public class PointTests
{
    [Fact]
    public void TestCreatePoint()
    {
        var point = new Point(5, 3);
        Assert.Equal(5, point.X);
        Assert.Equal(3, point.Y);
    }

    [Fact]
    public void TestCreateWithSameCoord()
    {
        var point = new Point(4);
        Assert.Equal(4, point.X);
        Assert.Equal(4, point.Y);
    }

    [Fact]
    public void TestCreateEmpty()
    {
        var point = new Point();
        Assert.Equal(0, point.X);
        Assert.Equal(0, point.Y);
    }

    [Fact]
    public void TestZeroIsZero()
    {
        var point = new Point();
        Assert.True(point.IsZero);
    }

    [Fact]
    public void TestNonZeroIsNotZero()
    {
        var point = new Point(3, 4);
        Assert.False(point.IsZero);
    }

    [Fact]
    public void TestPointEquality()
    {
        var pt1 = new Point(3, 4);
        var pt2 = new Point(3, 4);

        Assert.True(pt1 == pt2);
    }

    [Fact]
    public void TestPointInequality()
    {
        var pt1 = new Point(3);
        var pt2 = new Point(4);

        Assert.True(pt1 != pt2);
    }

    [Fact]
    public void TestUnaryPlus()
    {
        var point = new Point(-2, -3);
        point = +point;
        Assert.Equal(2, point.X);
        Assert.Equal(3, point.Y);
    }

    [Fact]
    public void TestUnaryMinus()
    {
        var point = new Point(4, 2);
        point = -point;

        Assert.Equal(-4, point.X);
        Assert.Equal(-2, point.Y);
    }

    [Fact]
    public void TestAddPoints()
    {
        var pt1 = new Point(2, 3);
        var pt2 = new Point(3, 4);

        var pt3 = pt1 + pt2;
        Assert.Equal(5, pt3.X);
        Assert.Equal(7, pt3.Y);
    }

    [Fact]
    public void TestAddPointWithInt()
    {
        var pt1 = new Point(3, 4);
        var pt2 = pt1 + 4;

        Assert.Equal(7, pt2.X);
        Assert.Equal(8, pt2.Y);
    }

    [Fact]
    public void TestAddIntWithPoint()
    {
        var pt1 = new Point(2, 3);
        var pt2 = 8 + pt1;

        Assert.Equal(10, pt2.X);
        Assert.Equal(11, pt2.Y);
    }

    [Fact]
    public void TestPointSubtraction()
    {
        var pt1 = new Point(4, 3);
        var pt2 = new Point(5, 1);

        var pt3 = pt1 - pt2;

        Assert.Equal(-1, pt3.X);
        Assert.Equal(2, pt3.Y);
    }

    [Fact]
    public void TestSubtractIntFromPoint()
    {
        var pt1 = new Point(4, 2);
        var pt2 = pt1 - 3;

        Assert.Equal(1, pt2.X);
        Assert.Equal(-1, pt2.Y);
    }

    [Fact]
    public void TestSubtractPointFromInt()
    {
        var pt1 = new Point(8, 4);
        var pt2 = 3 - pt1;

        Assert.Equal(-5, pt2.X);
        Assert.Equal(-1, pt2.Y);
    }

    [Fact]
    public void TestMultiplyPoints()
    {
        var pt1 = new Point(2, 2);
        var pt2 = new Point(2, 3);

        var pt3 = pt1 * pt2;
        Assert.Equal(4, pt3.X);
        Assert.Equal(6, pt3.Y);
    }

    [Fact]
    public void TestMultiplyPointWithInt()
    {
        var pt1 = new Point(3, 2);
        var pt2 = pt1 * 3;

        Assert.Equal(9, pt2.X);
        Assert.Equal(6, pt2.Y);
    }

    [Fact]
    public void TestMultiplyIntWithPoint()
    {
        var pt1 = new Point(2, 3);
        var pt2 = 4 * pt1;

        Assert.Equal(8, pt2.X);
        Assert.Equal(12, pt2.Y);
    }

    [Fact]
    public void DividePoints()
    {
        var pt1 = new Point(9, 8);
        var pt2 = new Point(3, 2);

        var pt3 = pt1 / pt2;
        Assert.Equal(3, pt3.X);
        Assert.Equal(4, pt3.Y);
    }

    [Fact]
    public void DividePointsDivByZero()
    {
        Assert.Throws<DivideByZeroException>(() =>
        {
            var pt1 = new Point(2, 3);
            var pt2 = new Point(0, 3);

            var pt3 = pt1 / pt2;
        });
    }

    [Fact]
    public void DividePointWithNumber()
    {
        var pt1 = new Point(16, 12);
        var pt2 = pt1 / 2;

        Assert.Equal(8, pt2.X);
        Assert.Equal(6, pt2.Y);
    }

    [Fact]
    public void DividePointWithZero()
    {
        Assert.Throws<DivideByZeroException>(() =>
        {
            var pt1 = new Point(16, 12);
            var pt2 = pt1 / 0;
        });
    }

    [Fact]
    public void DivideNumberWithPoint()
    {
        var pt1 = new Point(4, 5);
        var pt2 = 20 / pt1;

        Assert.Equal(5, pt2.X);
        Assert.Equal(4, pt2.Y);
    }

    [Fact]
    public void DivideNumberWithZeroPoint()
    {
        Assert.Throws<DivideByZeroException>(() =>
        {
            var pt1 = new Point(0, 4);
            var pt2 = 40 / pt1;
        });
    }

    [Fact]
    public void TestEquality()
    {
        var pt1 = new Point(2, 3);
        var pt2 = new Point(2, 3);

        Assert.True(pt1.Equals(pt2));
    }

    [Fact]
    public void TestInequality()
    {
        var pt1 = new Point(4, 5);
        var pt2 = "This is a point";

        Assert.False(pt1.Equals(pt2));
    }

    [Fact]
    public void TestConvertToSDL()
    {
        var pt = new Point(2, 3);

        var sdlPt = (SDL2.Point) pt;

        Assert.Equal(2, sdlPt.X);
        Assert.Equal(3, sdlPt.Y);
    }

    [Fact]
    public void TestConvertFromSDL()
    {
        SDL2.Point sdlPt;
        sdlPt.X = 29;
        sdlPt.Y = 39;

        var pt = (Point) sdlPt;

        Assert.Equal(29, pt.X);
        Assert.Equal(39, pt.Y);
    }
}