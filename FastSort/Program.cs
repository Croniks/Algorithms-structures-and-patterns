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
            int[] someArray1 = { 8, 4, 2, 7, 3, 1, 5, 9, 6 };
            int[] someArray2 = { 3, 1, 1, 7, 8, 1, 5, 2, 9 };

            FastSort(someArray1, 0, someArray1.Length - 1);
            FastSort(someArray2, 0, someArray2.Length - 1);

            foreach (int n in someArray1)
                Console.Write(n + " ");

            Console.Write("\n");

            foreach (int n in someArray2)
                Console.Write(n + " ");

            Console.ReadKey();
        }
    }
}