Console.Write("Enter count of rows: ");
int rows;
bool rowsInput = int.TryParse(Console.ReadLine(), out rows);

Console.Write("Enter count of columns: ");
int columns;
bool columnsInput = int.TryParse(Console.ReadLine(), out columns);

if (rowsInput == false || columnsInput == false || rows <= 0 || columns <= 0)
    return;

Console.WriteLine("===================================");

int[,] firstArray = create2DArray(rows, columns);

Console.WriteLine("===================================");

int[,] secondArray = create2DArray(rows, columns);

if (firstArray == null || secondArray == null) 
    return;

Console.WriteLine("===================================");

int[,] sumOfMatrices = addMatrices(firstArray, secondArray);

printMatrix(sumOfMatrices);

// METHODS ~ METHODS ~ METHODS ~ METHODS ~ METHODS ~ METHODS ~ METHODS ~ METHODS ~ METHODS ~ METHODS ~ METHODS ~ METHODS
// METHODS ~ METHODS ~ METHODS ~ METHODS ~ METHODS ~ METHODS ~ METHODS ~ METHODS ~ METHODS ~ METHODS ~ METHODS ~ METHODS
void printMatrix(int[,] matrix)
{
    Console.WriteLine("Here is the sum of matrices:");

    int rows = matrix.GetLength(0);
    int columns = matrix.GetLength(1);

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            Console.Write(matrix[i, j] + ", ");
        }
        Console.WriteLine();
    }
}
int[,] addMatrices(int[,] firstMatrix, int[,] secondMatrix)
{
    int rows = firstMatrix.GetLength(0);
    int columns = firstMatrix.GetLength(1);

    int[,] sumOfMatrices = new int[rows, columns];

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            sumOfMatrices[i, j] = firstMatrix[i, j] + secondMatrix[i, j];
        }
    }

    return sumOfMatrices;
}
int[,] create2DArray(int rows, int columns)
{
    int[,] numArray = new int[rows, columns];

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            Console.Write($"Enter integer for index {i},{j}: ");

            int num;
            bool numInput = int.TryParse(Console.ReadLine(), out num);

            if (numInput == false)
                return null;

            numArray[i, j] = num;
        }
    }

    return numArray;
}