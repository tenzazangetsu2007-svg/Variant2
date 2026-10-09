namespace DefaultNamespace;

public class ColumnChecker
{
    /// Процедура проверки: получает все элементы столбца,
    /// true — если каждый элемент кратен 5 или 7.
    public static bool IsAllMultipleOf5Or7(int[] column)
    {
        foreach (int x in column)
            if (x % 5 != 0 && x % 7 != 0)
                return false;
        return true;
    }
}
