using System;
using System.IO;
using System.Text;
using System.Collections.Generic;


namespace Visitor
{
    interface IAccount
    {
        void Accept(IVisitor visitor);
    }
    
    interface IVisitor
    {
        void VisitPersonAcc(Person acc);
        void VisitCompanyAcc(Company acc);
    }

    class HtmlSerializer : IVisitor
    {
        public void VisitPersonAcc(Person acc)
        {
            string result = "<table><tr><td>Свойство<td><td>Значение</td></tr>";
            result += "<tr><td>FIO<td><td>" + acc.FIO + "</td></tr>";
            result += "<tr><td>Number<td><td>" + acc.AccNumber + "</td></tr></table>";

            string path = @"C:\Users\user\Desktop\VisitorPatternPerson.html";
            SerializeAndSave(result, path);
        }

        public void VisitCompanyAcc(Company acc)
        {
            string result = "<table><tr><td>Свойство<td><td>Значение</td></tr>";
            result += "<tr><td>Name<td><td>" + acc.Name + "</td></tr>";
            result += "<tr><td>RegNumber<td><td>" + acc.RegNumber + "</td></tr>";
            result += "<tr><td>Number<td><td>" + acc.Number + "</td></tr></table>";
            
            string path = @"C:\Users\user\Desktop\VisitorPatternCompany.html";
            SerializeAndSave(result, path);
        }

        private void SerializeAndSave(string text, string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }

                using (FileStream fs = File.Create(path))
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes(text);
                    fs.Write(info, 0, info.Length);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
    
    class Person : IAccount
    {
        public string FIO { get; set; } 
        public string AccNumber { get; set; }
        
        public void Accept(IVisitor visitor)
        {
            visitor.VisitPersonAcc(this);
        }
    }
    
    class Company : IAccount
    {
        public string Name { get; set; } 
        public string RegNumber { get; set; } 
        public string Number { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitCompanyAcc(this);
        }
    }

    class Bank
    {
        List<IAccount> accounts;

        public Bank(params IAccount[] accs)
        {
            accounts = new List<IAccount>();

            foreach(var acc in accs)
                accounts.Add(acc);
        }

        public void Accept(IVisitor visitor)
        {
            foreach (var acc in accounts)
                acc.Accept(visitor);
        }

        public void Add(IAccount  acc)
        {
            accounts.Add(acc);
        }

        public void Remove(IAccount acc)
        {
            accounts.Remove(acc);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            person.FIO = "Иванов Иван Иванович";
            person.AccNumber = "11111";
            
            Company company = new Company();
            company.Name = "Ford";
            company.Number = "22222";
            company.RegNumber = "33333";
            
            Bank bank = new Bank(person, company);
            bank.Accept(new HtmlSerializer());

            Console.ReadKey();
        }
    }
}