using System;

namespace NET_lab01
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrixSize = getMatrixSize_input();
            if (matrixSize == -1)
            {
                return;
            }
            Random random = new Random();
            int[,] intArray2D = new int[matrixSize, matrixSize];

            // Add random numbers to matrix
            for (int i = 0; i < matrixSize; i += 1)
            {
                for (int y = 0; y < matrixSize; y += 1)
                {
                    intArray2D[i, y] = random.Next(1, 10);
                }
            }

            Program.print2DArray(intArray2D, matrixSize);

            // Change first columng with the last one
            var lastElementIndex = matrixSize - 1;
            for (int i = 0; i < matrixSize; i += 1)
            {
                var temp = intArray2D[i, 0];
                intArray2D[i, 0] = intArray2D[i, lastElementIndex];
                intArray2D[i, lastElementIndex] = temp;
            }
            Program.print2DArray(intArray2D, matrixSize);
        }

        static void print2DArray(int[,] array2D, int size)
        {
            Console.WriteLine("");
            for (int i = 0; i < size; i += 1)
            {
                for (int y = 0; y < size; y += 1)
                {
                    Console.Write(array2D[i, y]);
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");
        }

        static int getMatrixSize_input()
        {
            int numVal = -1;
            bool repeat = true;

            while (repeat)
            {
                Console.Write("Enter a number between −2,147,483,648 and +2,147,483,647 (inclusive): ");

                string input = Console.ReadLine();

                // ToInt32 can throw FormatException or OverflowException.
                try
                {
                    numVal = Convert.ToInt32(input);
                    if (numVal < Int32.MaxValue)
                    {
                        Console.WriteLine("The new value is {0}", ++numVal);
                        repeat = false;
                    }
                    else
                    {
                        Console.WriteLine("numVal cannot be incremented beyond its current value");
                        goAgain(ref repeat);
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Input string is not a sequence of digits.");
                    goAgain(ref repeat);
                }
                catch (OverflowException)
                {
                    Console.WriteLine("The number cannot fit in an Int32.");
                    goAgain(ref repeat);
                }


            }
            return numVal;
        }
        static void goAgain(ref bool flag)
        {
            Console.Write("Go again? Y/N: ");
            string go = Console.ReadLine();
            if (go.ToUpper() != "Y")
            {
                flag = false;
            }
        }
    }
}
