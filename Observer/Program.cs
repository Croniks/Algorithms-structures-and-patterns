using System;
using System.Collections.Generic;

namespace Observer
{
    interface IObservable
    {
        void AddObserver(IObserver o);
        void RemoveObserver(IObserver o);
        void NotifyObservers();
    }

    interface IObserver
    {
        void Update();
    }

    class StockInfo
    {
        public double USD { get; set; }
        public double EUR { get; set; }
    }

    class Stock : IObservable
    {
        public StockInfo SInfo { get; private set; }
        List<IObserver> observers;
        Random rnd;

        public Stock()
        {
            SInfo = new StockInfo();
            observers = new List<IObserver>();
            rnd = new Random();
        }

        public void AddObserver(IObserver o)
        {
            observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            observers.Remove(o);
        }

        public void NotifyObservers()
        {
            foreach(IObserver o in observers)
                o.Update();
        }

        public void Market()
        {
            SInfo.USD = rnd.Next(39, 60);
            SInfo.EUR = rnd.Next(49, 70);
            NotifyObservers();
        }
    }
    
    class Broker : IObserver
    {
        public string Name { get; private set; }
        Stock stock; 

        public Broker(string name, Stock stck)
        {
            Name = name;
            stock = stck;
            stock.AddObserver(this);
        }
         
        public void Update()
        {
            if(stock is null)
            {
                Console.WriteLine($"Брокер {Name} в данный момент не торгует!");
                return;
            }

            if(stock.SInfo.USD >= 50)
                Console.WriteLine($"Брокер {Name} продает доллары! " +
                    $"Текущий курс: доллар - {stock.SInfo.USD}");
            else
                Console.WriteLine($"Брокер {Name} покупает доллары! " +
                    $"Текущий курс: доллар - {stock.SInfo.USD}");
        }

        public void StopTrade()
        {
            stock.RemoveObserver(this);
            stock = null;
        }
    }

    class Bank : IObserver
    {
        public string Name { get; private set; }
        Stock stock;

        public Bank(string name, Stock stck)
        {
            Name = name;
            stock = stck;
            stock.AddObserver(this);
        }

        public void Update()
        {
            if (stock is null)
            {
                Console.WriteLine($"Банк {Name} в данный момент не торгует!");
                return;
            }

            if (stock.SInfo.EUR >= 60)
                Console.WriteLine($"Банк {Name} продает евро! " +
                    $"Текущий курс: евро - {stock.SInfo.EUR}");
            else
                Console.WriteLine($"Банк {Name} покупает евро! " +
                    $"Текущий курс: евро - {stock.SInfo.EUR}");
        }

        public void StopTrade()
        {
            stock.RemoveObserver(this);
            stock = null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Stock stock = new Stock();

            Broker brokerIvan = new Broker("Иван", stock);
            Bank bankSber = new Bank("Сбербанк", stock);
            
            stock.Market();
            Console.WriteLine(new string('-', 55));

            stock.Market();
            Console.WriteLine(new string('-', 55));

            stock.Market();
            Console.WriteLine(new string('-', 55));

            brokerIvan.StopTrade();

            Console.WriteLine(new string('=', 55));

            stock.Market();
            stock.Market();

            Console.ReadKey();
        }
    }
}
