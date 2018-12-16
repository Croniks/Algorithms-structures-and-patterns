using System;


namespace Closure
{
    class Program
    {
        public delegate int Counter();
        
        public static Counter ReturnCounter(int number)
        {
            return () => number++;
        }
        
        static void Main(string[] args)
        {
            Counter counter = ReturnCounter(1);
            
            Console.WriteLine(counter());
            Console.WriteLine(counter());
            Console.WriteLine(counter());
            Console.WriteLine(counter());
            
            Console.ReadKey();
        }
    }
}
