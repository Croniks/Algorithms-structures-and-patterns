using System;


namespace CovarianceGenericDel
{
    class Cat
    {
        public string Name { get; set; }
        public string Breed { get; protected set; }

        public Cat(string name = "Котик")
        {
            Name = name;
            Breed = "Порода не определена";
        }
        
        public Cat GetCat() { return this; }
        public virtual void ShowInfo(){ Console.WriteLine($"{Name} : {Breed}"); }
    }
    
    class MaineCoon : Cat
    {
        public MaineCoon(string name = "Мейнкунчик")
        {
            Name = name;
            Breed = "Мейн Кун";
        }
        
        public MaineCoon GetMaineCoon() { return this; }
        public override void ShowInfo() { Console.WriteLine($"{Name} : {Breed}"); }
    }


    class Program
    {
        private delegate T CovarianceGenericDel<out T>();

        static void Main(string[] args)
        {
            Cat cat = new Cat("Маркиз");
            MaineCoon mc = new MaineCoon("Чейз");
                
            CovarianceGenericDel<MaineCoon> delMaineCoon = mc.GetMaineCoon;
            CovarianceGenericDel<Cat> delCat = delMaineCoon;

            Cat newCat = delCat();
            newCat.ShowInfo();

            Console.ReadKey();
        }
    }
}
