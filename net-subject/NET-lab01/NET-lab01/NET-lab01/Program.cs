using System;

namespace NET_lab01
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrixSize = 5;
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
    }
}
