using System;
using System.Threading;


namespace TestDashMoving
{
    class Program
    {
        static void Main(string[] args)
        {
            int index = 0;
            int velocity = 1000 / 30;
            
            while (true)
            {
                if (index > 40) index = 0;
                
                Console.Write(new string(' ', index++) + "===");
                Thread.Sleep(velocity);

                Console.Clear();
            }
        }
    }
}