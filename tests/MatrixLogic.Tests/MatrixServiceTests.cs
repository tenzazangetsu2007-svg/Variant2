using DefaultNamespace;

namespace MatrixLogic.Tests;

public class MatrixServiceTests
{
    [Fact]
    public void FindColumns_AllColumnsSatisfy_ReturnsAllColumnNumbers()
    {
        // 2x3: все столбцы из кратных 5 или 7
        int[,] matrix =
        {
            { 5, 7, 10 },
            { 14, 35, 0 }
        };

        var result = MatrixService.FindColumns(matrix);

        Assert.Equal(new List<int> { 1, 2, 3 }, result);
    }

    [Fact]
    public void FindColumns_NoColumnsSatisfy_ReturnsEmptyList()
    {
        int[,] matrix =
        {
            { 1, 2, 3 },
            { 4, 6, 8 }
        };

        var result = MatrixService.FindColumns(matrix);

        Assert.Empty(result);
    }

    [Fact]
    public void FindColumns_SomeColumnsSatisfy_ReturnsOnlyMatchingNumbers()
    {
        // столбец 1: 5, 10 — ок
        // столбец 2: 1, 2 — нет
        // столбец 3: 7, 14 — ок
        int[,] matrix =
        {
            { 5, 1, 7 },
            { 10, 2, 14 }
        };

        var result = MatrixService.FindColumns(matrix);

        Assert.Equal(new List<int> { 1, 3 }, result);
    }

    [Fact]
    public void FindColumns_SingleColumnSatisfies_ReturnsOne()
    {
        int[,] matrix =
        {
            { 5 },
            { 7 },
            { 35 }
        };

        var result = MatrixService.FindColumns(matrix);

        Assert.Equal(new List<int> { 1 }, result);
    }

    [Fact]
    public void FindColumns_SingleColumnDoesNotSatisfy_ReturnsEmpty()
    {
        int[,] matrix =
        {
            { 5 },
            { 3 }
        };

        var result = MatrixService.FindColumns(matrix);

        Assert.Empty(result);
    }

    [Fact]
    public void FindColumns_SingleRow_ChecksEachElementAsColumn()
    {
        // одна строка: каждый элемент — отдельный столбец из одного числа
        int[,] matrix =
        {
            { 5, 3, 7, 11 }
        };

        var result = MatrixService.FindColumns(matrix);

        Assert.Equal(new List<int> { 1, 3 }, result);
    }

    [Fact]
    public void FindColumns_ColumnNumbersAreOneBased()
    {
        // только второй столбец (индекс 1) подходит → номер 2
        int[,] matrix =
        {
            { 1, 5, 2 },
            { 3, 10, 4 }
        };

        var result = MatrixService.FindColumns(matrix);

        Assert.Equal(new List<int> { 2 }, result);
    }

    [Fact]
    public void FindColumns_NegativeAndZeroValues_HandledCorrectly()
    {
        int[,] matrix =
        {
            { 0, -5, -3 },
            { -7, -10, 1 }
        };

        var result = MatrixService.FindColumns(matrix);

        Assert.Equal(new List<int> { 1, 2 }, result);
    }

    [Fact]
    public void FindColumns_ResultOrderIsLeftToRight()
    {
        int[,] matrix =
        {
            { 5, 1, 7, 2, 10 },
            { 10, 3, 14, 4, 35 }
        };

        var result = MatrixService.FindColumns(matrix);

        Assert.Equal(new List<int> { 1, 3, 5 }, result);
    }
}
