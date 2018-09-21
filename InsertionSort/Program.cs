using System;


namespace InsertionSort
{
    class Program
    {
        static void InsertionSort(int[] array)
        {
            int length = array.Length;
            for (int i = 1; i < length; i++)
            {
                int index = i;
                while(index > 0)
                {
                    if (array[index] < array[index - 1])
                    {
                        int temp = array[index];
                        array[index] = array[index - 1];
                        array[index - 1] = temp;
                    }
                    index--;
                }
            }
        }

        static void Main(string[] args)
        {
            int[] someArray = { 8, 4, 2, 7, 3, 1, 5, 9, 6 };
            int[] someArray2 = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] someArray3 = { 9, 8, 7, 6, 5, 4, 3, 2, 1 };

            InsertionSort(someArray);
            InsertionSort(someArray2);
            InsertionSort(someArray3);

            foreach (int n in someArray3)
                Console.Write(n + " ");

            Console.ReadKey();
        }
    }
}
