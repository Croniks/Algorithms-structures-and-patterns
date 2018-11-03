using System;


namespace Singleton
{
    class Singleton
    {
        private static Singleton instance;

        private Singleton() {}

        public static Singleton GetInstance() { return instance ?? (instance = new Singleton()); }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Singleton s1 = Singleton.GetInstance();
            Singleton s2 = Singleton.GetInstance();

            Console.WriteLine(s1 == s2);

            Console.ReadKey();
        }
    }
}
