using System;
using System.Collections;
using System.Collections.Generic;


namespace Iterator
{
    class GamesCatalog<T> : IEnumerable<T>, IEnumerator<T>
    {
        List<T> _items;
        int _current;

        public int Count { get; private set; }
        public Object Current { get; }
        T IEnumerator<T>.Current { get{ return _items[_current]; } }

        public GamesCatalog() { _items = new List<T>(); _current = -1; }

        public void Dispose() { }

        public void AddGame(T game) { _items.Add(game); Count++; }

        public void RemoveGame(T game) { _items.Remove(game); Count--; }

        public bool MoveNext()
        {
            if(++_current < Count)
                return true;
            
            Reset();
            return false;
        }

        public void Reset() { _current = -1; }
        
        IEnumerator IEnumerable.GetEnumerator() { return ((IEnumerable<T>)this).GetEnumerator(); }
        
        IEnumerator<T> IEnumerable<T>.GetEnumerator(){ return this; }
    }

    
    class Program
    {
        static void Main(string[] args)
        {
            GamesCatalog<string> gc = new GamesCatalog<string>();

            gc.AddGame("The Witcher 3: Wild Hunt");
            gc.AddGame("Horizon Zero Dawn");
            gc.AddGame("Mortal Combat XL");

            foreach(string str in gc)
                Console.WriteLine(str);

            Console.WriteLine(new string('-', 30));

            foreach (string str in gc)
                Console.WriteLine(str);

            Console.WriteLine(new string('-', 30));

            foreach (string str in gc)
                Console.WriteLine(str);

            Console.ReadKey();
        }
    }
}
