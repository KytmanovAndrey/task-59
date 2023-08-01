// Задача 59: Задайте двумерный массив из целых чисел. Напишите программу, которая удалит строку и столбец, на пересечении которых расположен наименьший элемент массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Наименьший элемент - 1, на выходе получим 
// следующий массив:
// 9 4 2
// 2 2 6
// 3 4 7


int[,] DeleteMinRowAndColumn(int[,] array, int iMin, int jMin, int minElement)
{
    int k = 0, l = 0;
    int [,] newArray = new int[array.GetLength(0)-1, array.GetLength(1)-1];
    for (int i = 0; i < newArray.GetLength(0); i++)
    {
        for (int j = 0; j < newArray.GetLength(1); j++)
        {
            if (i == iMin) k = i + 1;
            if (j == jMin) l = j + 1;
            newArray[i, j] = array[k, l];
            l++;
        }
        k++;
        l = 0;
    }
    if (FindCountMinIndex(newArray, iMin, jMin, minElement)) return DeleteMinRowAndColumn(newArray, iMin, jMin, minElement);
    else return newArray;
}

bool FindCountMinIndex(int[,] array, int iMin, int jMin, int minElement)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (array[i, j] == minElement) return true;
        }
    }
    return false;
}

void FindMinIndex(int[,] array, out int minI, out int minJ, out int minElemen)
{
    int min = array[0, 0];
    minI = 0;
    minJ = 0;
    minElemen = 0;


    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (array[i, j] <= min)
            {
                min = array[i, j];
                minI = i;
                minJ = j;

            }
        }
    }
    minElemen = array[minI, minJ];
}

void Print2DArray(int[,] newArray)
{
    Console.WriteLine("Новый массив выглядит так:");
    for (int i = 0; i < newArray.GetLength(0); i++)
    {
        for (int j = 0; j < newArray.GetLength(1); j++)
        {
            Console.Write($"{newArray[i, j]}\t");
        }
        Console.WriteLine();
    }
}

int[,] Create2DArray(int rows, int columns)
{
    int[,] array = new int[rows, columns];
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            array[i, j] = new Random().Next(1, 5);
            Console.Write($"{array[i, j]}\t");
        }
        Console.WriteLine();
    }
    return array;
}

int GetInput(string text)
{
    Console.Write(text);
    return Convert.ToInt32(Console.ReadLine());
}

int rows = GetInput("Введите число строк: ");
int columns = GetInput("Введите число столбцов: ");
int[,] array = Create2DArray(rows, columns);
int iMin;
int jMin;
int minElement = 0;
FindMinIndex(array, out iMin, out jMin, out minElement);
int[,] newArray = DeleteMinRowAndColumn(array, iMin, jMin, minElement);
Print2DArray(newArray);