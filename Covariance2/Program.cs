using System;


namespace Covariance2
{
    interface SomeInterface<out T>
    {
        void ShowTypeT();
    }

    class ClassImplementingInterface<T> : SomeInterface<T>
    {
        public void ShowTypeT() { Console.WriteLine(typeof(T)); }
    }

    class A { }
    class B : A { }


    class Program
    {
        static void Main(string[] args)
        {
            SomeInterface<A> a = new ClassImplementingInterface<A>();
            SomeInterface<B> b = new ClassImplementingInterface<B>();

            SomeInterface<A>[] arr = new SomeInterface<A>[]
                {
                    new ClassImplementingInterface<B>(),
                    new ClassImplementingInterface<A>()
                };

            foreach (var obj in arr)
                obj.ShowTypeT();

            Console.ReadKey();
        }
    }
}