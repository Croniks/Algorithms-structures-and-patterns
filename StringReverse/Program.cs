using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringReverseV1
{
    class Program
    {
        static string StringReverse(string @string)
        {
            string newString = "";
            for(int i = @string.Length - 1; i >= 0; i--)
                newString += @string[i];
            
            return newString;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(StringReverse("Улыбок тебе дед Макар"));

            Console.ReadKey();
        }
    }
}
