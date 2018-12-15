using System;


namespace TemplateMethod
{
    abstract class Worker
    {   
        public void Work()
        {
            PrepareForWork();
            StartWork();
            EndedWork();
        }
        
        abstract public void PrepareForWork();
        abstract public void StartWork();
        abstract public void EndedWork();
    }
    
    class Cleaner : Worker
    {
        public override void PrepareForWork()
        {
            Console.WriteLine("Уборщик берёт швабру!");
        }

        public override void StartWork()
        {
            Console.WriteLine("Уборщик моет пол!");
        }

        public override void EndedWork()
        {
            Console.WriteLine("Уборщик закончил мыть пол!");
        }
    }

    class Programmer : Worker
    {
        public override void PrepareForWork()
        {
            Console.WriteLine("Программист включает компьютер!");
        }
        
        public override void StartWork()
        {
            Console.WriteLine("Программист печатает код!");
        }

        public override void EndedWork()
        {
            Console.WriteLine("Программист закончил писать код!");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Cleaner cleaner = new Cleaner();
            Programmer programmer = new Programmer();
            
            cleaner.Work();
            programmer.Work();
            
            Console.ReadKey();
        }
    }
}