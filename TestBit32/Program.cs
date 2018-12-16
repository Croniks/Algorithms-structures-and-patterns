using System;
using System.Collections.Specialized;


namespace TestBit32
{
    class Program
    {
        static void Main(string[] args)
        {
            int bit1 = BitVector32.CreateMask();
            int bit2 = BitVector32.CreateMask(bit1);
            int bit3 = BitVector32.CreateMask(bit2);
            int bit4 = BitVector32.CreateMask(bit3);
            int bit5 = BitVector32.CreateMask(bit4);
            
            Console.WriteLine(bit1);
            Console.WriteLine(bit2);
            Console.WriteLine(bit3);
            Console.WriteLine(bit4);
            Console.WriteLine(bit5);

            Console.WriteLine(BitVector32.CreateMask(64));

            Console.ReadKey();
        }
    }
}
