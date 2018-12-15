using System;
using System.Collections.Generic;


namespace test10
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> someList = new List<int>();

            someList.Add(2);
            someList.Add(4);
            someList.Add(6);

            Console.WriteLine(someList[4]);

            Console.ReadKey();
        }
    }
}
