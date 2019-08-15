using System;


namespace Test
{
    class Parent
    {
        public string text = "Parent";

        public static bool operator true(Parent parent)
        {
            return parent != null ? true : false;
        }

        public static bool operator false(Parent parent)
        {
            return parent != null ? true : false;
        }
    }

    class Child : Parent
    {
        public new string text = "Child";
        public string parentText { get{ return base.text; } set { base.text = value; } }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //float number1 = 101f, number2 = 100f;

            //Console.WriteLine(number1 % number2);

            Parent parent1 = new Parent();
            Parent parent2 = null;

            if (parent1)
                Console.WriteLine("Parent1 is true");
            else
                Console.WriteLine("Parent1 is false");

            if (parent2)
                Console.WriteLine("Parent2 is true");
            else
                Console.WriteLine("Parent2 is false");

            Console.ReadKey();
        }
    }
}