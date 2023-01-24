/*Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3.
*/
Console.Clear();
int GetDataFromUser(string msg, string value)
{
    ColorizeText(msg, ConsoleColor.White);
    int variable = 0;
    if (int.TryParse(Console.ReadLine()!, out variable) && variable > 0)
        return variable;
    else
    {
        ColorizeText("Введено недопустимое значение", ConsoleColor.DarkRed);
        Console.WriteLine();
        return variable = GetDataFromUser($"Введите повторно количество {value} (число должно быть целочисленным и больше нуля): ", value);
    }
}
void ColorizeText(string msg, ConsoleColor Color)
{
    Console.ForegroundColor = Color;
    Console.Write(msg);
    Console.ResetColor();
}
int[,] GetRandomMatrixAndPrint(int rows, int columns, int deviation)
{
    Console.Write("\t");
    for (int j = 0; j < columns; j++)
    {
        ColorizeText($" #{j}" + "\t", ConsoleColor.DarkYellow);
    }
    Console.WriteLine();
    int[,] matrix = new int[rows,columns];
    for (int i = 0; i < rows; i++)
    {
        ColorizeText($"#{i}" + "\t", ConsoleColor.DarkYellow);
        for (int j = 0; j < columns; j++)
        {
            matrix[i,j] = new Random().Next(-deviation, deviation + 1);
            if (matrix[i,j] < 0)
                ColorizeText(matrix[i,j] + "\t", ConsoleColor.White);
            else                
                ColorizeText($" {matrix[i,j]}" + "\t", ConsoleColor.White);
        }
        Console.WriteLine();
    }
    Console.WriteLine();
    return matrix;
}
double[] GetSumOfElementsOfColumn(int[,] matrix)
{
    double[] array = new double[matrix.GetLength(1)];
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        int sum = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            sum += matrix[i,j];
        }
        array[j] = Math.Round(sum / (double)matrix.GetLength(0), 2);
    }
    return array;
}
void ShowResult(double[] array)
{
    ColorizeText("Среднее арифметическое элементов в каждом столбце:", ConsoleColor.DarkGreen);
    Console.WriteLine();
    ColorizeText("\t", ConsoleColor.DarkYellow);
    for (int i = 0; i < array.Length; i++)
    {
        ColorizeText($"#{i}" + "\t", ConsoleColor.DarkYellow);
    }
    Console.WriteLine();
    Console.Write("\t");
    for (int i = 0; i < array.Length; i++)
    {
        ColorizeText($"{array[i]}"+"\t", ConsoleColor.White);
    }
    Console.WriteLine();
}
ColorizeText("Введите размерность матрицы", ConsoleColor.DarkBlue);
Console.WriteLine();
int numberRow = GetDataFromUser("Количество строк: ", "строк");
int numberColumn = GetDataFromUser("Количество столбцов: ", "столбцов");
int[,] randomMatrix = GetRandomMatrixAndPrint(numberRow, numberColumn, 20);
double[] arraySum = GetSumOfElementsOfColumn(randomMatrix);
ShowResult(arraySum);