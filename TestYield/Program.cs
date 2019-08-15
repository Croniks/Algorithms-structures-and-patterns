using System;
using System.Collections.Generic;


namespace TestYield
{
    class Program
    {
        private static IEnumerable<int> GetOddNumbers()
        {
            var previous = 0;
            while (true)
            { 
                if(previous < 100)
                { 
                    if (++previous % 2 != 0)
                        yield return previous;
                }
                else
                    yield break;
            }
        }

        static void Main(string[] args)
        {
            IEnumerable<int> someCollection = GetOddNumbers();
            
            IEnumerator<int> iteratorOfSomeCollection = someCollection.GetEnumerator();

            //Console.WriteLine(iteratorOfSomeCollection.Current);
            //iteratorOfSomeCollection.MoveNext();
            //Console.WriteLine(iteratorOfSomeCollection.Current);
            //iteratorOfSomeCollection.MoveNext();
            //Console.WriteLine(iteratorOfSomeCollection.Current);
            //iteratorOfSomeCollection.MoveNext();
            //Console.WriteLine(iteratorOfSomeCollection.Current);
            //iteratorOfSomeCollection.MoveNext();

            foreach (var n in GetOddNumbers())
                Console.WriteLine(n);
            
            Console.ReadKey();
        }
    }
}