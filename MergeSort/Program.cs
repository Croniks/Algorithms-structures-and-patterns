using System;


namespace MergeSort
{
    class Program
    {
        static void MergeSort(int[] someArray)
        {
            if(someArray.Length < 2)
                return;
            
            int length = someArray.Length;
            int leftLength = length / 2;
            int rightLength = (length / 2) + (length % 2);
            
            int[] left = new int[leftLength];
            int[] right = new int[rightLength];

            for(int i=0; i < length; i++)
            {
                if(i < leftLength)
                    left[i] = someArray[i];
                else
                    right[i - leftLength] = someArray[i];
            }

            MergeSort(left);
            MergeSort(right);

            int l = 0, r = 0;

            for(int k = 0; k < length; k++)
            {
                if(l < leftLength && r < rightLength)
                {
                    if (left[l] < right[r])
                        someArray[k] = left[l++];
                    else
                        someArray[k] = right[r++];
                }
                else
                {
                    if(l < leftLength)
                        someArray[k] = left[l++];
                    else
                        someArray[k] = right[r++];
                }
            }
        }

        static void Main(string[] args)
        {
            int[] someArray = {8, 4, 2, 7, 3, 1, 5, 9, 6};

            MergeSort(someArray);

            foreach(int n in someArray)
                Console.Write(n + " ");

            Console.ReadKey();
        }
    }
}
