using System;
using System.Collections;
using System.Collections.Generic;


namespace test
{
    struct User
    {
        public string name;
        public int age;

        public User(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {name}  Age: {age}");
        }
    }

    public class Class1
    {
        public string String1 { get{ return String1 = "String1";} private set {} } 
    }

    public class Class2
    {
        public string String2 { get { return String2 = "String2"; } private set {} }
    }

    enum State
    {
        THINKING = 0,
        SMILING = 1,
        SPEAKING = 2,
        WATCHING = 4,
        NODDING = 8
    }

    class Program
    {
        public static string returnString (object someObject)
        {
            if(string.IsNullOrEmpty(someObject.ToString()))
                return "Пусто!";
            return someObject.ToString();
        }

        public static bool IsInteger(ValueType da)
        {
            return da is Int32;
        }

        public static void TestString(string str)
        {
            str += " другая строка";
        }

        public struct SomeInt
        {
            Object obj;

            int x;
            public int X
            {
                get { return x; }
                set
                {
                    if(value == 0)
                        obj = null;
                    else
                        obj = default(Object);
                    X = value;
                }
            }

            public SomeInt(int x=0)
            {
                this.x = x;
               
                if(x != 0)
                    obj = default(Object);
                obj = null;
            }
        }

        static void Main(string[] args)
        {
            Hashtable ht = new Hashtable();
            Dictionary<int, string> dict = new Dictionary<int, string>();
            
            ht.Add(0, "Zero");
            ht.Add(1, "One");
            ht.Add(2, 3);
            
            int result = 2 + (int)ht[2];
            Console.WriteLine(result);

            ht[2] = "Three";
            Console.WriteLine(ht[2]);

            Console.WriteLine(new string('-', 30));

            foreach (DictionaryEntry item in ht)
            {
                Console.WriteLine(item.Key + " : " + item.Value);
            }

            string someString1 = "dada";
            string someString2 = "";
            int someInt = 5;

            Console.WriteLine(returnString(someString1));
            Console.WriteLine(returnString(someString2));
            Console.WriteLine(returnString(someInt));

            dict[2] = "Dsds";
            Console.WriteLine(dict[2]);

            Console.WriteLine(new string('-', 30));

            Class1 InstanceS1 = new Class1();

            Type S1 = InstanceS1.GetType();

            if("test.Class1" == InstanceS1.GetType().ToString())
                Console.WriteLine("!!!!");

            Console.WriteLine(new string('-', 30));
            Console.WriteLine(new string('-', 30));




            //dict.Add(0, "Zero");
            //dict.Add(1, "One");
            //dict.Add(2, "Two");

            //IEnumerator enumOfDict = dict.GetEnumerator();

            //enumOfDict.MoveNext();
            //enumOfDict.MoveNext();

            //KeyValuePair<int, string> one = (KeyValuePair<int, string>)enumOfDict.Current;

            //Console.WriteLine(one.Key + " : " + one.Value);

            //Console.WriteLine(new string('-', 30));

            //Console.WriteLine(4 % 32);
            //Console.WriteLine(33 % 32);
            //Console.WriteLine(63 % 32);
            //Console.WriteLine(65 % 32);

            //Console.WriteLine(new string('-', 30));

            //Object someObject = new Object();

            //Console.WriteLine(5.GetHashCode() % 32);
            //Console.WriteLine("Пять".GetHashCode() % 32);
            //Console.WriteLine(someObject.GetHashCode() % 32);

            Console.ReadKey();
        }
    }
}
