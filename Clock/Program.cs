using System;


namespace Clock
{
    class Program
    { 
        public static float CalculateAngle1(float hours, float minutes)
        {
            if (hours > 12) hours = Math.Abs(hours - 12);
            return Math.Abs((((hours * 5) + minutes / 12) - minutes) * 6);
        }

        public static float CalculateAngle2(float hours, float minutes)
        {
            if (hours > 12) hours = Math.Abs(hours - 12);

            float angleMinutes = minutes * (360 / 60);
            float angleHours = 360/12*hours + 30/(360/angleMinutes);

            return Math.Abs(angleHours - angleMinutes);
        }

        public static float CalculateAngle3(float hours, float minutes)
        {
            if (hours > 12 || hours == 0) hours = Math.Abs(hours - 12);
            return Math.Abs(( ( (hours * 5) + minutes/12) - minutes ) * 6);
        }

        static void Main(string[] args)
        {
            Console.WriteLine(CalculateAngle1(10, 47));
            Console.WriteLine(CalculateAngle1(3, 15));
            
            Console.WriteLine(new string('-', 30));

            Console.WriteLine(CalculateAngle2(10, 47));
            Console.WriteLine(CalculateAngle2(3, 15));

            Console.WriteLine(new string('-', 30));

            Console.WriteLine(CalculateAngle3(10, 47));
            Console.WriteLine(CalculateAngle3(22, 47));

            Console.WriteLine(new string('-', 30));

            Console.WriteLine(CalculateAngle3(00, 47));
            Console.WriteLine(CalculateAngle3(12, 47));
            
            Console.ReadKey();
        }
    }
}
