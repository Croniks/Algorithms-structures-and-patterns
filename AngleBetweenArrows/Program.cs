using System;


namespace AngleBetweenArrows
{
    class Program
    {
        static float GetAngle(float hours, float minutes)
        {
            if(hours > 12 || hours == 0) hours = Math.Abs(hours - 12);
            return Math.Abs((minutes - ((hours * 5)  + (minutes / 12))) * 6);  
        }

        static void Main(string[] args)
        {
            Console.WriteLine(GetAngle(10, 47));
            Console.WriteLine(GetAngle(22, 47));

            Console.ReadKey();
        }
    }
}