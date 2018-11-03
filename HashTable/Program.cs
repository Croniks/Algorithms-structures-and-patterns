using System;
using System.Collections;
using System.Collections.Generic;


namespace HashTable
{
    public struct Item<K, V> 
    {
        public K Key { get; set; }

        public V Value { get; set; }
        
        public Item(K key, V value)
        {
            if (string.IsNullOrEmpty(key.ToString()))
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (string.IsNullOrEmpty(value.ToString()))
            {
                throw new ArgumentNullException(nameof(value));
            }

            Key = key;
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
    
    public class CustomHashTable<K, V> : IEnumerable<Item<K, V>>
    {  
        int capacity; int filling;
        Item<K, V>[] data;

        public Item<K, V> this[K key]
        {
            get
            {
                int index = SearchIndex(key);
                if (index != -1) return data[index];
                else throw new ArgumentException("Отсутствует элемент с данным ключом!");
            }
        }

        public CustomHashTable(int length=100) { data = new Item<K, V>[capacity=length]; }
        
        public void Insert(K key, V value)
        {
            if(filling == capacity)
                throw new InvalidOperationException("Хеш таблица заполнена!");
            
            if (string.IsNullOrEmpty(key.ToString()))
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (string.IsNullOrEmpty(value.ToString()))
            {
                throw new ArgumentNullException(nameof(value));
            }

            Item<K, V> item = new Item<K, V>(key, value);
            int hashIndex = GetHash(key);

            if (!data[hashIndex].Equals(default(Item<K, V>)))
            {
                int wantedIndex = hashIndex + 1;

                while (wantedIndex < capacity && !data[wantedIndex].Equals(default(Item<K, V>)))
                {
                    if (data[wantedIndex].Key.Equals(key))
                    {
                        throw new ArgumentException($"Хеш-таблица уже содержит элемент с ключом {key}. " +
                            $"Ключ должен быть уникален.", nameof(key));
                    }
                    
                    wantedIndex++;
                }
                
                if (wantedIndex >= capacity)
                {
                    wantedIndex = hashIndex - 1;

                    while (wantedIndex >= 0 && !data[wantedIndex].Equals(default(Item<K, V>)))
                    {
                        if (data[wantedIndex].Key.Equals(key))
                        {
                            throw new ArgumentException($"Хеш-таблица уже содержит элемент с ключом {key}. " +
                                $"Ключ должен быть уникален.", nameof(key));
                        }

                        wantedIndex--;
                    }
                    
                    data[wantedIndex] = item;
                    filling++;
                }
                else
                {
                    data[wantedIndex] = item;
                    filling++;
                }
            }
            else
            {
                data[hashIndex] = item;
                filling++;
            }
        }

        public Item<K, V> Search(K key)
        {
            int index = SearchIndex(key);

            if(index != -1)
                return data[index];
            else
                throw new ArgumentException("Отсутствует элемент с данным ключом!");
        }

        public void Delete(K key)
        {
            int index = SearchIndex(key);

            if (index != -1)
                data[index] = default(Item<K, V>);
        }

        private int SearchIndex(K key)
        {
            int hashIndex = GetHash(key);
            int wantedIndex = hashIndex;

            while (wantedIndex < capacity)
            {
                if (data[wantedIndex].Equals(default(Item<K, V>)))
                { 
                    wantedIndex++;
                    continue;
                }

                if (!data[wantedIndex].Key.Equals(key))
                {
                    wantedIndex++;
                    continue;
                }
                else
                    return wantedIndex;
            }

            wantedIndex = hashIndex - 1;

            while (wantedIndex >= 0)
            {
                if (data[wantedIndex].Equals(default(Item<K, V>)))
                {
                    wantedIndex--;
                    continue;
                }

                if (!data[wantedIndex].Key.Equals(key))
                {
                    wantedIndex--;
                    continue;
                }
                else
                    return wantedIndex;
            }
            
            return -1;
        }

        private int GetHash(K key)
        {
            return Math.Abs(key.GetHashCode() % (capacity - 1));
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<Item<K, V>> IEnumerable<Item<K, V>>.GetEnumerator()
        {
            for(int i=0; i < capacity; i++)
            {
                if(!data[i].Equals(default(Item<K, V>)))
                    yield return data[i];
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //CustomHashTable<string, string> ht = new CustomHashTable<string, string>(3);

            //ht.Insert("Кладбище домашних животных", "Стивен Кинг");
            //ht.Insert("Тёмная башня", "Стивен Кинг");
            //ht.Insert("Владычица озера", "Анджей Сапковский");
            //ht.Insert("Крещение огнём", "Анджей Сапковский");
            //ht.Insert("Башная ласточки", "Анджей Сапковский");

            int length = 200;

            CustomHashTable<string, int> ht = new CustomHashTable<string, int>(length);

            Random rnd = new Random();

            string testKey = "";

            for (int i = 0; i < length; i++)
            {
                string str = "";

                for(int j=0; j < 10; j++)
                {
                    str += (char)rnd.Next(65, 124);
                }

                if (i == 0)
                    testKey = str;

                ht.Insert(str, rnd.Next(1, 101));
            }

            foreach (var pair in ht)
            {
                Console.WriteLine(pair.Key + " : " + pair.Value);
            }

            Console.WriteLine(new string('-', 30));

            Console.WriteLine(ht[testKey]);
            Console.WriteLine(ht.Search(testKey));

            ht.Delete(testKey);
            
            try
            {
                Console.WriteLine(ht.Search(testKey));
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            Console.ReadKey();
        }
    }
}
