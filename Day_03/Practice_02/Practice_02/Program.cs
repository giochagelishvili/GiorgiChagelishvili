Console.WriteLine("Enter first number: ");
int firstSideLength;
bool firstSideInput = int.TryParse(Console.ReadLine(), out firstSideLength);

Console.WriteLine("Enter second number: ");
int secondSideLength;
bool secondSideInput = int.TryParse(Console.ReadLine(), out secondSideLength);

Console.WriteLine("Enter third number: ");
int thirdSideLength;
bool thirdSideInput = int.TryParse(Console.ReadLine(), out thirdSideLength);

if (firstSideInput == true && secondSideInput == true && thirdSideInput == true)
{
    validTriangle(firstSideLength, secondSideLength, thirdSideLength);
}

Console.ReadKey();

/* 
* Check sides according to Triangle Inequality Theorem, 
* which states that the sum of two side lengths of a 
* triangle is always greater than the third side.
*/
static void validTriangle(int firstSide, int secondSide, int thirdSide)
{
    if (
        (firstSide + secondSide) > thirdSide &&
        (firstSide + thirdSide) > secondSide &&
        (secondSide + thirdSide) > firstSide
       )
    {
        Console.WriteLine("This should be a triangle !");
    }
}