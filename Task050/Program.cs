/*Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, 
и возвращает значение этого элемента или же указание, что такого элемента нет.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
1 7 -> такого числа в массиве нет*/
Console.Clear();
int GetDataFromUser(string msg, string value)
{
    ColorizeText(msg, ConsoleColor.DarkBlue);
    int variable = -1;
    if (int.TryParse(Console.ReadLine()!, out variable) && variable >= 0)
        return variable;
    else
    {
        ColorizeText("Введено недопустимое значение", ConsoleColor.DarkRed);
        Console.WriteLine();
        return variable = GetDataFromUser($"Введите повторно номер {value} (число должно быть целочисленным и не меньше нуля): ", value);
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
void OutputOfElement(int[,] matrix, int userRow, int userColumn)
{
    if (userRow < matrix.GetLength(0) && userColumn < matrix.GetLength(1))
        ColorizeText($"Элемент матрицы: matrix[{userRow},{userColumn}] = {matrix[userRow,userColumn]}", ConsoleColor.DarkGreen);
    else
        ColorizeText($"Элемент матрицы: matrix[{userRow},{userColumn}] - такого элемента в матрице нет", ConsoleColor.DarkRed);
    Console.WriteLine();
}
ColorizeText("<<<<< НУМЕРАЦИЯ СТРОК И СТОЛБЦОВ В МАТРИЦЕ НАЧИНАЕТСЯ С НУЛЕЙ!!! >>>>>", ConsoleColor.Magenta);
Console.WriteLine();
int numberRow = GetDataFromUser("Номер строки: ", "строки");
int numberColumn = GetDataFromUser("Номер столбца: ", "столбца");
int[,] randomMatrix = GetRandomMatrixAndPrint(6, 4, 20);
OutputOfElement(randomMatrix, numberRow, numberColumn);