using System;


namespace Asterisks
{
    class Program
    {
        public static void PrintTriangle(int size, bool reverse=false)
        {
            if(size < 1)
                throw new ArgumentException("Размер треугольника " +
                    "должен быть положительным целым числом!");
            
            void Print(int i)
            {
                string str = new string(' ', ((2 * size - 1) - (2 * i - 1)) / 2 );
                str += new string('*', (2 * i - 1) );

                Console.WriteLine(str);
            }

            if (!reverse)
                for (int i=1; i < size+1; i++)
                    Print(i);
            else
                for (int i=size; i > 0; i--)
                    Print(i);    
        }

        public static void PrintTriangle2(int size, bool reverse = false)
        {
            if (size < 1)
                throw new ArgumentException("Размер треугольника " +
                    "должен быть положительным целым числом!");

            void Print(int i)
            {
                for (int j = 0; j < size - (2 * (i + 1)) / 2; j++) Console.Write(' ');
                for (int j = 0; j < (2 * (i + 1) - 1); j++) Console.Write('*');
                Console.WriteLine();
            }

            if(!reverse)
                for (int i=0; i < size; i++)
                    Print(i);
            else
                for (int i = size -1; i >= 0; i--)
                    Print(i);
        }
        
        static void Main(string[] args)
        {
            try
            {
                PrintTriangle(5);
                Console.WriteLine(new string('-', 9));
                Console.WriteLine();

                PrintTriangle(5, true);
                Console.WriteLine(new string('-', 9));
                Console.WriteLine();

                PrintTriangle(5);
                PrintTriangle(5, true);

                Console.WriteLine(new string('-', 9));
                Console.WriteLine();

                PrintTriangle2(5);
                PrintTriangle2(5, true);

                PrintTriangle(-2);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}
