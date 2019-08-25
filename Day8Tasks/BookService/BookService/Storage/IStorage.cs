using BookService.BookSystem;
using System.Collections.Generic;

namespace BookService.Storage
{
    interface IStorage
    {
        string Path { get; set; }

        void Write(List<Book> list);
        void Load(List<Book> list);
    }
}
