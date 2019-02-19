using System;


namespace Checking
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 5;
            float b = 5.4f;

            if(a > b)
                Console.WriteLine("a > b");
            else
                Console.WriteLine("a < b");
            
            Console.ReadKey();
        }
    }
}
