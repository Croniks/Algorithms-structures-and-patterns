using System;


namespace test8
{
    class Program
    {
        public static void ShowNumbers1(int a, int b, int c)
        {
            Console.WriteLine($"a = {a}, b = {b}, c = {c}");
        }

        public static void ShowNumbers2(params int[] numbers)
        {
            foreach(int number in numbers)
                Console.Write($"{number} ");
        }

        static void Main(string[] args)
        {
            ShowNumbers1(b: 3, a : 4, c : 7);
            
            Console.ReadKey();
        }
    }
}
