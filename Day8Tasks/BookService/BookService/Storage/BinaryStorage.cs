using BookService.BookSystem;
using System.Collections.Generic;
using System.IO;

namespace BookService.Storage
{
    class BinaryStorage : IStorage
    {
        /// <summary>
        /// Path property
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public BinaryStorage()
        {
            Path = "E:\\books.dat";
        }

        /// <summary>
        /// Custom constructor
        /// </summary>
        /// <param name="path"></param>
        public BinaryStorage(string path)
        {
            this.Path = path;
        }

        /// <summary>
        /// Write list to storage
        /// </summary>
        /// <param name="list"></param>
        public void Write(List<Book> list)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(Path, FileMode.OpenOrCreate)))
            {
                foreach (Book s in list)
                {
                    writer.Write(s.ISBN);
                    writer.Write(s.Author);
                    writer.Write(s.Title);
                    writer.Write(s.Year);
                    writer.Write(s.Publishing);
                    writer.Write(s.CountOfPages);
                    writer.Write(s.Price);
                }
            }
        }

        /// <summary>
        /// Load list from storage
        /// </summary>
        /// <param name="list"></param>
        public void Load(List<Book> list)
        {
            using (BinaryReader reader = new BinaryReader(File.Open(Path, FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    string isbn = reader.ReadString();
                    string author = reader.ReadString();
                    string title = reader.ReadString();
                    int year = reader.ReadInt32();
                    string publishing = reader.ReadString();
                    int countOfPages = reader.ReadInt32();
                    double price = reader.ReadDouble();

                    list.Add(new Book(isbn, title, author, year, publishing, countOfPages, price));
                }
            }
        }
    }
}
