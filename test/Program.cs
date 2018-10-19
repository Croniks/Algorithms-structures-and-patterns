using System;
using System.Collections;


namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable ht = new Hashtable();

            ht.Add(0, "Zero");
            ht.Add(1, "One");
            ht.Add(2, "Two");

            //Console.WriteLine(ht[2]);
            int result = 2 + (int)ht[3];

            Console.WriteLine(result);

            Console.ReadKey();
        }
    }
}
