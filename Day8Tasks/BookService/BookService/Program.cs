using BookService.BookSystem;
using System;
using BookService.Predicate;
using System.Collections.Generic;
using BookService.Storage;

namespace BookService
{
    class Program
    {
        static void Main(string[] args)
        {
            BookListService service = new BookListService();

            service.AddBook(new Book("11211","Tomop", "Tol", 1997, "RR.C", 234, 333));
            service.AddBook(new Book("113111","Toop", "ol", 1987, "RR.C", 234, 333));
            service.AddBook(new Book("11311","Vdop", "Tol", 1987, "RR.C", 234, 333));
            service.AddBook(new Book("12111","Adsop", "Tol", 3442, "RR.C", 234, 333));
            service.AddBook(new Book("111211","Fswomop", "Tol", 2222, "RR.C", 234, 333));

            service.ShowList();
            service.SortBooksByTag(new NameComparer());
            Console.WriteLine();

            service.ShowList();
            service.DeleteBook(new Book("11211", "Tomop", "Tol", 1997, "RR.C", 234, 333));
            Console.WriteLine();

            service.ShowList();
            Console.WriteLine();

            service.WriteToStorage(new BinaryStorage());
            List<Book> list = service.FindBookByTag(new NameTag("Fswomop"));
            foreach(Book b in list)
            {
                Console.WriteLine(b);
            }
            
            Console.WriteLine();

            BookListService service1 = new BookListService();
            service1.LoadFromStorage(new BinaryStorage());
            service1.ShowList();

            Console.Read();
        }
    }
}
