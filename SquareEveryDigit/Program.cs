using System;


namespace SquareEveryDigit
{
    class Programm
    {
        public static int SquareDigits(int n)
        {
            int result = 0;
            int digit = 0;

            while (n > 0)
            {
                int value = n % 10;

                if (value != 0)
                {
                    result += (int)Math.Pow(value, 2) * (int)Math.Pow(10, digit);

                    if (value > 3)
                        digit += 2;
                    else
                        digit++;
                }
                else
                    digit++;

                n /= 10;
            }

            return result;
        }


        public static void Main(string[] args)
        {
            Console.WriteLine(SquareDigits(9119));
            Console.WriteLine(SquareDigits(9119));
            Console.WriteLine(SquareDigits(123));
            Console.WriteLine(SquareDigits(5972));
            Console.WriteLine(SquareDigits(2106));
            Console.WriteLine(SquareDigits(2006));
            Console.WriteLine(SquareDigits(0030502));
            Console.WriteLine(SquareDigits(6));
            Console.WriteLine(SquareDigits(214));

            Console.ReadKey();
        }
    }
}