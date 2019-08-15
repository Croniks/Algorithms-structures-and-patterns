using System;


namespace Adapter
{
    interface IСombatUnit
    {
        void Attack();
    }

    interface IWorkUnit
    {
        void Mine();
        void AttackEnemy();
    }

    class Peasant : IWorkUnit
    {
        public void Mine()
        {
            Console.WriteLine("Добыча ресурсов!");
        }

        public void AttackEnemy()
        {
            Console.WriteLine("Удар киркой!");
        }
    }

    class PeasantAdapter : IСombatUnit
    {
        private Peasant _peasant;

        public PeasantAdapter(Peasant peasant)
        {
            _peasant = peasant;
        }

        public void Attack()
        {
            _peasant.AttackEnemy();
        }
    }

    class Footman : IСombatUnit
    {
        public void Attack()
        {
            Console.WriteLine("Удар мечом!");
        }
    }
    

    class Player
    {
        public void SelectedUnitAttack(IСombatUnit unit)
        {
            unit.Attack();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            Footman footman = new Footman();
            player.SelectedUnitAttack(footman);

            Peasant peasant = new Peasant();
            PeasantAdapter adapter = new PeasantAdapter(peasant);
            player.SelectedUnitAttack(adapter);

            Console.ReadKey();
        }
    }
}