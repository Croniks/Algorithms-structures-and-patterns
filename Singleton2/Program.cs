using System;

namespace Singleton2
{
    class OS
    {
        private static OS os;
        public string Name { get; private set; }

        protected OS(string name) { Name = name; }
        public static OS GetInstance(string name) { return os ?? (os = new OS(name)); }
    }

    class Computer
    {
        public OS OS { get; set; }
        
        public Computer(string OsName) { OS = OS.GetInstance(OsName); }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Computer comp = new Computer("Windows 7");
            Console.WriteLine(comp.OS.Name);

            comp.OS = OS.GetInstance("windows 10");
            Console.WriteLine(comp.OS.Name);

            Console.ReadLine();
        }
    }
}
