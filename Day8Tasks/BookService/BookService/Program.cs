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

            service.AddBook(new Book("978-1-10-769989-2", "Dog in the hell", "Pushkin", 1997, "RR.C", 234, 333));
            service.AddBook(new Book("978-1-10-763989-2", "Dog in the sky", "Pushkin", 1999, "RR.C", 224, 536));
            service.AddBook(new Book("978-1-10-739989-2", "Black lake", "Losna", 2008, "RB.C", 238, 621));

            service.ShowList();
            service.SortBooksByTag(new NameComparer());
            Console.WriteLine();

            service.ShowList();
            service.DeleteBook("978-1-10-769989-2");
            Console.WriteLine();

            service.ShowList();
            Console.WriteLine();

            service.WriteToStorage(new BinaryStorage());
            List<Book> list = service.FindBookByTag(new TitleTag("Black lake"));
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
