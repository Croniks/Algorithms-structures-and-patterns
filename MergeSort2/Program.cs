using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort2
{
    class Program
    {
        static void MergeSort(int[] array)
        {
            int length = array.Length;

            if(length < 2)
                return;

            int leftLength = length / 2;
            int rightLength = (length / 2) + (length % 2);

            int[] left = new int[leftLength]; int[] right = new int[rightLength];

            for(int i=0; i < length; i++)
            {
                if(i < leftLength)
                    left[i] = array[i];
                else
                    right[i - leftLength] = array[i];
            }

            MergeSort(left); MergeSort(right);
            int l = 0; int r = 0;

            for (int i = 0; i < length; i++)
            {
                if(l < leftLength && r < rightLength)
                {
                    if(left[l] < right[r])
                        array[i] = left[l++];
                    else
                        array[i] = right[r++];
                }
                else
                {
                    if(l < leftLength)
                        array[i] = left[l++];
                    else
                        array[i] = right[r++];
                }
            }
        }

        static void Main(string[] args)
        {
            int[] array = { 6, 2, 8, 5, 1, 9, 3, 4, 7, 10 };

            MergeSort(array);

            foreach (var n in array)
                Console.Write(n + " ");

            Console.ReadKey();
        }
    }
}
