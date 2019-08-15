using System;
using System.Linq;
using System.Text.RegularExpressions;


namespace Vowels
{
    class Program
    {
        public static int VowelsCount1(string str)
        {
            char[] vowels = new char[]{ 'a', 'o', 'e', 'i', 'u'};
            str = str.ToLower();
            int length = str.Length;
            int count = 0;

            for(int i=0; i < length; i++)
            {
                if(vowels.Contains(str[i]))
                    count++;
            }

            return count;
        }

        public static int VowelsCount2(string str)
        {
            Regex regex = new Regex(@"[aAoOeEiIuU]");
            MatchCollection matches = regex.Matches(str);
            
            return matches.Count;
        }

        
        static void Main(string[] args)
        {
            string str1 = "haha";
            string str2 = "Hellow, world!";

            Console.WriteLine(VowelsCount1(str1));
            Console.WriteLine(VowelsCount1(str2));

            Console.WriteLine(VowelsCount2(str1));
            Console.WriteLine(VowelsCount2(str2));

            Console.ReadKey();
        }
    }
}
