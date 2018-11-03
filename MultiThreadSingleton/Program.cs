using System;
using System.Threading;

namespace MultithreadSingleton
{
    class OS
    {
        private static object SyncRoot = new Object();
        private static OS os;
        public string Name { get; private set; }

        protected OS(string name) { Name = name; }

        public static OS GetInstance(string name)
        {
            lock(SyncRoot)
            {
                return os ?? (os = new OS(name));
            }
        }
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
            (new Thread(() =>
            {
                Computer comp2 = new Computer("Windows 10");
                Console.WriteLine(comp2.OS.Name);
            })).Start();
            
            Computer comp = new Computer("Windows 8.1");
            Console.WriteLine(comp.OS.Name);

            Console.WriteLine(System.Guid.NewGuid().ToString());

            Console.ReadLine();
        }
    }
}
