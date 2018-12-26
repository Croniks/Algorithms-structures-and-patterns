using System;


namespace Mediator
{
    abstract class Mediator
    {
        public abstract void Send(string msg, Actor actor);
    }
    
    class ConcreteMediator : Mediator
    {
        public Actor Visitor { get; set; }
        public Actor Cashier { get; set; }
        public Actor Cook { get; set; }

        public override void Send(string msg, Actor actor)
        {
            if(actor == Visitor)
                Cashier.Notify(msg);
            else if(actor == Cashier)
                Cook.Notify(msg);
            else
                Visitor.Notify(msg);
        }
    }
    
    abstract class Actor
    {
        protected Mediator mediator { get; set; }

        public Actor(Mediator mediator) { this.mediator = mediator; }

        public virtual void Send(string message) { mediator.Send(message, this); }
        public abstract void Notify(string message);
    }

    class Visitor : Actor
    {
        public Visitor(Mediator mediator) : base(mediator) { }
        public override void Notify(string message) { Console.WriteLine($"Посетитель: получил на кассе свой {message}!"); }
    }

    class Cashier : Actor
    {
        public Cashier(Mediator mediator) : base(mediator) { }
        public override void Notify(string message) { Console.WriteLine($"Кассир: поступил заказ на {message}!"); }
    }

    class Cook : Actor
    {
        public Cook(Mediator mediator) : base(mediator) { }
        public override void Notify(string message) { Console.WriteLine($"Повар: приготовил {message}!"); }
    }


    class Program
    {
        static void Main(string[] args)
        {
            ConcreteMediator mediator = new ConcreteMediator();

            Actor visitor = new Visitor(mediator);
            Actor cashier = new Cashier(mediator);
            Actor cook = new Cook(mediator);

            mediator.Visitor = visitor;
            mediator.Cashier = cashier;
            mediator.Cook = cook;

            visitor.Send("гамбургер");
            cashier.Send("Гамбургер");
            cook.Send("гамбургер");

            Console.ReadKey();
        }
    }
}