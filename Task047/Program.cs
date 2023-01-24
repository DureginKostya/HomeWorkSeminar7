/* Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.
m = 3, n = 4.
0,5 7 -2 -0,2
1 -3,3 8 -9,9
8 7,8 -7,1 9
*/
Console.Clear();
int GetDataFromUser(string msg)
{
    PrintInColor(msg, ConsoleColor.White);
    int number = int.Parse(Console.ReadLine()!); 
    return number;
}
void PrintInColor(string msg, ConsoleColor Color)
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
            matrix[i,j] = new Random().Next(-deviation, deviation) + Math.Round(new Random().NextDouble(), 2);
        }
    }
    return matrix;
}
void ShowMatrix(double[,] matrix)
{
    Console.Write("\t");
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        PrintInColor(j + "\t", ConsoleColor.DarkCyan);
    }
    Console.WriteLine();
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        PrintInColor(i + "\t", ConsoleColor.DarkCyan);
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            PrintInColor(matrix[i,j] + "\t", ConsoleColor.White);            
        }
        Console.WriteLine();
    }
}
int rowsLength = GetDataFromUser("Введите количество строк в матрице: ");
int columnsLength = GetDataFromUser("Введите количество столбцов в матрице: ");
double[,] randomMatrix = GetMatrixFromRandomNumbers(rowsLength, columnsLength, 15);
ShowMatrix(randomMatrix);