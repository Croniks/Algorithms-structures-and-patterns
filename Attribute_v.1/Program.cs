using System;
using System.Reflection;


namespace Attribute_v._1
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = true, Inherited = true)]
    public class TestAttribute : Attribute
    {
        private readonly string property1;
        private readonly string property2;

        public string Property1 { get { return property1; } }
        public string Property2 { get { return property2; } }

        public TestAttribute(string str1, string str2)
        {
            property1 = str1;
            property2 = str2;
        }

        public void PrintProperties()
        {
            Console.WriteLine($"Property1 = {property1}, " +
                $"Property2 = {property2}");
        }
    }

    [Test("Hello", "world!")]
    [Test("Hello", "again!")]
    public class BaseClass
    {
        public string Name { get; set; }

        public BaseClass(string name = "StandartBaseClass")
        {
            Name = name;
        }
    }

    public class DerivedClass
    {
        public string Name { get; set; }

        public DerivedClass(string name = "StandartDerivedClass")
        {
            Name = name;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BaseClass bc = new BaseClass();
            DerivedClass dc = new DerivedClass();
            
            var type1 = typeof(BaseClass);
            var type2 = typeof(DerivedClass);
            
            object[] attributes = type1.GetCustomAttributes(typeof(TestAttribute), true);

            if (attributes.GetLength(0) != 0)
            {

                foreach (TestAttribute attribute in attributes)
                {
                    Console.WriteLine(attribute.Property1);
                    Console.WriteLine(attribute.Property2);
                    attribute.PrintProperties();
                }
            }

            Console.ReadKey();
        }
    }
}
