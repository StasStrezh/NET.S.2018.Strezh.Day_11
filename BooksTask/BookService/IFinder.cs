using System;
using BooksTask;

namespace BookService
{
    public interface IFinder
    {
        Book FindBookByTeg();
    }
}