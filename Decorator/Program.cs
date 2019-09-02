using System;


namespace Decorator
{
    abstract class Lamp
    {
        public string Name { get; private set; }

        public Lamp(string name)
        {
            Name = name;
        }
        
        abstract public int GetCost();
    }

    class IncandescentLamp : Lamp
    {
        public IncandescentLamp() : base("Лампа накаливания"){}
        
        public override int GetCost()
        {
            return 100;
        }
    }

    class LEDLamp : Lamp
    {
        public LEDLamp() : base("Лампа светодиодная") {}

        public override int GetCost()
        {
            return 120;
        }
    }

    class RedLampDecorator : Lamp
    {
        public int DecorCost { get; private set; } = 20;
         
        private Lamp _lamp;

        public RedLampDecorator(Lamp lamp) : base(lamp.Name + " - красный цвет")
        {
            _lamp = lamp;
        }
        
        public override int GetCost()
        {
            return _lamp.GetCost() + DecorCost;
        }
    }

    class GreenLampDecorator : Lamp
    {
        public int DecorCost { get; private set; } = 30;

        private Lamp _lamp;

        public GreenLampDecorator(Lamp lamp) : base(lamp.Name + " - зелёный цвет")
        {
            _lamp = lamp;
        }

        public override int GetCost()
        {
            return _lamp.GetCost() + DecorCost;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Lamp incandescentLamp = new IncandescentLamp();
            Lamp ledLamp = new LEDLamp();

            Console.WriteLine(incandescentLamp.Name);
            Console.WriteLine(incandescentLamp.GetCost());

            Console.WriteLine(ledLamp.Name);
            Console.WriteLine(ledLamp.GetCost());

            Console.WriteLine(new string('-', 30));

            incandescentLamp = new RedLampDecorator(incandescentLamp);
            ledLamp = new GreenLampDecorator(ledLamp);

            Console.WriteLine(incandescentLamp.Name);
            Console.WriteLine(incandescentLamp.GetCost());

            Console.WriteLine(ledLamp.Name);
            Console.WriteLine(ledLamp.GetCost());

            Console.ReadKey();
        }
    }
}