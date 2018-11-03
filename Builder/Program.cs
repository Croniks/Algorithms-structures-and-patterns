using System;
using System.Text;

namespace Builder
{
    class Onion {}
    class Dill {}
    class Carrot {}
    class Potato {}
    
    class Soup
    {
        public Onion Onion { get; set; }
        public Dill Dill { get; set; }
        public Carrot Carrot { get; set; }
        public Potato Potato { get; set; }
        
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if(Onion != null)
                sb.Append("Лук \n");
            if(Dill != null)
                sb.Append("Укроп \n");
            if (Carrot != null)
                sb.Append("Морковь \n");
            if(Potato != null)
                sb.Append("Картофель \n");
            
            return sb.ToString();
        }
    }

    abstract class SoupBuilder
    {   
        public Soup Soup { get; private set; }

        public SoupBuilder()
        {
            Soup = new Soup();
        }

        public abstract void SetOnion();
        public abstract void SetDill();
        public abstract void SetCarrot();
        public abstract void SetPotato();
    }

    class CarrotSoupBuilder : SoupBuilder
    {
        public override void SetOnion() { Soup.Onion = new Onion(); }
        public override void SetDill() { Soup.Dill = new Dill(); }
        public override void SetCarrot() { Soup.Carrot = new Carrot(); }
        public override void SetPotato() { }
    }

    class PotatoSoupBuilder : SoupBuilder
    {
        public override void SetOnion() { Soup.Onion = new Onion(); }
        public override void SetDill() { Soup.Dill = new Dill(); }
        public override void SetCarrot() {}
        public override void SetPotato() { Soup.Potato = new Potato(); }
    }

    class Cook
    {
        public Soup ToCook(SoupBuilder soupBuilder)
        {
            soupBuilder.SetOnion();
            soupBuilder.SetDill();
            soupBuilder.SetCarrot();
            soupBuilder.SetPotato();

            return soupBuilder.Soup;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Cook cook = new Cook();

            Soup soup1 = cook.ToCook(new CarrotSoupBuilder());
            Soup soup2 = cook.ToCook(new PotatoSoupBuilder());

            Console.WriteLine(soup1);
            Console.WriteLine(soup2);

            Console.ReadLine();
        }
    }
}
