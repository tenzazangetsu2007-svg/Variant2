using DefaultNamespace;

namespace MatrixLogic.Tests;

public class ColumnCheckerTests
{
    [Fact]
    public void IsAllMultipleOf5Or7_EmptyColumn_ReturnsTrue()
    {
        var column = Array.Empty<int>();

        var result = ColumnChecker.IsAllMultipleOf5Or7(column);

        Assert.True(result);
    }

    [Theory]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(15)]
    [InlineData(0)]
    [InlineData(-5)]
    [InlineData(-10)]
    public void IsAllMultipleOf5Or7_MultiplesOf5_ReturnsTrue(int value)
    {
        var column = new[] { value };

        var result = ColumnChecker.IsAllMultipleOf5Or7(column);

        Assert.True(result);
    }

    [Theory]
    [InlineData(7)]
    [InlineData(14)]
    [InlineData(21)]
    [InlineData(-7)]
    [InlineData(-14)]
    public void IsAllMultipleOf5Or7_MultiplesOf7_ReturnsTrue(int value)
    {
        var column = new[] { value };

        var result = ColumnChecker.IsAllMultipleOf5Or7(column);

        Assert.True(result);
    }

    [Fact]
    public void IsAllMultipleOf5Or7_MixedMultiplesOf5And7_ReturnsTrue()
    {
        var column = new[] { 5, 7, 10, 14, 35, 0 };

        var result = ColumnChecker.IsAllMultipleOf5Or7(column);

        Assert.True(result);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(6)]
    [InlineData(8)]
    [InlineData(9)]
    [InlineData(11)]
    [InlineData(-1)]
    [InlineData(-3)]
    public void IsAllMultipleOf5Or7_NotMultipleOf5Or7_ReturnsFalse(int value)
    {
        var column = new[] { value };

        var result = ColumnChecker.IsAllMultipleOf5Or7(column);

        Assert.False(result);
    }

    [Fact]
    public void IsAllMultipleOf5Or7_OneInvalidAmongValid_ReturnsFalse()
    {
        var column = new[] { 5, 7, 10, 3, 14 };

        var result = ColumnChecker.IsAllMultipleOf5Or7(column);

        Assert.False(result);
    }

    [Fact]
    public void IsAllMultipleOf5Or7_MultipleOfBoth5And7_ReturnsTrue()
    {
        // 35 кратно и 5, и 7
        var column = new[] { 35, 70, -35 };

        var result = ColumnChecker.IsAllMultipleOf5Or7(column);

        Assert.True(result);
    }
}
