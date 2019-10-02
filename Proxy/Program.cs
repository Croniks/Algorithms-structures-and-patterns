using System;
using System.Collections.Generic;
using System.Linq;


namespace Proxy
{
    class Program
    {
        // Класс объекта который нужно хранить или получать
        class Page
        {
            public int Id { get; set; }
            public int Number { get; set; }
            public string Text { get; set; }

            public Page(int id, int number, string text)
            {
                Id = id; Number = number; Text = text;
            }

            public override string ToString()
            {
                return $"{Number} : {Text}";
            }
        }

        // Коллекция, играющая роль базы данных
        static List<Page> dbPages = new List<Page>() { new Page(1, 1, "Первая страница"),
                                                       new Page(2, 2, "Вторая страница"),
                                                       new Page(3, 3, "Третья страница") };

        // Общий интерфейс для объектов заместителя и начальника
        interface IBook : IDisposable
        {
            Page GetPage(int number);
            void AddPage(Page page);
        }

        // Объект начальник
        class DbPageStorage : IBook
        {
            List<Page> Pages { get; set; }

            public DbPageStorage()
            {
                // Имитируем соединение с базой данных
                Pages = dbPages;
            }

            public Page GetPage(int number)
            {
                return Pages.FirstOrDefault(p => p.Number == number);
            }

            public void AddPage(Page p)
            {
                Pages.Add(p);
            }

            public void Dispose()
            {
                // Сбрасываем соединение с базой данных
                Pages = null;
            }
        }

        // Объект заместитель
        class PageStorageProxy : IBook
        {
            List<Page> pages { get; set; }
            DbPageStorage db;

            public PageStorageProxy()
            {
                pages = new List<Page>();
            }

            public Page GetPage(int number)
            {
                Page page = pages.FirstOrDefault(p => p.Number == number);
                
                if(page == null)
                {
                    if(db == null)
                        db = new DbPageStorage();

                    page = db.GetPage(number);

                    if(page != null)
                        pages.Add(page);
                }
                
                return page;
            }

            public void AddPage(Page p)
            {
                pages.Add(p);

                if (db == null)
                    db = new DbPageStorage();
                db.AddPage(p);
            }

            public void Dispose()
            {
                if(db != null)
                    db.Dispose();
            }
        }

        
        static void Main(string[] args)
        {
            IBook book = new PageStorageProxy();

            using (book)
            {
                Page page1 = book.GetPage(1);
                Page page2 = book.GetPage(2);
                Page page5 = book.GetPage(5);

                Console.WriteLine(page1);
                Console.WriteLine(page2);
                Console.WriteLine(page5);

                book.AddPage(new Page(5, 5, "Пятая страница"));
                page5 = book.GetPage(5);

                Console.WriteLine(page1);
                Console.WriteLine(page2);
                Console.WriteLine(page5);
            }

            Console.ReadKey();
        }
    }
}