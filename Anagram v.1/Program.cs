using System;
using System.Collections.Generic;


namespace Anagram_v._1
{
    class Program
    {
        public static bool IsAnagram(string str1, string str2)
        {
            if(str1 == str2 || str1 is null || str2 is null)
                return false;

            str1 = str1.ToLower();
            str2 = str2.ToLower();
            
            Dictionary<char, int> dict1 = new Dictionary<char, int>();
            Dictionary<char, int> dict2 = new Dictionary<char, int>();

            void FillDict(Dictionary<char, int> dict, string str)
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] != ' ')
                    {
                        if (!dict.ContainsKey(str[i]))
                            dict.Add(str[i], 1);
                        else
                            dict[str[i]]++;
                    }
                }
            }

            FillDict(dict1, str1);
            FillDict(dict2, str2);
            
            if(dict1.Count != dict2.Count)
                return false;

            foreach(var pair in dict1)
            {
                if(dict2.ContainsKey(pair.Key))
                {
                    if(pair.Value != dict2[pair.Key])
                        return false;
                }
                else
                    return false;
            }

            return true;
        }

        static void Main(string[] args)
        {
            string str1 = "Том Нарволо Реддл"; 
            string str2 = "Лорд Волан де Морт";
            
            Console.WriteLine(IsAnagram(str1, str2));

            Console.ReadKey();
        }
    }
}
