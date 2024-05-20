using LINQUnderstandingAPP.Model;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace LINQUnderstandingAPP
{
    internal class Program


    {

        //void PrintTheBooksPulisherwise()
        //{
        //    pubsContext context = new pubsContext();
        //    var books = context.Titles
        //                .GroupBy(t => t.PubId, t => t.Pub, (pid, title) => new { Key = pid, TitleCount = title.Count() });

        //    foreach (var book in books)
        //    {
        //        Console.Write(book.Key);
        //        Console.WriteLine(" - " + book.TitleCount);
        //    }
        //}
        void PrintTheBooksPulisherwise()
        {
            pubsContext context = new pubsContext();
            var books = context.Titles
                        .GroupBy(t => t.PubId, t => t, (pid, title) => new { Key = pid, TitleCount = title.Count(), TitleNames = title.ToList() });

            foreach (var book in books)
            {
                Console.Write(book.Key);
                Console.WriteLine(" - " + book.TitleCount);
                Console.WriteLine("BookNames");
                foreach (var title in book.TitleNames)
                {
                    Console.WriteLine(title.Title1);
                }
            }
        }

        //void PrintTheBooksPulisherwise()
        //{
        //    pubsContext context = new pubsContext();
        //    var books = context.Titles
        //                .GroupBy(t => t.PubId)
        //                .Select(t => new
        //                {
        //                    PublisherId = t.Key,
        //                    TitleCount = t.Count(),
        //                    Titles = t.Select(t => new
        //                    {
        //                        BookName = t.Title1,
        //                        BookPrice = t.Price
        //                    })
        //                });

        //    foreach (var book in books)
        //    {
        //        Console.Write(book.PublisherId);
        //        Console.WriteLine(" - " + book.TitleCount);
        //        foreach (var title in book.Titles)
        //        {
        //            Console.WriteLine("\t" + title.BookName + " " + title.BookPrice);
        //        }
        //    }
        //}

        //Print the TitleId and the same Quantity and order id for every title

        void PrintTitleID()
        {
            pubsContext context = new pubsContext();
            //var titleid = context.Sales.ToList();
            //foreach (var title in titleid) {
            //    Console.WriteLine( "TitleID: "+ title.TitleId+" "+"Quantity Saled : " + 
            //        title.Qty+" "+ "Order_Num: "+title.OrdNum);
            var books = context.Sales.GroupBy(s => s.TitleId, s => s, 
                (titleId, sales) => new {
                TitleId = titleId,
                Sales = sales.ToList()
            }).ToList();
        }
        
        void PrintNumberOfBooksFromType(string type)
        {
            pubsContext context = new pubsContext();
            var bookCount = context.Titles.Where(t => t.Type == type).Count();
            Console.WriteLine($"There are {bookCount} in the type {type}");
        }

        void PrintAuthorNames()
        {
            pubsContext context = new pubsContext();
            var authors = context.Authors.ToList();
            foreach (var author in authors)
            {
                Console.WriteLine(author.AuFname + " " + author.AuLname);
            }
        }
        static void Main(string[] args)
        {
            Program program = new Program();

            //.PrintAuthorNames();
            //program.PrintNumberOfBooksFromType("mod_cook");
            //program.PrintTheBooksPulisherwise();
            program.PrintTitleID();


    }
    }
}
