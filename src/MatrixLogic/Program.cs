using DefaultNamespace;

Console.Write("Введите количество строк N: ");
if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
{
    Console.WriteLine("Ошибка: N должно быть положительным целым числом.");
    return;
}

Console.Write("Введите количество столбцов M: ");
if (!int.TryParse(Console.ReadLine(), out int m) || m <= 0)
{
    Console.WriteLine("Ошибка: M должно быть положительным целым числом.");
    return;
}

var matrix = new int[n, m];
Console.WriteLine($"Введите элементы матрицы ({n}x{m}), по строкам:");

for (int i = 0; i < n; i++)
{
    Console.Write($"Строка {i + 1}: ");
    var parts = (Console.ReadLine() ?? "")
        .Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries);

    if (parts.Length != m)
    {
        Console.WriteLine($"Ошибка: ожидалось {m} чисел, получено {parts.Length}.");
        return;
    }

    for (int j = 0; j < m; j++)
    {
        if (!int.TryParse(parts[j], out matrix[i, j]))
        {
            Console.WriteLine($"Ошибка: «{parts[j]}» не является целым числом.");
            return;
        }
    }
}

Console.WriteLine();
Console.WriteLine("Матрица:");
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)
        Console.Write($"{matrix[i, j],6}");
    Console.WriteLine();
}

var columns = MatrixService.FindColumns(matrix);

Console.WriteLine();
if (columns.Count == 0)
    Console.WriteLine("Нет столбцов, в которых каждый элемент кратен 5 или 7.");
else
    Console.WriteLine("Номера столбцов (с 1), где каждый элемент кратен 5 или 7: "
                      + string.Join(", ", columns));
