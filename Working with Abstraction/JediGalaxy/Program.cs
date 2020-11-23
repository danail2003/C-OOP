using System;
using System.Linq;

namespace JediGalaxy
{
    class Program
    {
        static void Main()
        {
            int[] dimestions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int row = dimestions[0];
            int column = dimestions[1];

            int[,] matrix = new int[row, column];
            MatrixFilling(matrix, row, column);

            string command = Console.ReadLine();
            long sum = 0;

            while (command != "Let the Force be with you")
            {
                int[] ivoCoordinates = command.Split(" " , StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int[] evilCoordinates = Console.ReadLine().Split(" " , StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int evilRow = evilCoordinates[0];
                int evilColumn = evilCoordinates[1];

                CollectingStarsOfEvil(matrix, evilRow, evilColumn);

                int ivoRow = ivoCoordinates[0];
                int ivoColumn = ivoCoordinates[1];

                while (ivoRow >= 0 && ivoColumn < matrix.GetLength(1))
                {
                    if (ivoRow >= 0 && ivoRow < matrix.GetLength(0) && ivoColumn >= 0 && ivoColumn < matrix.GetLength(1))
                    {
                        sum += matrix[ivoRow, ivoColumn];
                    }

                    ivoColumn++;
                    ivoRow--;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(sum);
        }

        public static int[,] MatrixFilling(int[,] matrix ,int row, int column)
        {
            int value = 0;

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    matrix[i, j] = value++;
                }
            }

            return matrix;
        }

        public static void CollectingStarsOfEvil(int[,] matrix, int evilRow, int evilColumn)
        {
            while (evilRow >= 0 && evilColumn >= 0)
            {
                if (evilRow >= 0 && evilRow < matrix.GetLength(0) && evilColumn >= 0 && evilColumn < matrix.GetLength(1))
                {
                    matrix[evilRow, evilColumn] = 0;
                }

                evilRow--;
                evilColumn--;
            }
        }
    }
}
