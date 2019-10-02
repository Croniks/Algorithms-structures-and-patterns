using System;
using System.Collections.Generic;


namespace Interpreter
{
    enum VariableType { INT, STRING }

    struct TypeValue
    {
        public VariableType Type { get; private set; }
        public string Value { get; private set; }

        public TypeValue(VariableType type, string value)
        {
            Type = type;
            Value = value;
        }
    }
    
    class Context
    {
        Dictionary<string, TypeValue> variables;
        
        public Context() { variables = new Dictionary<string, TypeValue>(); }

        public TypeValue GetVariable(string name) { return variables[name]; }

        public void SetVariable(string name, TypeValue typeValue)
        {
            if(variables.ContainsKey(name))
                variables[name] = typeValue;
            else
                variables.Add(name, typeValue);
        }
    }

    interface IInterpreter
    {
        TypeValue Interpret(Context context);
    }
    
    class Expression : IInterpreter
    {
        string name;
        
        public Expression(string name) { this.name = name; }

        public TypeValue Interpret(Context context)
        {
            return context.GetVariable(name);
        }
    }
    
    abstract class BinaryOperationExpression : IInterpreter
    {
        public Expression operand1;
        public Expression operand2;

        public BinaryOperationExpression(Expression operand1, Expression operand2)
        {
            this.operand1 = operand1;
            this.operand2 = operand2;
        }

        abstract public TypeValue Interpret(Context context);
    }

    class PlusExpression : BinaryOperationExpression
    {
        public PlusExpression(Expression operand1, Expression operand2) :
            base(operand1, operand2) {}
        
        public override TypeValue Interpret(Context context)
        {
            if(operand1.Interpret(context).Type == operand2.Interpret(context).Type)
            {
                if(operand1.Interpret(context).Type == VariableType.INT)
                {
                    int x, y;

                    Int32.TryParse(operand1.Interpret(context).Value.ToString(), out x);
                    Int32.TryParse(operand2.Interpret(context).Value.ToString(), out y);

                    return new TypeValue(VariableType.INT, (x + y).ToString());
                }
                else if(operand1.Interpret(context).Type == VariableType.STRING)
                {
                    string a, b;

                    a = operand1.Interpret(context).Value;
                    b = operand2.Interpret(context).Value;
                    
                    return new TypeValue(VariableType.STRING, (a + b));
                }
            }
            else
            {
                Console.WriteLine("Нельзя выполнить операцию '+' с операндами разных типов!");
            }

            return default(TypeValue);
        }
    }
    
    
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();

            int x = 3;
            int y = 2;

            context.SetVariable("x", new TypeValue(VariableType.INT, x.ToString()));
            context.SetVariable("y", new TypeValue(VariableType.INT, y.ToString()));

            Expression intX = new Expression("x");
            Expression intY = new Expression("y");
            PlusExpression plusExpression = new PlusExpression(intX, intY);
            var result1 = plusExpression.Interpret(context);

            string a = "Hellow, ";
            string b = " world!";

            context.SetVariable("a", new TypeValue(VariableType.STRING, a));
            context.SetVariable("b", new TypeValue(VariableType.STRING, b));

            Expression stringA = new Expression("a");
            Expression stringB = new Expression("b");
            plusExpression = new PlusExpression(stringA, stringB);
            var result2 = plusExpression.Interpret(context);

            Console.WriteLine($"Пременная типа \"{result1.Type}\" со значением: {result1.Value}");
            Console.WriteLine($"Пременная типа \"{result2.Type}\" со значением: {result2.Value}");

            Console.ReadKey();
        }
    }
}