namespace DefaultNamespace;

public class MatrixGenerator
{
    private static readonly Random Rnd = new();

    /// Случайная матрица натуральных чисел 1..max.
    public static int[,] Generate(int rows, int cols, int max = 50)
    {
        var m = new int[rows, cols];
        for (int i = 0; i < rows; i++)
        for (int j = 0; j < cols; j++)
            m[i, j] = Rnd.Next(1, max + 1);
        return m;
    }
}