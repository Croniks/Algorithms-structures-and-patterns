using System;


namespace BubbleSort
{
    class Program
    {
        static void BubbleSort(int[] array)
        {
            int length = array.Length;
            for(int i=0; i < length - 1; i++)
            {
                bool wasChange = false;
                for(int k=0; k < length - i - 1; k++)
                {
                    if(array[k] > array[k + 1])
                    {
                        int temp = array[k];
                        array[k] = array[k + 1];
                        array[k + 1] = temp;
                        wasChange = true;
                    }
                }

                if(!wasChange)
                    return;
            }
        }

        static void Main(string[] args)
        {
            int[] someArray = { 8, 4, 2, 7, 3, 1, 5, 9, 6 };
            int[] someArray2 = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] someArray3 = { 9, 8, 7, 6, 5, 4, 3, 2, 1 };

            BubbleSort(someArray);
            BubbleSort(someArray2);
            BubbleSort(someArray3);

            foreach (int n in someArray3)
                Console.Write(n + " ");

            Console.ReadKey();
        }
    }
}
