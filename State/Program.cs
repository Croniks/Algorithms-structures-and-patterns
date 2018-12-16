using System;


namespace State
{
    enum State
    {
        PatrolSTate,
        ChaseState,
        FightState,
    }

    interface IState
    {
        void PerformAction(bool flag = false);
    }
    
    class PatrolState : IState
    {
        Guardian guardian;

        public PatrolState(Guardian guardian) { this.guardian = guardian; }

        public void PerformAction(bool flag = false)
        {
            if (flag)
            { 
                guardian.State = new ChaseState(guardian);
                return;
            }

            Console.WriteLine("Патрулирую!");
        }
    }

    class ChaseState : IState
    {
        Guardian guardian;

        public ChaseState(Guardian guardian) { this.guardian = guardian; }

        public void PerformAction(bool flag = false)
        {
            if (flag)
            {
                guardian.State = new FightState(guardian);
                return;
            }

            Console.WriteLine("Преследую!");
        }
    }

    class FightState : IState
    {
        Guardian guardian;

        public FightState(Guardian guardian) { this.guardian = guardian; }

        public void PerformAction(bool flag = false)
        {
            if (flag)
            {
                guardian.State = new PatrolState(guardian);
                return;
            }
            
            Console.WriteLine("Дерусь!");
        }
    }
    
    class Guardian
    {
        public IState State { get; set; }

        public Guardian(IState state=null) { State = state ?? new PatrolState(this); }

        public void PerformAction(bool flag=false)
        {
            State.PerformAction(flag);
        }
    }
     
    struct SomeStruct {  public static int dds ; }

    class Program
    {
        
        static void Main(string[] args)
        {
            Guardian guardian = new Guardian();
            
            guardian.PerformAction();
            guardian.PerformAction();
            guardian.PerformAction(true);
            guardian.PerformAction();
            guardian.PerformAction(true);
            guardian.PerformAction();
            guardian.PerformAction();
            guardian.PerformAction(true);
            guardian.PerformAction();
            
            Console.ReadKey();
        }
    }
}