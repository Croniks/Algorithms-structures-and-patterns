using System;
using System.Collections.Generic;
using System.Linq;


namespace FibonacciRecursive
{
    class Program
    {
        static int FibonacciNumber(int position)
        {
            if(position == 1 || position == 2)
                return 1;

            return FibonacciNumber(position - 1) + FibonacciNumber(position - 2);
        }

        static IEnumerable<int> Fibonacci()
        {
            int a = 0; int b = 1;
            while (true)
            {
                int temp = a;
                a = b;
                b = b + temp;

                yield return a;
            }
        }

        static void Main(string[] args)
        {
            foreach (int n in Fibonacci().Take(20))
                Console.Write(n + " ");

            Console.WriteLine();

            int position = 10;

            Console.Write("Элемент на позиции " + position + " в последовательности Фиобначчи равен: " + FibonacciNumber(position));

            Console.ReadKey();
        }
    }
}
