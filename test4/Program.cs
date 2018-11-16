using System;
using System.Collections.Generic;


namespace test4
{
    class Program
    {
        public static List<int> Intersection(int[] arr1, int[] arr2)
        {
            int length1 = arr1.Length;
            int length2 = arr2.Length;
            List<int> resultArry = new List<int>();

            int index1 = 0;
            int index2 = 0;
            
            while (index1 < length1 && index2 < length2)
            {
                if(arr1[index1] == arr2[index2])
                {
                    resultArry.Add(arr1[index1++]);
                    index2++;
                }
                else if(arr1[index1] > arr2[index2])
                    index2++;
                else
                    index1++;
            }
            
            return resultArry;
        }

        static void Main(string[] args)
        {
            List<int> someArray = Intersection(new int[] { 4, 5, 6, 7, 8}, new int[] { 6, 7, 8, 9, 10});

            foreach(int number in someArray)
                Console.Write(number + " ");
            
            Console.ReadKey();
        }
    }
}
