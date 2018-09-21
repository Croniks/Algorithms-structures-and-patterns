using System;


namespace BinarySearch
{
    class Program
    {
        static int BinarySearch(int[] array, int number, int start, int end, int numberOperations=0)
        {
            numberOperations++;

            int middle = (start + end) / 2;

            if (start == end)
            {
                if(array[middle] == number)
                {
                    Console.WriteLine(numberOperations);
                    return middle;
                }
                else
                {
                    Console.WriteLine(numberOperations);
                    return -1;
                }
            }

            if(array[middle] > number)
            {
                return BinarySearch(array, number, start, middle -1, numberOperations);
            }
            else if(array[middle] < number)
            {
                return BinarySearch(array, number, middle + 1, end, numberOperations);
            }
            else
            {
                Console.WriteLine(numberOperations);
                return middle;
            }
        }

        static void Main(string[] args)
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Console.WriteLine(BinarySearch(array, 20, 0, array.Length -1));

            Console.ReadKey();
        }
    }
}
