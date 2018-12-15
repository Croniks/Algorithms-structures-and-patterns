using System;
using System.Collections;
using System.Collections.Generic;


namespace GenericDelegate
{
    class MyCollection<T> : IEnumerable<T>
    {
        public delegate bool Contains(T val);
        public delegate bool SearchDelegate(T val1, T val2 = default(T));

        SearchDelegate searchDelegate;

        List<T> _items;
        int _current;
        public int Count { get; private set; }

        public MyCollection() { _items = new List<T>(); }

        public void AddItem(T item) { _items.Add(item); Count++; }
        public void RemoveItem(T item) { _items.Remove(item); Count--; }
        
        IEnumerator IEnumerable.GetEnumerator() { return ((IEnumerable<T>)this).GetEnumerator(); }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            _current = 0;
            while(_current < Count)
                yield return _items[_current];
        }
        
        public int FindIndex(Contains pointer)
        {
            for (int i=0; i < Count; i++)
                if (pointer(_items[i]))
                    return i;
            
            return -1;
        }

        public int FindIndex(T item)
        {
            for (int i = 0; i < Count; i++)
                if (_items[i].Equals(item))
                    return i;

            return -1;
        }

        public void SetSearchPointer(SearchDelegate pointer) { searchDelegate = pointer; }

        public int FindIndexUsingSearchDelegate(T k)
        {
            for (int i = 0; i < Count; i++)
                if (searchDelegate(_items[i], k))
                    return i;
            
            return -1;
        }
    }

    
    class Program
    {
        static void Main(string[] args)
        {
            MyCollection<int> intCollection = new MyCollection<int>();
          
            intCollection.AddItem(21);
            intCollection.AddItem(76);
            intCollection.AddItem(38);

            int x = 1;
            Console.WriteLine(intCollection.FindIndex(n => n == x));
            
            x = 21;
            Console.WriteLine(intCollection.FindIndex(n => n == x));

            x = 76;
            Console.WriteLine(intCollection.FindIndex(n => n == x));

            Console.WriteLine(new string('-', 30));

            intCollection.SetSearchPointer((n, k) => n == k);

            Console.WriteLine(intCollection.FindIndexUsingSearchDelegate(1));
            Console.WriteLine(intCollection.FindIndexUsingSearchDelegate(21));
            Console.WriteLine(intCollection.FindIndexUsingSearchDelegate(76));

            Console.WriteLine();
            Console.WriteLine(new string('=', 30));

            MyCollection<string> stringCollection = new MyCollection<string>();

            stringCollection.AddItem("  Hellow, ");
            stringCollection.AddItem("   uncle ");
            stringCollection.AddItem(" Ben's!   ");

            stringCollection.SetSearchPointer((n, k) => n.Trim() == k.Trim());

            Console.WriteLine(stringCollection.FindIndexUsingSearchDelegate("    Hellow, "));
            Console.WriteLine(stringCollection.FindIndexUsingSearchDelegate(" uncle    "));
            Console.WriteLine(stringCollection.FindIndexUsingSearchDelegate("  Ben's!   "));
            
            Console.ReadKey();
        }
    }    
}