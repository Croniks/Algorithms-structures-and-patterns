using System;


namespace TestStructure
{
    class Program
    {
        struct MyStruct
        {
            public int number;
            public string str;

            MyStruct(int number = 0, string str = "")
            {
                this.number = number;
                this.str = str;
            }
        }
        
        static void Main(string[] args)
        {
            MyStruct strct = new MyStruct();

            Console.WriteLine(strct.number);
            Console.WriteLine(strct.str);
            
            Console.ReadKey();
        }
    }
}
