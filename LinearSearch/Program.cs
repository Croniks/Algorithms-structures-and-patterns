using System;


namespace LinearSearch
{
    class Program
    {
        static int LinearSearch(int[] array, int number)
        {
            int index = 0;
            int last = array[array.Length - 1];
            array[array.Length - 1] = number;

            while(array[index] != number)
            {
                index++;
            }

            array[array.Length - 1] = last;

            if (index < array.Length - 1 || array[array.Length - 1] == number)
            {
                Console.WriteLine(index);
                return index;
            }

            Console.WriteLine(index);
            return -1;
        }

        static void Main(string[] args)
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Console.WriteLine(LinearSearch(array, 20));

            Console.ReadKey();
        }
    }
}
