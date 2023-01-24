/* Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.
m = 3, n = 4.
0,5 7 -2 -0,2
1 -3,3 8 -9,9
8 7,8 -7,1 9
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
double[,] GetMatrixFromRandomNumbers(int rows, int columns, int deviation)
{
    double[,] matrix = new double[rows,columns];
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            matrix[i,j] = Math.Round(new Random().Next(-deviation, deviation) + new Random().NextDouble(), 2);
        }
    }
    return matrix;
}
void ShowMatrix(double[,] matrix)
{
    Console.Write("\t");
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        ColorizeText($"  #{j}" + "\t", ConsoleColor.DarkCyan);
    }
    Console.WriteLine();
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        ColorizeText($"#{i}" + "\t", ConsoleColor.DarkCyan);
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[i,j] < 0)
                ColorizeText($" {matrix[i,j]}" + "\t", ConsoleColor.White);    
            else
                ColorizeText($"  {matrix[i,j]}" + "\t", ConsoleColor.White); 
        }
        Console.WriteLine();
    }
}
int rowsLength = GetDataFromUser("Введите количество строк в матрице: ", "строк");
int columnsLength = GetDataFromUser("Введите количество столбцов в матрице: ", "столбцов");
double[,] randomMatrix = GetMatrixFromRandomNumbers(rowsLength, columnsLength, 20);
ShowMatrix(randomMatrix);