Console.Write("Enter array row size: ");
int rows;
bool rowInput = int.TryParse(Console.ReadLine(), out rows);

Console.Write("Enter array column size: ");
int columns;
bool columnInput = int.TryParse(Console.ReadLine(), out columns);

if (rowInput == false || columnInput == false || rows <= 0 || columns <= 0)
    return;

int[,] numArray =  new int[rows, columns];

for (int i = 0; i < rows; i++)
{
    for (int j = 0; j < columns; j++)
    {
        Console.Write($"Enter number for index {i},{j}: ");

        int num;
        bool numInput = int.TryParse(Console.ReadLine(), out num);

        if (numInput == false)
            return;

        numArray[i, j] = num;
    }
}

Console.WriteLine("Here is matrix view of multidimensional array: ");

for (int i = 0; i < rows; i++)
{
    for (int j = 0; j < columns; j++)
    {
        int currentNum = numArray[i, j];
        Console.Write($"{currentNum}, ");
    }
    Console.WriteLine();
}

Console.ReadKey();