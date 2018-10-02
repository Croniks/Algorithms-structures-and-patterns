using System;
using System.Collections.Generic;
using System.Linq;

namespace FibonacciIterative
{
    class Program
    {
        static int FibonacciNumber(int position)
        {
            int a = 0; int b = 1;
            while (position > 0)
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
                yield return a;

                int temp = a;
                a = b;
                b = b + temp;
            }
        }

        static void Main(string[] args)
        {
            foreach(int n in Fibonacci().Take(20))
                Console.Write(n + " ");

            Console.WriteLine();

            int position1 = 0;
            int position2 = 1;
            int position3 = 2;
            int position4 = 3;

            Console.WriteLine("Элемент на позиции " + position1 + " в последовательности Фиобначчи равен: " + FibonacciNumber(position1));
            Console.WriteLine("Элемент на позиции " + position2 + " в последовательности Фиобначчи равен: " + FibonacciNumber(position2));
            Console.WriteLine("Элемент на позиции " + position3 + " в последовательности Фиобначчи равен: " + FibonacciNumber(position3));
            Console.WriteLine("Элемент на позиции " + position4 + " в последовательности Фиобначчи равен: " + FibonacciNumber(position4));

            Console.ReadKey();
        }
    }
}
