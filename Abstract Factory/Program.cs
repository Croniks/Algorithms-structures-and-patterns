using System;

namespace Abstract_Factory
{
    public abstract class Ability1 { public abstract string GetDescription(); }

    public class Blizzard : Ability1
    {
        public override string GetDescription() { return "Ледяной дождь"; }
    }

    public class WindWalk : Ability1
    {
        public override string GetDescription() { return "Невидимость"; }
    }

    public abstract class Ability2 { public abstract string GetDescription(); }

    public class SummonWaterElemental : Ability2
    {
        public override string GetDescription() { return "Водный элементаль"; }
    }

    public class MirrorImage : Ability2
    {
        public override string GetDescription() { return "Иллюзии"; }
    }
        
    public abstract class HeroFactory
    {
        public abstract Ability1 CreateAbility1();
        public abstract Ability2 CreateAbility2();
    }

    public class ArcMageFactory : HeroFactory
    {
        public override Ability1 CreateAbility1() { return new Blizzard(); }
        public override Ability2 CreateAbility2() { return new SummonWaterElemental(); }
    }

    public class BladeMasterFactory : HeroFactory
    {
        public override Ability1 CreateAbility1() { return new WindWalk(); }
        public override Ability2 CreateAbility2() { return new MirrorImage(); }
    }

    public class Hero
    {
        public Ability1 abillity1;
        public Ability2 abillity2;

        public Hero(HeroFactory factory)
        {
            abillity1 = factory.CreateAbility1();
            abillity2 = factory.CreateAbility2();
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Hero hero1 = new Hero(new ArcMageFactory());
            Hero hero2 = new Hero(new BladeMasterFactory());

            Console.WriteLine(hero1.abillity1.GetDescription());
            Console.WriteLine(hero1.abillity2.GetDescription());

            Console.WriteLine(new string('-', 30));

            Console.WriteLine(hero2.abillity1.GetDescription());
            Console.WriteLine(hero2.abillity2.GetDescription());
            
            Console.ReadKey();
        }
    }
}


