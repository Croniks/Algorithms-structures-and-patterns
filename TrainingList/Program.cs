using System;
using System.Collections.Generic;


namespace TrainingList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> someList = new List<string>();

            someList.Add("Hellow");
            someList.Add(",");
            someList.Add(" world");
            someList.Add("!");

            Console.WriteLine(someList.FindIndex(str => str == " world"));
            
            Console.ReadKey();
        }
    }
}
