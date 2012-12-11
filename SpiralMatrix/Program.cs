/*
 * Generating spiral matrix.
 */

using System;

namespace Problem14SpiralMatrix
{
    class Program
    {
        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0, 5}", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        static void FillSpiralMatrix(int[,] matrix)
        {
            int counter = 1;
            int matrixSize = matrix.GetLength(0) * matrix.GetLength(1);
            int row = 0, col = 0;
            bool decCol = false, decRow = false;
            int step = matrix.GetLength(0);
            bool changeStep = true;
            int it = 0;

            while (true)
            {
                if (!decCol)
                {
                    while (it < step)
                    {
                        matrix[row, col] = counter;
                        col++;
                        counter++;
                        it++;
                    }
                    col--;
                    row++;
                    it = 0;
                    decCol = true;
                    if (changeStep)
                    {
                        changeStep = false;
                        step -= 1;
                    }
                    else
                        changeStep = true;
                    if (counter == matrixSize)
                    {
                        matrix[row, col] = counter;
                        return;
                    }
                }
                if (!decRow)
                {
                    while (it < step)
                    {
                        matrix[row, col] = counter;
                        row++;
                        counter++;
                        it++;
                    }
                    row--;
                    col--;
                    it = 0;
                    decRow = true;
                    if (changeStep)
                    {
                        changeStep = false;
                        step -= 1;
                    }
                    else
                        changeStep = true;
                    if (counter == matrixSize)
                    {
                        matrix[row, col] = counter;
                        return;
                    }
                }

                if (decCol)
                {
                    while (it < step)
                    {
                        matrix[row, col] = counter;
                        col--;
                        counter++;
                        it++;
                    }
                    col++;
                    row--;
                    it = 0;
                    decCol = false;
                    if (changeStep)
                    {
                        changeStep = false;
                        step -= 1;
                    }
                    else
                        changeStep = true;
                    if (counter == matrixSize)
                    {
                        matrix[row, col] = counter;
                        return;
                    }
                }

                if (decRow)
                {
                    while (it < step)
                    {
                        matrix[row, col] = counter;
                        row--;
                        counter++;
                        it++;
                    }
                    row++;
                    col++;
                    it = 0;
                    decRow = false;
                    if (changeStep)
                    {
                        changeStep = false;
                        step -= 1;
                    }
                    else
                        changeStep = true;
                    if (counter == matrixSize)
                    {
                        matrix[row, col] = counter;
                        return;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Enter n = ");
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            FillSpiralMatrix(matrix);
            PrintMatrix(matrix);
        }
    }
}
