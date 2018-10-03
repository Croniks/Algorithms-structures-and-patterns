using System;
using System.Collections;
using System.Collections.Generic;


namespace Queue
{
    class Program
    {
        class Node<T>
        {
            public T Data { get; set; }
            public Node<T> Next { get; set; }

            public Node(T data) { Data = data; }
        }

        class Queue<T> : IEnumerable<T>
        {
            Node<T> first;
            Node<T> last;
            int count;

            public int Count { get { return count; } }
            public bool IsEmpty { get { return count == 0; } }

            public void Push(T data)
            {
                Node<T> node = new Node<T>(data);

                if(!IsEmpty)
                { 
                    last.Next = node;
                    last = node;
                }
                else
                    first = last = node;
                
                count++;
            }

            public T Pop()
            {
                if (IsEmpty)
                    throw new InvalidOperationException("Stack is empty!");

                Node<T> current = first;
                first = first.Next;

                count--;
                return current.Data;
            }

            public T Peek()
            {
                if (IsEmpty)
                    throw new InvalidOperationException("Stack is empty!");
                return first.Data;
            }

            public bool Contains(T data)
            {
                Node<T> current = first;

                while (current != null)
                {
                    if (current.Data.Equals(data))
                        return true;
                    current = current.Next;
                }

                return false;
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable)this).GetEnumerator();
            }

            IEnumerator<T> IEnumerable<T>.GetEnumerator()
            {
                Node<T> node = first;

                while (node != null)
                {
                    yield return node.Data;
                    node = node.Next;
                }
            }

        }

        static void Main(string[] args)
        {
            try
            {
                Queue<string> programms = new Queue<string>();

                programms.Push("Programm_№1");
                programms.Push("Programm_№2");
                programms.Push("Programm_№3");
                programms.Push("Programm_№4");
                programms.Push("Programm_№5");
                programms.Push("Programm_№6");
                programms.Push("Programm_№7");

                Console.WriteLine(programms.Pop());
                Console.WriteLine(new string('-', programms.Peek().Length));

                foreach (var p in programms)
                    Console.WriteLine(p);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}
