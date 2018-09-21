using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectionSort
{
    class Program
    {
        static void SelectionSort(int[] array)
        {
            int length = array.Length;
            for (int i = 0; i < length - 1; i++)
            {
                for (int k = i + 1; k < length; k++)
                {
                    if (array[i] > array[k])
                    {
                        int temp = array[k];
                        array[k] = array[i];
                        array[i] = temp;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            int[] someArray = { 8, 4, 2, 7, 3, 1, 5, 9, 6 };
            int[] someArray2 = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] someArray3 = { 9, 8, 7, 6, 5, 4, 3, 2, 1 };

            SelectionSort(someArray);
            SelectionSort(someArray2);
            SelectionSort(someArray3);

            foreach (int n in someArray)
                Console.Write(n + " ");

            Console.ReadKey();
        }
    }
}
