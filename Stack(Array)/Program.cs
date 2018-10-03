using System;


namespace Stack_Array
{
    class Program
    {
        class Stack<T>
        {
            const int startSize = 5;
            T[] items;
            int count;

            public int ContainerLength { get { return items.Length; } }
            public int Count { get{ return count; } }
            public bool IsNull { get{ return count == 0; } }

            public Stack() { items = new T[startSize]; }
            public Stack(int length) { items = new T[length]; }

            public void Push(T item)
            {
                if(count == items.Length)
                    Resize(items.Length + startSize);

                items[count++] = item;
            }

            public T Pop()
            {
                if(IsNull)
                    throw new InvalidOperationException("Stack is empty");

                T item = items[--count];
                items[count] = default(T);

                if(count > 0 && count < items.Length - startSize)
                    Resize(items.Length - startSize);
                
                return item;
            }

            public T Peek()
            {
                if (IsNull)
                    throw new InvalidOperationException("Stack is empty");

                return items[count-1];
            }

            public void Resize(int max)
            {
                T[] temp = new T[max];

                for(int i=0; i < items.Length; i++)
                    temp[i] = items[i];
                
                items = temp;
            }
        }
        
        static void Main(string[] args)
        {
            try
            {
                Stack<string> programms = new Stack<string>();
                
                programms.Push("Programm_№1");
                programms.Push("Programm_№2");
                programms.Push("Programm_№3");
                programms.Push("Programm_№4");
                programms.Push("Programm_№5");
                programms.Push("Programm_№6");
                programms.Push("Programm_№7");

                Console.WriteLine(programms.ContainerLength);
                Console.WriteLine(programms.Peek());
                Console.WriteLine(programms.Pop());
                Console.WriteLine(programms.Peek());
                Console.WriteLine(programms.Pop());
                Console.WriteLine(programms.Pop());
                Console.WriteLine(programms.Peek());
                Console.WriteLine(programms.ContainerLength);
            }
            catch(InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}
