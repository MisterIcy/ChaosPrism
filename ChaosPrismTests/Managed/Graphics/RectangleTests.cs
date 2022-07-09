using System;
using ChaosPrism.Bindings;
using Xunit;
using ChaosPrism.Managed.Graphics;

namespace ChaosPrismTests.Managed.Graphics;

public class RectangleTests
{
    [Fact]
    public void TestCreateRectangle()
    {
        var rect = new Rectangle(10, 10, 20, 30);
        Assert.Equal(10, rect.X);
        Assert.Equal(10, rect.Y);
        Assert.Equal(20, rect.Width);
        Assert.Equal(30, rect.Height);
    }

    [Fact]
    public void TestCreateRectangleWithNegativeWidth()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            var rect = new Rectangle(10, 10, -1, 1);
        });
    }

    [Fact]
    public void TestCreateRectangleWithNegativeHeight()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            var rect = new Rectangle(10, 10, 1, -1);
        });
    }

    [Fact]
    public void TestConvertToSDL()
    {
        var rect = new Rectangle(0, 10, 20, 30);
        var sdlRect = (SDL2.Rect) rect;

        Assert.Equal(0, sdlRect.X);
        Assert.Equal(10, sdlRect.Y);
        Assert.Equal(20, sdlRect.W);
        Assert.Equal(30, sdlRect.H);
    }

    [Fact]
    public void TestConvertFromSDL()
    {
        SDL2.Rect sdlRect;
        sdlRect.X = 10;
        sdlRect.Y = 20;
        sdlRect.W = 30;
        sdlRect.H = 40;

        var rect = (Rectangle) sdlRect;

        Assert.Equal(10, rect.X);
        Assert.Equal(20, rect.Y);
        Assert.Equal(30, rect.Width);
        Assert.Equal(40, rect.Height);
    }

    [Fact]
    public void TestTop()
    {
        var rect = new Rectangle(10, 20, 30, 40);
        Assert.Equal(20, rect.Top);
    }

    [Fact]
    public void TestLeft()
    {
        var rect = new Rectangle(10, 20, 30, 40);
        Assert.Equal(10, rect.Left);
    }

    [Fact]
    public void TestBottom()
    {
        var rect = new Rectangle(10, 20, 30, 40);
        Assert.Equal(60, rect.Bottom);
    }

    [Fact]
    public void TestRight()
    {
        var rect = new Rectangle(10, 20, 30, 40);
        Assert.Equal(40, rect.Right);
    }

    [Fact]
    public void TestEmptyIsEmpty()
    {
        var rect = new Rectangle(10, 10, 0, 0);
        Assert.True(rect.IsEmpty);
    }

    [Fact]
    public void TestNonEmptyIsNotEmpty()
    {
        var rect = new Rectangle(10, 10, 20, 30);
        Assert.False(rect.IsEmpty);
        Assert.False(rect.IsLine);
    }

    [Fact]
    public void TestEmptyIsNotLine()
    {
        var rect = new Rectangle(10, 10, 0, 0);
        Assert.True(rect.IsEmpty);
        Assert.False(rect.IsLine);
    }

    [Fact]
    public void TestLineIsLine()
    {
        var rect = new Rectangle(10, 10, 10, 0);
        Assert.True(rect.IsLine);
        Assert.False(rect.IsEmpty);
    }

    [Fact]
    public void TestRectangleIsNotLine()
    {
        var rect = new Rectangle(10, 10, 20, 30);
        Assert.False(rect.IsLine);
        Assert.False(rect.IsEmpty);
    }

    [Fact]
    public void TestRectangleContainsPoint()
    {
        var point = new Point(12, 14);
        var rect = new Rectangle(10, 10, 10, 10);

        Assert.True(rect.Contains(point));
    }

    [Fact]
    public void TestRectangleNotContainsPoint()
    {
        var point = new Point(8, 8);
        var rect = new Rectangle(10, 10, 10, 10);

        Assert.False(rect.Contains(point));
    }

    [Fact]
    public void TestRectangleContainsRectangle()
    {
        var big = new Rectangle(10, 10, 100, 100);
        var small = new Rectangle(30, 30, 30, 30);

        Assert.True(big.Contains(small));
    }

    [Fact]
    public void TestRectangleNotContainsRectangle()
    {
        var big = new Rectangle(10, 10, 100, 100);
        var small = new Rectangle(130, 130, 30, 30);

        Assert.False(big.Contains(small));
    }

    [Fact]
    public void TestRectangleNotContainsIntersectingRectangle()
    {
        var big = new Rectangle(10, 10, 100, 100);
        var small = new Rectangle(30, 30, 300, 30);

        Assert.False(big.Contains(small));
    }

    [Fact]
    public void TestRectanglesAreEqual()
    {
        var r1 = new Rectangle(10, 10, 20, 30);
        var r2 = new Rectangle(10, 10, 20, 30);

        Assert.True(r1 == r2);
    }

    [Fact]
    public void TestRectanglesAreNotEqual()
    {
        var r1 = new Rectangle(10, 10, 20, 30);
        var r2 = new Rectangle(10, 10, 20, 40);

        Assert.True(r1 != r2);
    }

    [Fact]
    public void TestRectangleIntersectsRectangleLeft()
    {
        var rect1 = new Rectangle(100, 100, 100, 100);
        var rect2 = new Rectangle(90, 110, 20, 20);

        Assert.True(rect1.Intersects(rect2));
    }

    [Fact]
    public void TestRectangleIntersectsRectangleTopLeft()
    {
        var rect1 = new Rectangle(100, 100, 100, 100);
        var rect2 = new Rectangle(90, 90, 20, 20);

        Assert.True(rect1.Intersects(rect2));
    }

    [Fact]
    public void TestRectangleIntersectsRectangleTop()
    {
        var rect1 = new Rectangle(100, 100, 100, 100);
        var rect2 = new Rectangle(110, 90, 20, 20);

        Assert.True(rect1.Intersects(rect2));
    }

    [Fact]
    public void TestRectangleIntersectsRectangleTopRight()
    {
        var rect1 = new Rectangle(100, 100, 100, 100);
        var rect2 = new Rectangle(190, 90, 20, 20);

        Assert.True(rect1.Intersects(rect2));
    }

    [Fact]
    public void TestRectangleIntersectsRectangleRight()
    {
        var rect1 = new Rectangle(100, 100, 100, 100);
        var rect2 = new Rectangle(190, 110, 20, 20);

        Assert.True(rect1.Intersects(rect2));
    }

    [Fact]
    public void TestRectangleIntersectsRectangleBottomRight()
    {
        var rect1 = new Rectangle(100, 100, 100, 100);
        var rect2 = new Rectangle(190, 190, 20, 20);

        Assert.True(rect1.Intersects(rect2));
    }

    [Fact]
    public void TestRectangleIntersectsRectangleBottom()
    {
        var rect1 = new Rectangle(100, 100, 100, 100);
        var rect2 = new Rectangle(150, 190, 20, 20);

        Assert.True(rect1.Intersects(rect2));
    }

    [Fact]
    public void TestRectangleIntersectsRectangleBottomLeft()
    {
        var rect1 = new Rectangle(100, 100, 100, 100);
        var rect2 = new Rectangle(90, 190, 20, 20);

        Assert.True(rect1.Intersects(rect2));
    }

    [Fact]
    public void TestInflate()
    {
        var rect = new Rectangle(100, 100, 100, 100);
        rect.Inflate(10);

        Assert.Equal(95, rect.Left);
        Assert.Equal(95, rect.Top);
        Assert.Equal(110, rect.Width);
        Assert.Equal(110, rect.Height);
        Assert.Equal(205, rect.Right);
        Assert.Equal(205, rect.Bottom);
    }

    [Fact]
    public void TestDeflate()
    {
        var rect = new Rectangle(100, 100, 100, 100);
        rect.Inflate(-10);

        Assert.Equal(105, rect.Left);
        Assert.Equal(105, rect.Top);
        Assert.Equal(90, rect.Width);
        Assert.Equal(90, rect.Height);
        Assert.Equal(195, rect.Right);
        Assert.Equal(195, rect.Bottom);
    }

    [Fact]
    public void TestGetIntersectionOfIntersectingRectangles()
    {
        var rect1 = new Rectangle(100, 100, 100, 100);
        var rect2 = new Rectangle(110, 90, 20, 40);

        var intersection = rect1.IntersectionWith(rect2);

        Assert.False(intersection.IsEmpty);
        Assert.Equal(Math.Max(rect1.Left, rect2.Left), intersection.Left);
        Assert.Equal(Math.Max(rect1.Top, rect2.Top), intersection.Top);
        Assert.Equal(Math.Min(rect1.Right, rect2.Right), intersection.Right);
        Assert.Equal(Math.Min(rect1.Bottom, rect2.Bottom), intersection.Bottom);
    }

    [Fact]
    public void TestGetIntersectionOfNonIntersectingRectangles()
    {
        var rect1 = new Rectangle(10, 20, 30, 40);
        var rect2 = new Rectangle(100, 200, 300, 400);

        var intersection = rect1.IntersectionWith(rect2);

        Assert.True(intersection.IsEmpty);
    }

    [Fact]
    public void TestMoveRectangleByPoint()
    {
        var rect = new Rectangle(100, 100, 100, 100);
        var pt = new Point(10, 10);

        rect.Offset(pt);
        Assert.Equal(110, rect.Left);
        Assert.Equal(110, rect.Top);
    }

    [Fact]
    public void TestMoveRectangleByZero()
    {
        var rect = new Rectangle(100, 100, 100, 100);
        var pt = new Point(0, 0);

        rect.Offset(pt);
        Assert.Equal(100, rect.Left);
        Assert.Equal(100, rect.Top);
    }
}