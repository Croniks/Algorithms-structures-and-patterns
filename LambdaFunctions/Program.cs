using System;


namespace LambdaFunctions
{
    class Program
    {
        // Делегат указывающий на метод, задающий логику вывода массива на экран
        private delegate bool PrintLogic(int number);

        // Метод вывода массива на экран
        private static void PrintArray(int[] arr, PrintLogic pl = null)
        {
            int length = arr.Length;

            if (pl != null)
            {
                for (int i = 0; i < length; i++)
                    if (pl(arr[i]))
                        Console.Write(arr[i] + " ");
            }
            else
                for (int i = 0; i < length; i++)
                    Console.Write(arr[i] + " ");

            Console.WriteLine();
        }


        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 5, 8, 2, 4, 3, 7, 6, 9, 10 };

            // Простой вывод массива на экран
            PrintArray(arr);

            Console.WriteLine(new string('-', 30));

            // Вывод только чётных чисел
            PrintArray(arr, n => n % 2 == 0);

            Console.WriteLine(new string('-', 30));

            // Вывод только нечётных чисел
            PrintArray(arr, n => n % 2 != 0);

            Console.WriteLine(new string('-', 30));

            // Вывод чисел больше или равных пяти
            PrintArray(arr, n => n >= 5);

            Console.ReadKey();
        }
    }
}