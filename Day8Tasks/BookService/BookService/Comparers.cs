using BookService.BookSystem;
using System;
using System.Collections.Generic;

namespace BookService
{
    class NameComparer : IComparer<Book>
    {
        /// <summary>
        /// IComparer<Book> implementation
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>Comprasion result</returns>
        public int Compare(Book a, Book b)
        {
            return String.Compare(a.Title, b.Title);
        }
    }
    class AuthorComparer : IComparer<Book>
    {
        /// <summary>
        /// IComparer<Book> implementation
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>Comprasion result</returns>
        public int Compare(Book a, Book b)
        {
            return String.Compare(a.Author, b.Author);
        }
    }
    class YearComparer : IComparer<Book>
    {
        /// <summary>
        /// IComparer<Book> implementation
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>Comprasion result</returns>
        public int Compare(Book a, Book b)
        {
            if (a.Year < b.Year)
                return 1;
            if (a.Year > b.Year)
                return -1;
            return 0;
        }
    }
}
