using System;


namespace CovarianceTest1
{
    interface SomeInterface<in T>
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

            SomeInterface<B>[] arr = new SomeInterface<B>[]
                {
                    new ClassImplementingInterface<B>(),
                    new ClassImplementingInterface<A>()
                };
            
            foreach(var obj in arr)
                obj.ShowTypeT();

            Console.ReadKey();
        }
    }
}