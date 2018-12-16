using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace TestCollections
{
    class TrimCollection : Dictionary<int, string>
    {
        public new string this[int index]
        {
            get { return base[index]; }
            set { value = value.Trim(); base[index] = value; }
        }
        
        public new void Add(int key, string value)
        {
            value = value.Trim();
            base.Add(key, value);
        }
    }

    class MyCollection<T> : IEnumerable<T>
    {
        T[] array = new T[10];
        int count = 0;

        public int Count { get {return count; } }

        public void Add(T item)
        {
            if (count == array.Length)
            {
                T[] newArray = new T[array.Length * 2];
                array.CopyTo(newArray, 0);
                array = newArray;
            }
            
            array[count++] = item;
        }

        public bool Remove(T item)
        {
            int deletedIndex = -1;
            int length = array.Length;
            
            for(int i=0; i < length; i++)
            {
                if(array[i].Equals(item))
                {
                    deletedIndex = i;
                    break;
                }
            }
            
            if(deletedIndex != -1)
            {
                for(int i=deletedIndex; i < count - 1; i++)
                    array[i] = array[i + 1];

                array[--count] = default(T);
                return true;
            }
            
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i=0; i < count; i++)
                yield return array[i];
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
    }

    class Program
    {
        static IEnumerable<int> Generator(int max)
        {
            Random rnd = new Random();
            
            while(true) yield return rnd.Next(max);
        }
        
        static void Main(string[] args)
        {
            foreach(int number in Generator(100).Take(10))
                Console.WriteLine(number);

            Console.WriteLine(new string('-', 20));

            MyCollection<int> col = new MyCollection<int>();

            col.Add(1);
            col.Add(2);
            col.Add(3);
            col.Add(4);
            col.Add(5);

            foreach (int number in col)
                Console.WriteLine(number);
            
            col.Remove(4);
            Console.WriteLine(new string('-', 20));
            
            foreach (int number in col)
                Console.WriteLine(number);

            Console.WriteLine(new string('=', 38));

            Hashtable ht = new Hashtable();
            
            ht.Add("key1", 5);
            ht.Add(2, "value2");
            ht.Add(true, new int[3]{1, 2, 3});
            
            foreach(DictionaryEntry pair in ht)
                Console.WriteLine($"Ключ : {pair.Key}, значение : {pair.Value};");

            Console.WriteLine(new string('-', 38));
            
            Dictionary<object, object> dict = new Dictionary<object, object>();
            
            dict.Add("key1", 5);
            dict.Add(2, "value2");
            dict.Add(true, new int[3] { 1, 2, 3 });
            
            foreach (KeyValuePair<object, object> pair in dict)
                Console.WriteLine($"Ключ : {pair.Key}, значение : {pair.Value};");

            Console.WriteLine(new string('-', 38));

            TrimCollection trimCollection = new TrimCollection();

            trimCollection.Add(0, "   Hellow");
            trimCollection.Add(1, "   World   ");
            trimCollection[2] = "  !   ";
            
            Console.WriteLine(trimCollection[0]);
            Console.WriteLine(trimCollection[1]);
            Console.WriteLine(trimCollection[2]);
            
            Console.ReadKey();
        }
    }
}