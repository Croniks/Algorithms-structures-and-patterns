using System;
using System.Collections.Generic;


namespace Memento
{
    class Program
    {
        interface HeroSettings
        {
            int Patrons{ get; set; }
            int Lives{ get; set; }
        }
        
        class HeroMemento : HeroSettings
        {
            public int Patrons { get; set; }
            public int Lives { get; set; }
            
            public HeroMemento(int patrons, int lives)
            {
                Patrons = patrons;
                Lives = lives;
            }
        }

        class Hero : HeroSettings
        {
            public int Patrons { get; set; }
            public int Lives { get; set; }

            public Hero() { Patrons = 10; Lives = 3; }
            
            public void Shoot()
            {
                if (Patrons <= 0)
                {
                    Console.WriteLine("Кончились патроны!");
                    return;
                }

                Patrons--;
                Console.WriteLine($"Бдыщь!");    
            }

            public HeroMemento SaveState()
            {
                return new HeroMemento(Patrons, Lives);
            }

            public void RestoreState(HeroMemento memento)
            {
                Patrons = memento.Patrons;
                Lives = memento.Lives;
            }

            public void GetInfo() { Console.WriteLine($"Жизней: {Lives}, патронов : {Patrons}"); }
        }

        class KeeperMemento
        {
            public Stack<HeroMemento> History { get; private set; }
            
            public KeeperMemento() { History = new Stack<HeroMemento>(); }
        }


        static void Main(string[] args)
        {
            Hero hero = new Hero();
            KeeperMemento saves = new KeeperMemento();

            hero.GetInfo();
            hero.Shoot();
            hero.Shoot();
            hero.GetInfo();

            saves.History.Push(hero.SaveState());

            hero.Shoot();
            hero.Shoot();
            hero.GetInfo();

            hero.Shoot();
            hero.Shoot();

            hero.RestoreState(saves.History.Peek());
            hero.GetInfo();

            Console.ReadKey();
        }
    }
}