using System;
using System.Collections;
using System.Collections.Generic;


namespace LinkedList
{
    public class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public Node<T> Next { get; set; }
    }

    public class LinkedList<T> : IEnumerable<T>
    {
        Node<T> first;
        Node<T> last;
        int count;

        public int Count { get { return count; } }
        Node<T> First { get { return first; } }
        Node<T> Last { get { return last; } }

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

            if (count > 1)
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
                        if (current == first)
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


            Console.ReadKey();
        }
    }
}