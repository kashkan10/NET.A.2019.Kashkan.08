using BookService.Predicate;
using BookService.Storage;
using System;
using System.Collections.Generic;

namespace BookService.BookSystem
{
    class BookListService
    {
        /// <summary>
        /// List of books
        /// </summary>
        private List<Book> list;

        /// <summary>
        /// Default constructor
        /// </summary>
        public BookListService()
        {
            list = new List<Book>();
        }

        /// <summary>
        /// Custom constructor
        /// </summary>
        /// <param name="list"></param>
        public BookListService(List<Book> list)
        {
            this.list = list;
        }

        /// <summary>
        /// Write list to storage
        /// </summary>
        /// <param name="storage"></param>
        public void WriteToStorage(IStorage storage)
        {
            storage.Write(list);
        }

        /// <summary>
        /// Load List from storage
        /// </summary>
        /// <param name="storage"></param>
        public void LoadFromStorage(IStorage storage)
        {
            storage.Load(list);
        }

        /// <summary>
        /// Add book to list
        /// </summary>
        /// <param name="book"></param>
        public void AddBook(Book book)
        {
            if (list.Contains(book))
                throw new Exception("This book is already in list");

            list.Add(book);
        }

        /// <summary>
        /// Delete book from list
        /// </summary>
        /// <param name="book"></param>
        public void DeleteBook(string isbn)
        {
            Book book = list.Find(bk => bk.ISBN == isbn);
            if (!list.Contains(book))
                throw new Exception("Book is not found");

            list.Remove(book);
        }

        /// <summary>
        /// Show list of books on the console
        /// </summary>
        public void ShowList()
        {
            foreach (Book book in list)
            {
                Console.WriteLine(book.ToString());
            }
        }

        /// <summary>
        /// Sort list of books by criterium
        /// </summary>
        /// <param name="comparer"></param>
        public void SortBooksByTag(IComparer<Book> comparer)
        {
            list.Sort(comparer);
        }

        /// <summary>
        /// Search for books by criterium
        /// </summary>
        /// <param name="comparer"></param>
        public List<Book> FindBookByTag(IPredicate tag)
        {
            return list.FindAll(tag.IsMatch);
        }
    }
}
