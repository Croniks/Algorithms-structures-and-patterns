using System;


namespace EnumTest
{
    [System.Flags]
    enum Pilot { PILOTOFF = 0, PRINTER = 1, COMPUTER = 2, MONITOR = 4, LAMP = 8, ROUTER = 16 }

    class Program
    {
        static void Main(string[] args)
        {
            Pilot pilot = (Pilot)0b11111; // or
            pilot = (Pilot)31; // or
            pilot = (Pilot)0x1F; // or
            pilot = pilot | (Pilot.COMPUTER |
                                Pilot.MONITOR |
                                    Pilot.ROUTER |
                                        Pilot.LAMP |
                                            Pilot.PRINTER);
            
            Console.WriteLine("В пилот включены следующие устройства: " + pilot);
            Console.WriteLine(new string('-', 79));

            // Отключить компьютер и монитор от пилота
            pilot = pilot ^ (Pilot.COMPUTER | Pilot.MONITOR);
            Console.WriteLine("В пилот включены следующие устройства: " + pilot);

            // Включить компьютер обратно в пилот
            pilot = pilot | (Pilot.COMPUTER | Pilot.MONITOR);
            Console.WriteLine("В пилот включены следующие устройства: " + pilot);

            Console.WriteLine(new string('-', 79));

            // Выключить все устройства
            pilot = pilot & 0;
            Console.WriteLine("В пилот включены следующие устройства: " + pilot);

            // Включить все устройства
            pilot = pilot | (Pilot)0b11111; 
            Console.WriteLine("В пилот включены следующие устройства: " + pilot);

            Console.ReadKey();
        }
    }
}