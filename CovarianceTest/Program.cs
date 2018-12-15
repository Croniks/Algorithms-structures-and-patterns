using System;
using System.Collections.Generic;


namespace Covariance
{
    class Car
    {
        public virtual void GetInfo() { Console.WriteLine("Автомобиль!"); }
    }

    class Kuga : Car
    {
        public override void GetInfo() { Console.WriteLine("Автомобиль компании \"Форд\", модель \"Куга\"!"); }
    }

    interface IAutoDealer<out T>
    {
        T GetCar();
    }
    
    class FordDealer<T> : IAutoDealer<T> where T : Car, new()
    {
        public T GetCar() { return new T(); }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            FordDealer<Kuga> autoDealer1 = new FordDealer<Kuga>();
            Car auto1 = autoDealer1.GetCar();
            auto1.GetInfo();
            
            IAutoDealer<Car> autoDealer2 = new FordDealer<Kuga>();
            Car auto2 = autoDealer2.GetCar();
            auto2.GetInfo();
            
            Console.ReadKey();
        }
    }
}
