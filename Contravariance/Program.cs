using System;
using System.Collections.Generic;


namespace Contravariance
{
    class Car
    {
        public virtual void GetInfo() { Console.WriteLine("Автомобиль!"); }
    }
    
    class Kuga : Car
    {
        public override void GetInfo() { Console.WriteLine("Автомобиль компании \"Форд\", модель \"Куга\"!"); }
    }

    interface IInformationService<in T>
    {
        void GetInfo(T car);
    }

    class CarInformation<T> : IInformationService<T> where T : Car, new()
    {
        public void GetInfo(T car) { car.GetInfo(); }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new Car();
            Kuga car2 = new Kuga();

            IInformationService<Car> infoService1 = new CarInformation<Car>();
            IInformationService<Kuga> infoService2 = new CarInformation<Car>();

            infoService1.GetInfo(car1);
            infoService1.GetInfo(car2);
            
            infoService2.GetInfo(car2);

            Console.ReadKey();
        }
    }
}
