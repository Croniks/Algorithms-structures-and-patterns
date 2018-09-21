using System;


namespace FactorialRecursive
{
    class Program
    {
        static int Factorial(int number)
        { 
            return number < 2 ? 1 : number * Factorial(number - 1);
        }

        static void Main(string[] args)
        {
            Console.WriteLine(Factorial(1));
            Console.WriteLine(Factorial(2));
            Console.WriteLine(Factorial(3));
            Console.WriteLine(Factorial(4));
            Console.WriteLine(Factorial(5));

            Console.ReadKey();
        }
    }
}
