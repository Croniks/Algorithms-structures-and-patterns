using System;


namespace Test2
{
    public abstract class Vehicle
    {
        public abstract void Move();
        public  int Move2;
        //public abstract void ToBrake();
    }

    public class Car : Vehicle
    {
        public override void Move()
        {
            Console.WriteLine("Машина едет");
        }
    }

    public class Bus : Vehicle
    {
        public override void Move()
        {
            Console.WriteLine("Автобус едет");
        }
    }

    public class Tram : Vehicle
    {
        public override void Move()
        {
            Console.WriteLine("Трамвай едет");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            for(int i=1; i < 101; i++)
                Console.WriteLine("{0}", i % 5 == 0 && i % 3 == 0 ? "FizzBuzz" : (i % 3 == 0 ? "Fizz" : (i % 5 == 0 ? "Buzz" : i.ToString())));

            for(int i=1; i < 101; i++)
            {
                string str = "";

                if(i % 3 == 0) str += "Fizz";
                if(i % 5 == 0) str += "Buzz";
                if(str == "") str += i.ToString();

                Console.WriteLine(str);
            }

            Console.ReadKey();
        }
    }
}
