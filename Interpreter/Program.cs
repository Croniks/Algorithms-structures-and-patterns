using System;
using System.Collections.Generic;


namespace Interpreter
{
    class Context
    {
        Dictionary<string, object> variables;
        
        public Context() { variables = new Dictionary<string, object>(); }

        public object GetVariable(string name) { return variables[name]; }
        public void SetVariable(string name, object value) { variables[name] = value; }
    }

    interface IInterpreter
    {
        object Interpret(Context context);
    }
    
    class Exprassion : IInterpreter
    {
        string name;

        public Exprassion(string name) { this.name = name; }

        public object Interpret(Context context)
        {
            return context.GetVariable(name);
        }
    }
    
    abstract class BinaryOperationExpration : IInterpreter
    {
        public Exprassion operand1;
        public Exprassion operand2;

        public BinaryOperationExpration(Exprassion operand1, Exprassion operand2)
        {
            this.operand1 = operand1;
            this.operand2 = operand2;
        }

        abstract public object Interpret(Context context);
    }

    class AdditionExprassion : BinaryOperationExpration
    {
        public AdditionExprassion(Exprassion operand1, Exprassion operand2) :
            base(operand1, operand2) {}

        public override object Interpret(Context context)
        {
            int x, y;
            Int32.TryParse(operand1.Interpret(context).ToString(), out x);
            Int32.TryParse(operand2.Interpret(context).ToString(), out y);
            
            return x + y;
        }
    }
    
    class ConcatenationExprassion : BinaryOperationExpration
    {
        public ConcatenationExprassion(Exprassion operand1, Exprassion operand2) : 
            base(operand1, operand2) {}

        public override object Interpret(Context context)
        { 
            return operand1.Interpret(context).ToString() + operand2.Interpret(context).ToString();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();

            context.SetVariable("string1", "Hellow");
            context.SetVariable("string2", " world!");
            context.SetVariable("number1", 6);
            context.SetVariable("number2", 4);
            context.SetVariable("string3", "4");

            IInterpreter stringConcatenation = new ConcatenationExprassion(
                    new Exprassion("string1"), new Exprassion("string2"));

            IInterpreter intAddition = new AdditionExprassion(
                     new Exprassion("number1"), new Exprassion("number2"));

            IInterpreter intStringConcatenation = new ConcatenationExprassion(
                    new Exprassion("number1"), new Exprassion("string2"));

            IInterpreter intStringAddition = new AdditionExprassion(
                    new Exprassion("number2"), new Exprassion("string3"));
            
            object result1 = stringConcatenation.Interpret(context);
            object result2 = intAddition.Interpret(context);
            object result3 = intStringConcatenation.Interpret(context);
            object result4 = intStringAddition.Interpret(context);
            
            Console.WriteLine("Результат №1: {0}", result1);
            Console.WriteLine("Результат №2: {0}", result2);
            Console.WriteLine("Результат №3: {0}", result3);
            Console.WriteLine("Результат №4: {0}", result4);
            
            Console.ReadKey();
        }
    }
}