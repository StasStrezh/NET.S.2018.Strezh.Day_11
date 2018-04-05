using System;

namespace BooksTask
{
    public class Book : IEquatable<Book>, IComparable, IComparable<Book>, IFormattable
    {
        /// <summary>
        /// Private fields
        /// </summary>
        private string _Isbn;
        private string _Author;
        private string _Name;
        private string _Publisher;

        /// <summary>
        /// Public properties
        /// </summary>
        public string Isbn
        {
            get => _Isbn;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Book must have ISBN!");
                _Isbn = value;
            }
        }
        public string Author
        {
            get => _Author;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Book must have Author!");
                _Author = value;
            }
        }
        public string Name
        {
            get => _Name;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Book must have name!");
                _Name = value;
            }
        }
        public string Publisher
        {
            get => _Publisher;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Book must have a publisher!");
                _Publisher = value;
            }
        }
        public int Year { get; }
        public decimal Price { get; }
        public int Pages { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="isbn"></param>
        /// <param name="author"></param>
        /// <param name="name"></param>
        /// <param name="publish"></param>
        /// <param name="year"></param>
        /// <param name="price"></param>
        /// <param name="pages"></param>
        public Book(string isbn, string author, string name, string publisher, int year, decimal price, int pages)
        {
            Isbn = isbn;
            Author = author;
            Name = name;
            Publisher = publisher;
            Year = year;
            Price = price;
            Pages = pages;
        }

        #region override
        /// <summary>
        /// IEquatable override method
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public bool Equals(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                return false;
            }
            if (ReferenceEquals(this, book))
            {
                return true;
            }
            return book.Isbn == Isbn;
        }
        /// <summary>
        /// Override method Equals
        /// </summary>
        /// <param name="bookEq"></param>
        /// <returns></returns>
        public override bool Equals(object bookEq)
        {
            var book = (Book)bookEq;
            if (book == null)
                return false;

            return Isbn == book.Isbn && Author == book.Author && Name == book.Name
                   && Publisher == book.Publisher && Year == book.Year && Pages == book.Pages;
        }
        /// <summary>
        /// Override GetHashCode
        /// </summary>
        /// <returns>New GetHashCode</returns>
        public override int GetHashCode()
        {
            return Isbn.GetHashCode();
        }
        /// <summary>
        /// Override ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ToString("7", null);
        }
        /// <summary>
        /// Output options
        /// </summary>
        /// <param name="format"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format)) format = "5";


            switch (format)
            {
                case "1": return "Book: " + Name + " Author: " + Author;
                case "2": return "Book: " + Name + " Author: " + Author + " ISBN: " + Isbn;
                case "3": return "Book: " + Name + " Author: " + Year + " y. " + Author + " ISBN: " + Isbn;
                case "4": return "Book: " + Name + " Author: " + Year + " y. " + Pages + " p. " + Author + " ISBN: " + Isbn;
                case "5": return "Book: " + Name + " Author: " + Year + " y. " + Pages + " p. " + Author + " ISBN: " + Isbn + " Publisher : " + Publisher;
                case "6": return "Book: " + Name + " Author: " + Year + " y. " + Pages + " p. " + Author + " ISBN: " + Isbn + " Publisher : " + Publisher + Price + " y.e ";
                default: throw new FormatException(String.Format("The {0} format string is not supported.", format));
            }
        }
        #endregion
        /// <summary>
        /// IComparable override method
        /// </summary>
        /// <param name="bookObj"></param>
        /// <returns></returns>
        public int CompareTo(object bookObj)
        {
            if (ReferenceEquals(bookObj, null)) return 1;
            var book = (Book)bookObj;
            return CompareTo(book);
        }

        public int CompareTo(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                return 1;
            }
            return string.Compare(Name, book.Name);
        }
    }
}
