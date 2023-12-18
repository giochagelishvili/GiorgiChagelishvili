using Generic_Practices.Generics;

namespace Generic_Practices
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //----------------//
            // Swap elements //
            //--------------//
            string[] stringArray = { "First", "Second", "Third" };

            Console.Write("Before swapping: ");

            foreach (string word in stringArray)
            {
                if (word == stringArray.Last())
                    Console.Write($"{word}\n");
                else
                    Console.Write($"{word}, ");
            }

            stringArray.SwapElements("First", "Second");

            Console.Write("After swapping: ");

            foreach (string word in stringArray)
            {
                if (word == stringArray.Last())
                    Console.Write($"{word}\n");
                else
                    Console.Write($"{word}, ");
            }

            //-------------------------//
            // Find max value element //
            //-----------------------//
            double[] doubleArray = { -20.2, 0.1, 2.3, -6, 20.2 };
            double maxValue = doubleArray.FindMax();

            Console.WriteLine($"Max value is: {maxValue}");

            //----------------//
            // Generic Queue //
            //---------------//
            GenericQueue<string> queue = new GenericQueue<string>();

            queue.Enqueue("First");
            queue.Enqueue("Second");
            queue.Enqueue("Third");
            queue.Enqueue("Fourth");
            queue.Enqueue("Fifth");
            queue.Enqueue("Sixth");

            Console.WriteLine($"Earliest element in queue: {queue.Peek()}");

            Console.WriteLine($"Dequeue element: {queue.Dequeue()}");

            Console.WriteLine($"Earliest element after dequeueing: {queue.Peek()}");

            Console.WriteLine($"Dequeue element: {queue.Dequeue()}");

            Console.WriteLine($"Earliest element after dequeueing: {queue.Peek()}");

            //----------------//
            // Generic Stack //
            //--------------//
            
            GenericStack<int> stack = new GenericStack<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);
            stack.Push(6);

            Console.WriteLine($"Last added element in stack: {stack.Peek()}");

            Console.WriteLine($"Pop element {stack.Pop()} from stack.");

            Console.WriteLine($"Last added element in stack after popping: {stack.Peek()}");

            Console.WriteLine($"Pop element {stack.Pop()} from stack.");

            Console.WriteLine($"Last added element in stack after popping: {stack.Peek()}");
        }
    }
}
