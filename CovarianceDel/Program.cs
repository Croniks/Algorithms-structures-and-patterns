using System;


namespace CovarianceDel
{
    abstract class Cat
    {
        public string Name {get; set; }
        public string Breed { get; protected set; }
    }

    class MaineCoon : Cat
    {
        public MaineCoon(string name = "Пусик")
        {
            Name = name;
            Breed = "Мейн Кун";
        }
        
        public MaineCoon GetMaineCoonCat() { return this; }
    }


    class Program
    {
        private delegate Cat CovarianceDel();

        static void Main(string[] args)
        {
            MaineCoon mc = new MaineCoon("Чейз");
            CovarianceDel del = mc.GetMaineCoonCat;

            Cat cat = del();

            Console.WriteLine(cat.Name);
            Console.WriteLine(cat.Breed);

            Console.ReadKey();
        }
    }
}
