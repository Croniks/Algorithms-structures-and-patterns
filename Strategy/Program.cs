using System;


namespace Strategy
{
    class Program
    {
        interface ITrackingTime
        {
            string GetTime();
        }

        class SunClock : ITrackingTime
        {
            private string name = "Солнечные часы";

            public string GetTime()
            {
                return name + " показывают: " + DateTime.Now;
            }
        }

        class ElectronicClock : ITrackingTime
        {
            private string name = "Электронные часы";

            public string GetTime()
            {
                return name + " показывают: " + DateTime.Now;
            }
        }

        class MechanicalClock : ITrackingTime
        {
            private string name = "Механические часы";

            public string GetTime()
            {
                return name + " показывают: " + DateTime.Now;
            }
        }

        class SandClock : ITrackingTime
        {
            private string name = "Песочные часы";

            public string GetTime()
            {
                return name + " показывают: " + DateTime.Now;
            }
        }

        class Man
        {
            public string Name { get; private set; }
            public ITrackingTime TrakingTimeDevice { get; set; }

            public Man(string name = "Вася", ITrackingTime device = null)
            {
                Name = name;
                TrakingTimeDevice = device;
            }

            public void ShowTime()
            {
                Console.WriteLine(TrakingTimeDevice?.GetTime() ?? "Нет устройства для определения времени!");
            }
        }

        static void Main(string[] args)
        {
            Man man = new Man("Петя");
            
            man.ShowTime();

            Console.WriteLine(new string('-', 50));

            man.TrakingTimeDevice = new MechanicalClock();
            man.ShowTime();

            man.TrakingTimeDevice = new ElectronicClock();
            man.ShowTime();
            
            Console.ReadKey();
        }
    }
}
