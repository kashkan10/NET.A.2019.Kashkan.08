using BookService.BookSystem;

namespace BookService.Predicate
{
    class TitleTag : IPredicate
    {
        /// <summary>
        /// name
        /// </summary>
        string title;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"></param>
        public TitleTag(string title)
        {
            this.title = title;
        }

        /// <summary>
        /// Checking for a match
        /// </summary>
        /// <param name="book"></param>
        /// <returns>Result of check</returns>
        public bool IsMatch(Book book)
        {
            return book.Title == title;
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
