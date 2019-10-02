using System;


namespace Action_Predicate_Func
{
    class Program
    {
        class SomeCollection
        {
            private int[] numbers;

            public SomeCollection()
            {
                numbers = new int[35];
                for(int i=0; i < numbers.Length; i++)
                {
                    numbers[i] = i;
                }
            }

            public int[] FindNumbers(Predicate<int> op)
            {
                int index = 0;
                int quantity = 10;
                int[] result = new int[quantity];
                
                for (int i = 0; i < numbers.Length; i++)
                {
                    if(op(numbers[i]))
                    { 
                        if(result.Length == index + 1)
                        {
                            quantity += 10;
                            int[] intermediate = new int[quantity];
                            result.CopyTo(intermediate, 0);
                            result = intermediate;
                        }

                        result[index++] = numbers[i];
                    }
                }
                
                return result;
            }
        }

        
        static void Main(string[] args)
        {
            int[] numbers;

            SomeCollection collection = new SomeCollection();

            ////numbers = collection.FindNumbers(x => x > 10);
            //numbers = collection.FindNumbers(x => x == 13);
            //numbers = collection.FindNumbers(x => x % 2 == 0);
            numbers = collection.FindNumbers(x => x % 2 != 0);

            foreach (var n in numbers)
                if(n != 0)
                    Console.Write(n + " ");

            Console.ReadKey();
        }
    }
}