Console.WriteLine("Enter first number: ");
var firstInput = Console.ReadLine();
int firstNum; // First side length

Console.WriteLine("Enter second number: ");
var secondInput = Console.ReadLine();
int secondNum; // Second side length

Console.WriteLine("Enter third number: ");
var thirdInput = Console.ReadLine();
int thirdNum; // Third side length

if (
    int.TryParse(firstInput, out firstNum) == true &&
    int.TryParse(secondInput, out secondNum) == true &&
    int.TryParse(thirdInput, out thirdNum) == true
   )
{
    /* 
     * Check sides according to Triangle Inequality Theorem, 
     * which states that the sum of two side lengths of a 
     * triangle is always greater than the third side.
    */
    if (
        (firstNum + secondNum) > thirdNum &&
        (firstNum + thirdNum) > secondNum &&
        (secondNum + thirdNum) > firstNum
       )
    {
        Console.WriteLine("This should be a triangle !");
    }
}