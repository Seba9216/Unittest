namespace tests;
using System;
using System.IO;
using techmath;


// Simple Unit test, just to Demo simple Assert construction
public class DemoUnitTest
{
    readonly Stack<int> stack;

    public DemoUnitTest()
    {
        stack = new Stack<int>();
    }


    [Fact]
    public void TestAssertTrue()
    {
        Assert.True(1 == 1);
    }

    [Fact]
    public void TestAssertFalse()
    {
        Assert.False(1 == 0);
    }

    [Fact]
    public void TestAssertEqual()
    {
        String name = "Per";
        String lastname = "Madsen";

        String full = name + " " + lastname;
        Assert.Equal("Per Madsen", full);
    }

    [Fact]
    public void TestAssertNotNull()
    {
        String name = "Per";

        Assert.NotNull(name);
    }

    [Fact]
    public void TestAssertNull()
    {
        String? name = "Per";
        Assert.Equal("Per", name);

        name = null;

        Assert.Null(name);
    }

    [Fact]
    public void TestAddToStack()
    {
        stack.Push(1);
        Assert.Single(stack);
    }

    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(-4, -6, -10)]
    [InlineData(-2, 2, 0)]
    [InlineData(int.MinValue, -1, int.MaxValue)]
    public void CanAddTheory(int value1, int value2, int expected)
    {

        var result = value1 + value2;

        Assert.Equal(expected, result);
    }

    [Fact]
    public void TestPrintHello()
    {
        // arrange
        var writer = new StringWriter();
        Console.SetOut(writer);

        // act
        IO.PrintHello();

        // assert
        var output = writer.ToString();
        Assert.Equal("Hello" + Environment.NewLine, output);
    }
    [Fact]
    public void TestEchoInput()
    {
        // arrange
        var reader = new StringReader("Hello");
        var writer = new StringWriter();
        Console.SetIn(reader);
        Console.SetOut(writer);

        // act
        IO.EchoInput();

        // assert
        var output = writer.ToString();
        Assert.Equal("Hello" + Environment.NewLine, output);
    }

    [Fact]
    public void TestWaitForEscape()
    {
        // arrange
        var reader = new StringReader("" + ConsoleKey.Escape);
        var writer = new StringWriter();
        Console.SetIn(reader);
        Console.SetOut(writer);
        ConsoleKeyInfo ki = new ConsoleKeyInfo((char)ConsoleKey.Escape, ConsoleKey.Escape, false, false, false);

        ConsoleKeyInfo[] keys = { ki };
        IO.MyConsole.SetTestMode(keys);

        // act
        IO.WaitForEscape();

        // assert
        var output = writer.ToString();
        Assert.Equal("Escape pressed 1!" + Environment.NewLine, output);
    }
    [Fact]
    public void TestStringDoesthrowexectption()
    {
        var rectangle = new Rectangle(1, 2);
        
        Assert.Equal("techmath.Rectangle(1,2)", rectangle.ToString()); 
    }
    [Fact]
    public void TestRectanglePerimeter()
    {
        var rectangle = new Rectangle(1, 2);
        Assert.Equal(6, rectangle.Perimeter()); 
    }
    [Fact]
    public void TestRectangleArea() 
    {
        var rectangle = new Rectangle(1, 2);
        Assert.Equal(2, rectangle.Area());


    }
    [Fact]
    public void TestCirleArea()
    {
        var circle = new Circle(2);
        Assert.Equal(12.566370614359172953850573533118, circle.Area());

    }
    [Fact]
    public void TestCirlePerimeter()
    {
        var circle = new Circle(2);
        Assert.Equal(12.566370614359172953850573533118, circle.Perimeter());
    }
    [Fact]
    public void TestCirleTostring()
    {
        var circle = new Circle(2);
        Assert.Equal("techmath.Circle(2)", circle.ToString());
    }
    [Fact]
    public void TestFractionMinus()
    {
        var fraction1 = new Fraction(5,10);
        var fraction2 = new Fraction(3, 10);
        var result = fraction1.Minus(fraction2);
        Assert.Equal(new Fraction(2, 10), result);
    }
    [Fact]
    public void TestFractionMultiply()
    {
        var fraction1 = new Fraction(5, 10);
        var fraction2 = new Fraction(3, 10);
        var result = fraction1.Multiply(fraction2);
        Assert.Equal(new Fraction(3, 20), result);
    }

}