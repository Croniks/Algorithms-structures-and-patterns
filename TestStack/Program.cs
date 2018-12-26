using System;
using System.Collections.Generic;


namespace TestStack
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> someStack = new Stack<string>();

            someStack.Push("world!");
            someStack.Push("Hellow, ");

            foreach(var word in someStack)
                Console.Write(word);
            
            Console.ReadKey();
        }
    }
}
