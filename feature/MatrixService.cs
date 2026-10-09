namespace DefaultNamespace;

public class MatrixService
{
    /// Возвращает номера (с 1) столбцов, удовлетворяющих условию.
    public static List<int> FindColumns(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        var result = new List<int>();

        for (int j = 0; j < cols; j++)
        {
            var column = new int[rows];
            for (int i = 0; i < rows; i++)
                column[i] = matrix[i, j];

            if (ColumnChecker.IsAllMultipleOf5Or7(column))
                result.Add(j + 1);
        }
        return result;
    }
}