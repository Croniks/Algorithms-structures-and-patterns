using System;


namespace Covariance
{
    class Account
    {
        public virtual void DoTransfer(int sum)
        {
            Console.WriteLine($"Клиент положил на счет {sum} долларов");
        }
    }

    class DepositAccount : Account
    {
        public override void DoTransfer(int sum)
        {
            Console.WriteLine($"Клиент положил на депозитный счет {sum} долларов");
        }
    }

    class EscrowAccount : Account
    {
        public override void DoTransfer(int sum)
        {
            Console.WriteLine($"Клиент положил на защищённый счет {sum} долларов");
        }
    }

    interface IBank<out T>
    {
        T CreateAccount(int sum);
    }

    class Bank<T> : IBank<T> where T : Account, new()
    {
        public T CreateAccount(int sum)
        {
            T acc = new T();  
            acc.DoTransfer(sum);
            return acc;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IBank<DepositAccount> depositBank = new Bank<DepositAccount>();
            Account acc1 = depositBank.CreateAccount(34);

            IBank<Account> ordinaryBank = new Bank<DepositAccount>();

            IBank<Account> escrowBank = new Bank<EscrowAccount>();
            
            Account acc2 = ordinaryBank.CreateAccount(45);

            Account acc3 = escrowBank.CreateAccount(70);

            Console.Read();
        }
    }
}
