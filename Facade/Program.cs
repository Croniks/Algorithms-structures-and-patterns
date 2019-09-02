using System;


namespace Facade
{
    class Program
    {
        class CarDriver
        {
            private Car _car;
            
            public CarDriver(Car car)
            {
                _car = car;
            }

            public void StartCar()
            {
                _car.Start();
            }

            public void StopCar()
            {
                _car.Stop();
            }
        }

        class Car
        {
            private Engine _engine;
            private Accumulator _accumulator;
            private FuelPump _fuelPump;

            public Car(Engine engine, Accumulator accumulator, FuelPump fuelPump)
            {
                _engine = engine;
                _accumulator = accumulator;
                _fuelPump = fuelPump;
            }

            public void Start()
            {
                _accumulator.StartAccumulator();
                _fuelPump.StartFuelPump();
                _engine.StartEngine();
            }

            public void Stop()
            {
                _accumulator.StopAccumulator();
                _fuelPump.StopFuelPump();
                _engine.StopEngine();
            }
        }

        class Engine
        {
            public void StartEngine()
            {
                Console.WriteLine("Двигатель запущен!");
            }

            public void StopEngine()
            {
                Console.WriteLine("Двигатель выключен!");
            }
        }

        class Accumulator
        {
            public bool StartAccumulator()
            {
                Console.WriteLine("Аккумулятор включён!");
                return true;
            }

            public void StopAccumulator()
            {
                Console.WriteLine("Прекращена подача электроэнергии!");
            }
        }

        class FuelPump
        {
            public bool StartFuelPump()
            {
                Console.WriteLine("Насос подал топливо в цилиндр!");
                return true;
            }

            public void StopFuelPump()
            {
                Console.WriteLine("Насос прекратил работу!");
            }
        }


        static void Main(string[] args)
        {
            Engine engine = new Engine();
            Accumulator accumulator = new Accumulator();
            FuelPump fuelPump = new FuelPump();

            Car car = new Car(engine, accumulator, fuelPump);
            CarDriver carDriver = new CarDriver(car);

            carDriver.StartCar();

            Console.WriteLine(new string('-', 30));

            carDriver.StopCar();

            Console.ReadKey();
        }
    }
}