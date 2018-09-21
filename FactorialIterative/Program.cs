using System;


namespace FactorialIterative
{
    class Program
    {
        static int Factorial(int number)
        {
            int result = 1;
            while(number > 1)
                result *= number--;
            
            return result;
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
