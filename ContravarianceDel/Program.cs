using System;


namespace ContravarianceDel
{
    class Cat
    {
        public string Name { get; set; }
        public string Breed { get; protected set; }

        public Cat(string name = "Пусик")
        {
            Name = name;
            Breed = "Порода не известна";
        }
    }

    class MaineCoon : Cat
    {
        public MaineCoon(string name = "Пусик")
        {
            Name = name;
            Breed = "Мейн Кун";
        }

        public MaineCoon GetMaineCoonCat() { return this; }

        // Объявление метода с помощью лямбда-выражения
        public void GetInfo() => Console.WriteLine($"{Name} : {Breed}");
    }


    class Program
    {
        delegate void ContravarianceDel(MaineCoon cat);

        static void CatInfo(Cat cat) { Console.WriteLine(cat.Name + " : " + cat.Breed); }

        static void Main(string[] args)
        {
            MaineCoon mc = new MaineCoon("Чейз");
            Cat cat = mc;

            ContravarianceDel del = CatInfo;

            del((MaineCoon)cat); // Как по мне, так полная хрень!

            mc.GetInfo();

            Console.ReadKey();
        }
    }
}