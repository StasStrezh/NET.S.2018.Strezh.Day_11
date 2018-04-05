using System;
using System.Collections.Generic;
using System.IO;
using BooksTask;

namespace BookStorage
{
    /// <summary>
    /// Class BookStorage
    /// </summary>
    public class BookStorage : IBookStorage
    {
        /// <summary>
        /// Private property
        /// </summary>
        private readonly string path;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="path"></param>
        public BookStorage(string path)
        {
            if(string.IsNullOrEmpty(path))
            {
                throw new ArgumentException();
            }
            this.path = path;
        }

        public IEnumerable<Book> GetBookList()
        {
            List<Book> books = new List<Book>();
            using (var br = new BinaryReader(File.Open(path, FileMode.OpenOrCreate,
                FileAccess.Read, FileShare.Read)))
            {
                while (br.BaseStream.Position != br.BaseStream.Length)
                {
                    var book = Reader(br);
                    books.Add(book);
                }
            }
            return books;
        }
        /// <summary>
        /// Write books to file
        /// </summary>
        /// <param name="book"></param>
        public void AppendBookToFile(Book book)
        {
            using (var bw = new BinaryWriter(File.Open(path, FileMode.Append,
                FileAccess.Write, FileShare.None)))
            {
                Writer(bw, book);
            }
        }

        public void SaveBooks(IEnumerable<Book> booksSave)
        {

            using (var bw = new BinaryWriter(File.Open(path, FileMode.Create,
                FileAccess.Write, FileShare.None)))
            {
                foreach (var book in booksSave)
                {
                    Writer(bw, book);
                }
            }
        }
        /// <summary>
        /// Private methods
        /// </summary>
        /// <param name="binary"></param>
        /// <param name="book"></param>
        private static void Writer(BinaryWriter binary, Book book)
        {
            binary.Write(book.Isbn);
            binary.Write(book.Author);
            binary.Write(book.Name);
            binary.Write(book.Publisher);
            binary.Write(book.Year);
            binary.Write(book.Price);
            binary.Write(book.Pages);
        }
        private static Book Reader(BinaryReader binary)
        {
            var isbn = binary.ReadString();
            var author = binary.ReadString();
            var name = binary.ReadString();
            var publisher = binary.ReadString();
            var year = binary.ReadInt32();
            var price = binary.ReadDecimal();
            var pages = binary.ReadInt32();

            return new Book(isbn, author, name, publisher, year, price, pages);
        }
    }
}
