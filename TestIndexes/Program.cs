using System;


namespace TestIndexes
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] doubleArr = new double[]{ 12.6, 343.2, 122.3, 22.5,};
            
            for(double i=0.3; i < doubleArr.Length; i++)
                Console.WriteLine(doubleArr[(int)i]);

            Console.ReadKey();
        }
    }
}
