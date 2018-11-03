using System;


namespace TestEnum
{
    [Flags]
    enum State
    {
        THINKING = 1,
        SMILING = 2,
        SPEAKING = 4,
        WATCHING = 8,
        NODDING = 16
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            State state1 = State.THINKING;
            State state2 = State.SMILING;
            State state3 = State.SPEAKING;

            State state4 = state1 | state2 | state3;
            
            Console.WriteLine(state4);
            Console.WriteLine((int)state4);

            State state5 = state4 & state2;
            State state6 = state4 ^ state2;

            Console.WriteLine(state5);
            Console.WriteLine(state6);

            Console.ReadLine();
        }
    }
}
