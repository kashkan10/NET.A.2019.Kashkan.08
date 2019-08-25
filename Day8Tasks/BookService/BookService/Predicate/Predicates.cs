﻿using BookService.BookSystem;

namespace BookService.Predicate
{
    class NameTag : IPredicate
    {
        /// <summary>
        /// name
        /// </summary>
        string name;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"></param>
        public NameTag(string name)
        {
            this.name = name;
        }

        /// <summary>
        /// Checking for a match
        /// </summary>
        /// <param name="book"></param>
        /// <returns>Result of check</returns>
        public bool IsMatch(Book book)
        {
            return book.Name == name;
        }
    }
    class YearTag : IPredicate
    {
        /// <summary>
        /// year
        /// </summary>
        int year;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="year"></param>
        public YearTag(int year)
        {
            this.year = year;
        }

        /// <summary>
        /// Checking for a match
        /// </summary>
        /// <param name="book"></param>
        /// <returns>Result of check</returns>
        public bool IsMatch(Book book)
        {
            return book.Year == year;
        }
    }
    class AuthorTag : IPredicate
    {
        /// <summary>
        /// author
        /// </summary>
        string author;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="author"></param>
        public AuthorTag(string author)
        {
            this.author = author;
        }

        /// <summary>
        /// Checking for a match
        /// </summary>
        /// <param name="book"></param>
        /// <returns>Result of check</returns>
        public bool IsMatch(Book book)
        {
            return book.Author == author;
        }
    }
}