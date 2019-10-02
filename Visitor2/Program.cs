using System;


namespace Visitor2
{
    static class ManExtension
    {
        public static void Crawl(this Man man)
        {
            Console.WriteLine($"{man.name} ползёт!");
        }
    }

    class Man
    {
        public string name;

        public Man(string name = "Вася") { this.name = name; }

        public void Go() { Console.WriteLine($"{name} идёт!"); }
        public void Run() { Console.WriteLine($"{name} бежит!"); }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Man someMan = new Man();

            someMan.Go();
            someMan.Run();
            someMan.Crawl();
            
            Console.ReadKey();
        }
    }
}