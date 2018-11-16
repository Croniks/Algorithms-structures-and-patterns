using System;

namespace test6
{
    class Program
    {
        static int a;

        public static void Func1()
        {
            if (a > 4) return;
            a++;
            Console.WriteLine(a);
            Func1();
        }
        
        static void Main(string[] args)
        {
            Func1();
            
            Console.ReadKey();
        }
    }
}
