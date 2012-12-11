/*
 * Trailing zero of number!
*/

using System;

namespace Problem13TrailingZeroes
{
    class Program
    {
        static int GetTrailingZeroes(int n)
        {
            int counter = 0;

            while (n != 0)
            {
                n /= 5;
                counter += n;
            }

            return counter;
        }
        static void Main(string[] args)
        {
            Console.Write("Enter n = ");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("The trailing zeroes of {0}! is {1}", n, GetTrailingZeroes(n));
        }
    }
}
