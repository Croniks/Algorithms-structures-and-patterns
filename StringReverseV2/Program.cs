using System;


namespace StringReverseV2
{
    class Program
    {
        static string StringReverse(string @string)
        {
            char[] charArray = @string.ToCharArray();
            int length = charArray.Length;
            for (int i = 0; i < length / 2; i++)
            { 
                char temp = charArray[i];
                charArray[i] = charArray[length - 1 - i];
                charArray[length - 1 - i] = temp;
            }

            return new string(charArray);
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine(StringReverse("Hellow, world!"));

            Console.ReadKey();
        }
    }
}