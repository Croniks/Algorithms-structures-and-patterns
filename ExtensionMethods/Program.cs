using System;


namespace ExtensionMethods
{
    static class IntExtension
    {
        public static void ShowInfo(this int number)
        {
            Console.WriteLine($"Это число {number}");
        }
    }

    class Person
    {
        public string name;
        
        public Person(string name) {  this.name = name; }
    }

    static class PersonExtension
    {
        public static string GetName(this Person str)
        {
            return str.name;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            int a = 5;
            a.ShowInfo();

            Person person = new Person("Вася");
            Console.WriteLine(person.name);
            Console.WriteLine(person.GetName());

            Console.ReadKey();
        }
    }
}