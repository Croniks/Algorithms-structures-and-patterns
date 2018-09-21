using System;


namespace CaesarCipher
{
    class Program
    {
        static string Cipher(string @string, int key=3)
        {
            char[] charArray = @string.ToCharArray();
            int length = charArray.Length;

            for(int i=0; i < length; i++)
            {
                char newChar = (char)((int)charArray[i] + key);
                charArray[i] = newChar;
            }

            return new string(charArray);
        }

        static string DeCipher(string @string, int key=3)
        {
            return Cipher(@string, -key);
        }

        static void Main(string[] args)
        {
            string baseString = "Hellow, world!";
            Console.WriteLine(baseString);

            string cipheredString = Cipher(baseString, 10);
            Console.WriteLine(cipheredString);

            string desipheredString = DeCipher(cipheredString, 10);
            Console.WriteLine(desipheredString);

            Console.ReadKey();
        }
    }
}
