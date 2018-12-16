using System;


namespace UpCastTest
{
    class MyClass
    {
        public int Number { get; private set; }
        public string Str { get; private set; }

        //public int GetValue(Type int) { return Number; }
        //public string GetValue(Type string) { return Str; }
    }

        
    class Program
    {
        static void Main(string[] args)
        {
            

            string str = "Hellow, world!";
            object obj1 = str;

            int number = 5;
            object obj2 = number;
            
            string stringFromObjString = obj1 as string;
            string stringFromObjInt = obj2 as string;

            //int intFromObjString = (int)obj1;
            int intFromObjInt = (int)obj2;

            Console.WriteLine(stringFromObjString);
            Console.WriteLine(stringFromObjInt);

            //Console.WriteLine(intFromObjString);
            Console.WriteLine(intFromObjInt);

            Console.ReadKey();
        }
    }
}
