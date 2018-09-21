using System;


namespace FastSort
{
    public class Program
    {
        public static void FastSort(int[] someArray, int start, int end)
        {
            if(start >= end)
                return;

            int current = start;
            for(int i = start; i < end; i++)
            {
                if(someArray[i] < someArray[end])
                {
                    int temp = someArray[current];
                    someArray[current++] = someArray[i];
                    someArray[i] = temp;
                }
            }
            int tmp = someArray[current];
            someArray[current] = someArray[end];
            someArray[end] = tmp;

            FastSort(someArray, start, current - 1);
            FastSort(someArray, current + 1, end);
        }

        static void Main(string[] args)
        {
            int[] someArray = { 8, 4, 2, 7, 3, 1, 5, 9, 6 };

            FastSort(someArray, 0, someArray.Length - 1);

            foreach (int n in someArray)
                Console.Write(n + " ");

            Console.ReadKey();
        }
    }
}
