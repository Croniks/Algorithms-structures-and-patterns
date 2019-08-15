using System;


namespace Test2
{
    public struct LaunchStatus
    {
        public static readonly LaunchStatus Green = new LaunchStatus(0);
        public static readonly LaunchStatus Yellow = new LaunchStatus(1);
        public static readonly LaunchStatus Red = new LaunchStatus(2);
        
        public int status;
        
        public LaunchStatus(int status)
        {
            this.status = status;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            LaunchStatus status = new LaunchStatus();

            Console.WriteLine(status.status);
            Console.ReadKey();
        }
    }
}
