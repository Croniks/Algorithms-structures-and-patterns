using System;


namespace TypeThroughPoint
{
    class Parent
    {
        public class Child
        {
            public string name;

            public Child(string name = "Child")
            {
                this.name = name;
            }
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Parent.Child child = new Parent.Child("Вася");
            Console.WriteLine(child.name);

            Console.ReadKey();
        }
    }
}