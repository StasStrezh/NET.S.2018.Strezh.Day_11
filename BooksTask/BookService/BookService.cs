using System;
using System.Collections.Generic;
using BooksTask;
using BookStorage;

namespace BookService
{
    public class BookService : IBookService
    {
        /// <summary>
        /// Private fields
        /// </summary>
        private readonly IBookStorage bookStorage;
        private List<Book> books = new List<Book>();
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="bookStorage"></param>
        public BookService(IBookStorage bookStorage)
        {
            if (ReferenceEquals(bookStorage, null))
            {
                throw new ArgumentException();
            }
            this.bookStorage = bookStorage;
        }
        /// <summary>
        /// Add book
        /// </summary>
        /// <param name="book"></param>
        public void AddBookToShop(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                throw new ArgumentNullException();
            }
            books.Add(book);
        }
        /// <summary>
        /// Remove book
        /// </summary>
        /// <param name="book"></param>
        public void RemoveBookFromShop(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                throw new ArgumentNullException();
            }
            books.Remove(book);
        }
        /// <summary>
        /// Find book
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public Book FindBook(IFinder parameter)
        {
            if (ReferenceEquals(parameter, null))
            {
                throw new ArgumentNullException();
            }
            return parameter.FindBookByTeg();
        }
        /// <summary>
        /// Sorting
        /// </summary>
        /// <param name="comparator"></param>
        public void Sort(IComparer<Book> comparator)
        {
            var booksArray = books.ToArray();

            if (ReferenceEquals(comparator, null))
            {
                Array.Sort(booksArray);
            }
            else
            {
                Array.Sort(booksArray, comparator);
            }
            books.Clear();
            books.AddRange(booksArray);
        }
        /// <summary>
        /// Save
        /// </summary>
        public void Save()
        {
            bookStorage.SaveBooks(books);
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return bookStorage.GetBookList();
        }
    }
}
