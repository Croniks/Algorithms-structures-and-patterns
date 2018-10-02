using System;
using System.Collections;
using System.Collections.Generic;


namespace DoublyLinkedList
{
    class Program
    {
        class Node<T>
        {
            public T Data { get; }
            public Node<T> Next { get; set; }
            public Node<T> Previous { get; set; }
            public Node(T data) { Data = data; }
        }

        class DoublyLinkedList<T> 
        {
            private Node<T> start;
            private Node<T> end;
            private int count = 0;
            
            public bool IsNull { get { return count == 0; } }
            public int Count { get { return count; } }
            public T First { get { return start.Data; } }
            public T Last { get { return end.Data; } }
            
            public void Add(T data)
            {
                Node<T> node = new Node<T>(data);

                if(start != null)
                {
                    Node<T> temp = start;

                    while(temp.Next != null)
                        temp = temp.Next;

                    temp.Next = node;
                    node.Previous = temp;
                    end = node;
                }
                else
                    start = end = node;

                count++;
            }

            public void AppendFirst(T data)
            {
                Node<T> node = new Node<T>(data);

                if(start != null)
                {
                    node.Next = start;
                    start.Previous = node;
                    start = node;
                }
                else
                    start = end = node;

                count++;
            }

            public bool Remove(T data)
            {
                Node<T> temp = start;

                while(temp != null)
                {
                    if (temp.Data.Equals(data))
                    {
                        if(count > 1)
                        {
                            if (temp != start)
                            { 
                                temp.Previous.Next = temp.Next;
                                temp.Next.Previous = temp.Previous;
                            }
                            else
                                start = temp.Next;
                        }
                        else
                            start = end = null;
                        
                        count--;
                        return true;
                    }

                    temp = temp.Next;
                }
                
                return false;
            }

            public bool Contains(T data)
            {
                Node<T> temp = start;

                while(temp != null)
                {
                    if(temp.Data.Equals(data))
                        return true;

                    temp = temp.Next;
                }

                return false;
            }
                
            public IEnumerable GetEnumerator(bool reverse=false)
            {
                Node<T> temp;
                
                if(!reverse)
                {
                    temp = start;
                    while (temp != null)
                    {
                        yield return temp.Data;
                        temp = temp.Next;
                    }
                    yield break;
                }
                else
                {
                    temp = end;
                    while (temp != null)
                    {
                        yield return temp.Data;
                        temp = temp.Previous;
                    }
                    yield break;
                }
            }
        }
        
        static void Main(string[] args)
        {
            DoublyLinkedList<string> list = new DoublyLinkedList<string>();

            list.Add("Два");
            list.Add("Три");
            list.Add("Четыре");
            list.Add("Пять");
            list.AppendFirst("Раз");
            
            foreach (var s in list.GetEnumerator())
                Console.Write(s + " ");

            Console.WriteLine();

            foreach (var s in list.GetEnumerator(true))
                Console.Write(s + " ");

            Console.WriteLine();
            Console.WriteLine(list.Count);

            if(list.Contains("Три"))
                list.Remove("Три");

            if(!list.IsNull)
                Console.WriteLine(list.Count);

            foreach (var s in list.GetEnumerator())
                Console.Write(s + " ");

            Console.ReadKey();
        }
    }
}
