using System;


namespace Closure
{
    delegate void PrintNumber();

    class Program
    {
        static void Main(string[] args)
        {
            PrintNumber Pn1 = () => Console.WriteLine(0);
            PrintNumber Pn2 = () => Console.WriteLine(0);

            for (int i = 1; i < 5; i++)
            {
                Pn1 += () => Console.WriteLine(i);
            }

            Pn1();

            Console.WriteLine(new string('-', 4));

            for (int i = 1; i < 5; i++)
            {
                int j = i;
                Pn2 += () => Console.WriteLine(j);
            }

            Pn2();

            Console.ReadKey();
        }
    }
}
