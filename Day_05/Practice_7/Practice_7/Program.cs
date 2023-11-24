Console.Write("Enter array row size: ");
int rows;
bool rowsInput = int.TryParse(Console.ReadLine(), out rows);

Console.Write("Enter array column size: ");
int columns;
bool columnsInput = int.TryParse(Console.ReadLine(), out columns);

if (rowsInput == false || columnsInput == false || rows <= 0 || columns <= 0)
    return;

int[,] firstMatrix = new int[rows, columns];
int[,] secondMatrix = new int[rows, columns];

Console.WriteLine("Fill first matrix: ");

for (int i = 0; i < rows; i++)
{
    for (int j = 0; j < columns; j++)
    {
        Console.Write($"Enter number for index {i},{j}: ");

        int num;
        bool numInput = int.TryParse(Console.ReadLine(), out num);

        if (numInput == false)
            return;

        firstMatrix[i, j] = num;
    }
}

Console.WriteLine("Fill second matrix: ");

for (int i = 0; i < rows; i++)
{
    for (int j = 0; j < columns; j++)
    {
        Console.Write($"Enter number for index {i},{j}: ");

        int num;
        bool numInput = int.TryParse(Console.ReadLine(), out num);

        if (numInput == false)
            return;

        secondMatrix[i, j] = num;
    }
}

int[,] matrixSum = new int[rows, columns];

for (int i = 0; i < rows; i++)
{
    for (int j = 0; j < columns; j++)
    {
        matrixSum[i, j] = firstMatrix[i, j] + secondMatrix[i, j];

        if (j != columns - 1)
            Console.Write($"{matrixSum[i, j]}, ");
        else
            Console.Write(matrixSum[i, j]);
    }
    Console.WriteLine();
}

Console.ReadKey();