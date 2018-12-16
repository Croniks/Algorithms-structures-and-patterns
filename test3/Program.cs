using System;
using System.Text.RegularExpressions;

namespace test3
{
    class Program
    {
        static void Main(string[] args)
        {

            string someString1 = "Вася пошёл в магазин за хлебом.";

            // Первый способ
            char[] someStrCharArray = someString1.ToCharArray();
            int length = someStrCharArray.Length;

            for (int i = 0; i < length - 1; i++)
            {
                if (someStrCharArray[i] == ' ' && someStrCharArray[i + 1] != ' ')
                    someStrCharArray[i + 1] = Char.ToUpper(someStrCharArray[i + 1]);
            }
            
            someString1 = new string(someStrCharArray);
            
            Console.WriteLine(someString1);
            
            // Второй способ
            string someString2 = "Вася пошёл в магазин за хлебом.";

            someString2 = Regex.Replace(someString2, @"(\b)(\w)(\S*\b)", m =>
            m.Groups[1].Value + m.Groups[2].Value.ToUpper() + m.Groups[3].Value);

            Console.WriteLine(someString2);

            // Третий способ
            string someString3 = "Вася пошёл в магазин за хлебом.";

            string[] strings = someString3.Split(' ');
            someString3 = "";

            for (int i=0; i < strings.Length; i++)
            {
                strings[i] = strings[i].Replace(strings[i][0], char.ToUpper(strings[i][0]));
                someString3 += strings[i] + " ";
            }
            
            Console.WriteLine(someString3);

            Console.ReadKey();
        }
    }
}