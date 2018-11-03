using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LinkedList
{
    class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }

        public Node(T data) { Data = data; }
    }

    class LinkedList<T> : IEnumerable<T>
    {
        Node<T> first;
        Node<T> last;
        int count;
        
        public int Count { get { return count; } }
        public T First { get { return first.Data; } }
        public T Last { get { return last.Data; } }
        public bool isEmpty { get { return count == 0; } }

        public bool Add(T data)
        {
            Node<T> node = new Node<T>(data);

            if (first != null)
            {
                last.Next = node;
                last = node;
            }
            else
                first = last = node;
            
            count++;
            return true;
        }

        public T Pop()
        {
            Node<T> current = first;

            if(count > 1)
            { 
                first = first.Next;
                count--;
            }
            else
            { 
                first = last = null;
                count = 0;
            }

            return current.Data;
        }

        public bool Remove(T data)
        {
            Node<T> current, previous;
            current = previous = first;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    if (count > 1)
                    {
                        if(current == first)
                            first = first.Next;
                        else
                            previous.Next = current.Next;
                    }
                    else
                    {
                        first = last = null;
                        count = 0;
                    }

                    count--;
                    return true;
                }
                else
                {
                    previous = current;
                    current = current.Next;
                }
            }

            return false;
        }
        
        public bool Clear()
        {
            first = null;
            last = null;
            count = 0;

            return true;
        }

        public bool Contains(T data)
        {
            Node<T> current = first;

            while(current != null)
            {
                if(current.Data.Equals(data))
                    return true;
                current = current.Next;
            }    
            
            return false;
        }

        public bool AppendFirst(T data)
        {
            Node<T> node = new Node<T>(data);

            if(first != null)
            {
                node.Next = first;
                first = node;
            }
            else
                first = last = node;
            
            count++;
            return true;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = first;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<string> myList = new LinkedList<string>();
            myList.Add("Ford");
            myList.Add("Reno");
            myList.Add("Nissan");
            myList.Add("Fiat");

            myList.Pop();
            myList.AppendFirst("Ford");

            foreach (string company in myList.Take(10))
            {
                Console.WriteLine(company);
            }
            
            Console.WriteLine(myList.Contains("Reno"));
            Console.WriteLine(myList.Contains("BMW"));
            Console.WriteLine(myList.Count);
            myList.Clear();

            Console.WriteLine(myList.Count);

            Console.ReadKey();
        }
    }
}
