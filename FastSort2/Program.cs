using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastSort2
{
    class Program
    {
        static void FastSort(int[] array, int start, int end)
        {
            if(start >= end)
                return;

            int temp;
            int index = start;
            for(int i = start; i < end; i++)
            {
                if(array[i] < array[end])
                {
                    temp = array[i];
                    array[i] = array[index];
                    array[index++] = temp;
                }
            }
            temp = array[end];
            array[end] = array[index];
            array[index] = temp;

            FastSort(array, start, index - 1);
            FastSort(array, index + 1, end);
        }

        static void Main(string[] args)
        {
            int[] array = { 6, 2, 8, 5, 1, 9, 3, 4, 7, 10 };

            FastSort(array, 0, array.Length - 1);

            foreach(var n in array)
                Console.Write(n + " ");

            Console.ReadKey();
        }
    }
}
