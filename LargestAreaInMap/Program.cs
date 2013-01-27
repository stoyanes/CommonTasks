using System;
using System.Collections.Generic;
using System.Linq;


namespace LargestAreaInMap
{

    struct Coords
    {
        public int i;
        public int j;

        public Coords(int x, int y)
        {
            i = x;
            j = y;
        }
    }
    class Program
    {

        public static bool IsInBoundary(int[,] matr, int i, int j)
        {
            if (matr.Length != 0)
            {
                int row = matr.GetLength(0);
                int col = matr.GetLength(1);
                if (i < 0 || j < 0 || i >= row || j >= col)
                    return false;
                else
                    return true;
            }
            return false;
        }

        public static int AreaCounter(int[,] matrix, bool[,] visited, int item, int i, int j)
        {
            Queue<Coords> queue = new Queue<Coords>();
            queue.Enqueue(new Coords(i, j));
            visited[queue.Peek().i, queue.Peek().j] = true;
            Coords currentCell = new Coords();
            int counter = 0;

            while (queue.Count != 0)
            {
                currentCell = queue.Dequeue();
                counter++;
                if (IsInBoundary(matrix, currentCell.i + 1, currentCell.j + 1) && !visited[currentCell.i + 1, currentCell.j + 1])
                {
                    if (matrix[currentCell.i + 1, currentCell.j + 1] == item)
                    {
                        queue.Enqueue(new Coords(currentCell.i + 1, currentCell.j + 1));
                        visited[currentCell.i + 1, currentCell.j + 1] = true;
                    }
                    else
                        visited[currentCell.i + 1, currentCell.j + 1] = true;
                }
                /*------------------------------------------------*/
                if (IsInBoundary(matrix, currentCell.i + 1, currentCell.j) && !visited[currentCell.i + 1, currentCell.j])
                {
                    if (matrix[currentCell.i + 1, currentCell.j] == item)
                    {
                        queue.Enqueue(new Coords(currentCell.i + 1, currentCell.j));
                        visited[currentCell.i + 1, currentCell.j] = true;
                    }
                    else
                        visited[currentCell.i + 1, currentCell.j] = true;
                }
                /*------------------------------------------------*/
                if (IsInBoundary(matrix, currentCell.i + 1, currentCell.j - 1) && !visited[currentCell.i + 1, currentCell.j - 1])
                {
                    if (matrix[currentCell.i + 1, currentCell.j - 1] == item)
                    {
                        queue.Enqueue(new Coords(currentCell.i + 1, currentCell.j - 1));
                        visited[currentCell.i + 1, currentCell.j - 1] = true;
                    }
                    else
                        visited[currentCell.i + 1, currentCell.j - 1] = true;
                }
                /*------------------------------------------------*/
                if (IsInBoundary(matrix, currentCell.i, currentCell.j + 1) && !visited[currentCell.i, currentCell.j + 1])
                {
                    if (matrix[currentCell.i, currentCell.j + 1] == item)
                    {
                        queue.Enqueue(new Coords(currentCell.i, currentCell.j + 1));
                        visited[currentCell.i, currentCell.j + 1] = true;
                    }
                    else
                        visited[currentCell.i, currentCell.j + 1] = true;
                }
                /*------------------------------------------------*/
                if (IsInBoundary(matrix, currentCell.i + 1, currentCell.j - 1) && !visited[currentCell.i + 1, currentCell.j - 1])
                {
                    if (matrix[currentCell.i + 1, currentCell.j - 1] == item)
                    {
                        queue.Enqueue(new Coords(currentCell.i + 1, currentCell.j - 1));
                        visited[currentCell.i + 1, currentCell.j - 1] = true;
                    }
                    else
                        visited[currentCell.i + 1, currentCell.j - 1] = true;
                }
                /*------------------------------------------------*/
                if (IsInBoundary(matrix, currentCell.i - 1, currentCell.j + 1) && !visited[currentCell.i - 1, currentCell.j + 1])
                {
                    if (matrix[currentCell.i - 1, currentCell.j + 1] == item)
                    {
                        queue.Enqueue(new Coords(currentCell.i - 1, currentCell.j + 1));
                        visited[currentCell.i - 1, currentCell.j + 1] = true;
                    }
                    else
                        visited[currentCell.i - 1, currentCell.j + 1] = true;
                }
                /*------------------------------------------------*/
                if (IsInBoundary(matrix, currentCell.i - 1, currentCell.j) && !visited[currentCell.i - 1, currentCell.j])
                {
                    if (matrix[currentCell.i - 1, currentCell.j] == item)
                    {
                        queue.Enqueue(new Coords(currentCell.i - 1, currentCell.j));
                        visited[currentCell.i - 1, currentCell.j] = true;
                    }
                    else
                        visited[currentCell.i - 1, currentCell.j] = true;
                }
                /*------------------------------------------------*/
                if (IsInBoundary(matrix, currentCell.i - 1, currentCell.j - 1) && !visited[currentCell.i - 1, currentCell.j - 1])
                {
                    if (matrix[currentCell.i - 1, currentCell.j - 1] == item)
                    {
                        queue.Enqueue(new Coords(currentCell.i - 1, currentCell.j - 1));
                        visited[currentCell.i - 1, currentCell.j - 1] = true;
                    }
                    else
                        visited[currentCell.i - 1, currentCell.j - 1] = true;
                }
            }
            return counter - 1;

        }


        public static void MakeFalse(bool[,] arr)
        {
            if (arr.Length != 0)
            {
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        arr[i, j] = false;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            int[,] matrix = 
            {
                 {1,3,1,1,8,9},
                 {2,1,3,1,1,7},
                 {2,1,6,2,3,1},
                 {3,4,5,10,1,1}
            };

            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);
            bool[,] visited = new bool[row, col];
            bool[,] tmpVisited = new bool[row, col];


            int tmpMax = 0;
            int max = 0;
            int item = matrix[0, 0];
            tmpVisited[0, 0] = true;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    tmpMax = AreaCounter(matrix, visited, item, i, j);

                    if (tmpMax > max)
                    {
                        max = tmpMax;
                        item = matrix[i, j];
                    }
                    item = matrix[i, j];
                    MakeFalse(visited);
                }
            }

            Console.WriteLine(max);
        }
    }
}
