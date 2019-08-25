using System;

namespace BookService.BookSystem
{
    class Book : IComparable
    {
        /// <summary>
        /// ISBN property
        /// </summary>
        public string ISBN { get; private set; }

        /// <summary>
        /// Name property
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Author property
        /// </summary>
        public string Author { get; private set; }

        /// <summary>
        /// Publishing property
        /// </summary>
        public string Publishing { get; private set; }

        /// <summary>
        /// Year property
        /// </summary>
        public int Year { get; private set; }

        /// <summary>
        /// CountOfPages property
        /// </summary>
        public int CountOfPages { get; private set; }

        /// <summary>
        /// Price property
        /// </summary>
        public int Price { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="isbn"></param>
        /// <param name="name"></param>
        /// <param name="author"></param>
        /// <param name="year"></param>
        /// <param name="publishing"></param>
        /// <param name="countOfPages"></param>
        /// <param name="price"></param>
        public Book(string isbn, string name, string author, int year, string publishing, int countOfPages, int price)
        {
            ISBN = isbn;
            Name = name;
            Author = author;
            Year = year;
            Publishing = publishing;
            CountOfPages = countOfPages;
            Price = price;
        }

        /// <summary>
        /// Override of GetHashCode() method
        /// </summary>
        /// <returns>Hash code of object</returns>
        public override int GetHashCode()
        {
            return Name.Length * Author.Length * Year;
        }

        /// <summary>
        /// Override of Equals(object obj) method
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Equality result</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (ReferenceEquals(obj, this))
                return true;
            Book book = obj as Book;
            if (book == null)
                return false;
            if (book.GetHashCode() != this.GetHashCode())
                return false;

            return book.ISBN == this.ISBN;
        }

        /// <summary>
        /// Override of ToString() method
        /// </summary>
        /// <returns>String representation</returns>
        public override string ToString()
        {
            return string.Format("{0} - {1}, {2}", Author, Name, Year);
        }

        /// <summary>
        /// IComparable implementation
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Comprasion result</returns>
        public int CompareTo(object obj)
        {
            Book book = obj as Book;
            if (book == null)
                throw new Exception();

            return string.Compare(book.Name, this.Name);
        }
    }
}
