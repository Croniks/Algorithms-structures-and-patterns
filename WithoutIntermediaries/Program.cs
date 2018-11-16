using System;


namespace WithoutIntermediaries
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 5; int b = 3;
            
            Console.WriteLine("a = " + a);
            Console.WriteLine("b = " + b);
            
            a = a ^ b; // 0101 -- a == 5 
                       //  ^
                       // 0011 -- b == 3
                       // 0110 -- a == 6
            
            Console.WriteLine(a);
            
            b = a ^ b; // 0110 -- a == 6
                       //  ^
                       // 0011 -- b == 3
                       // 0101 -- b == 5
            
            Console.WriteLine(b);
            
            a = a ^ b;
            
            Console.WriteLine("a = " + a);
            Console.WriteLine("b = " + b);
            
            Console.ReadKey();
        }
    }
}
