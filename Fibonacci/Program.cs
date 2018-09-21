using System;
using System.Collections.Generic;
using System.Linq;

namespace FibonacciIterative
{
    class Program
    {
        static int FibonacciNumber(int position)
        {
            int a = 1; int b = 1;
            while (position > 1)
            {
                int temp = a;
                a = b;
                b = b + temp;
                position--;
            }
            
            return a;
        }

        static IEnumerable<int> Fibonacci()
        {
            int a = 0; int b = 1;
            while(true)
            {
                int temp = a;
                a = b;
                b = b + temp;

                yield return a;
            }
        }

        static void Main(string[] args)
        {
            foreach(int n in Fibonacci().Take(20))
                Console.Write(n + " ");

            Console.WriteLine();

            int position = 10;

            Console.Write("Элемент на позиции " + position + " в последовательности Фиобначчи равен: " + FibonacciNumber(position));

            Console.ReadKey();
        }
    }
}
