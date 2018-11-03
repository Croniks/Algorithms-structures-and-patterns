using System;
using System.Threading;


namespace LazySingleton
{
    class Program
    {
        class OS
        {
            public string Name { get; private set; }

            private OS(string name)
            {
                Name = name;
            }

            public static OS GetInstance(string name="MS-DOS")
            {
                return instance ?? (instance = new OS(name));
            }

            private class Nested
            {
                private static readonly OS instance = new OS();
            }
        }

        class Computer
        {
            public OS os;
            public string Name { get; private set; }
            public string OsName { get; private set; }

            public Computer(string name) { Name = name; }

            public void SetSystem(string name)
            {
                os = OS.GetInstance(name);
                OsName = os.Name;
            }
        }

        static void Main(string[] args)
        {
            (new Thread(() =>
            {
                Computer comp1 = new Computer("computer1");
                comp1.SetSystem("Windows 7");
                Console.WriteLine(comp1.Name + " : " + comp1.OsName);
            })).Start();
            
            Computer comp2 = new Computer("computer2");
            comp2.SetSystem("Windows 10");
            Console.WriteLine(comp2.Name + " : " + comp2.OsName);

            Console.ReadKey();
        }
    }
}
