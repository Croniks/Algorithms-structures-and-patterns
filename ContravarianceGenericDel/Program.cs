using System;


namespace ContravarianceGenericDel
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
        
        public virtual void ShowInfo() { Console.WriteLine($"{Name} : {Breed}"); }
    }
    
    class MaineCoon : Cat
    {
        public MaineCoon(string name = "Мейнкунчик")
        {
            Name = name;
            Breed = "Мейн Кун";
        }
        
        public override void ShowInfo() { Console.WriteLine($"{Name} : {Breed}"); }
    }
    
    
    class Program
    {
        private delegate void CovarianceGenericDel<in T>(T animal) where T : Cat;

        private static void ShowCatInfo(Cat cat) { cat.ShowInfo(); }
        private static void ShowMaineCoonInfo(MaineCoon mc) { mc.ShowInfo(); }

        static void Main(string[] args)
        {
            Cat cat = new Cat("Маркиз");
            MaineCoon mc = new MaineCoon("Чейз");

            CovarianceGenericDel<MaineCoon> delMaineCoon = ShowMaineCoonInfo;
            delMaineCoon(mc);

            Console.WriteLine(new string('-', 15));

            CovarianceGenericDel<Cat> delCat = ShowCatInfo;

            delMaineCoon = delCat;
            delMaineCoon(mc);
            
            Console.ReadKey();
        }
    }
}
