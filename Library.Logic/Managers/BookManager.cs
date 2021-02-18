using Library.Logic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Logic.Managers
{
    /// <summary>
    /// All the logic for taking/returning books
    /// </summary>
    public class BookManager
    {
        private LibraryBooks Library { get; set; }

        public BookManager()
        {
            Library = new LibraryBooks();
        }

        /// <summary>
        /// Returns list of all available books
        /// </summary>
        /// <returns></returns>
        public List<Book> GetAvailableBooks()
        {
            // Book list - shows all the available books in the library (ordered by title). 
            // Corresponding message if there are no more books in the list.
            return Library.Books
                .Where(b => b.Copies > 0)
                .OrderBy(b => b.Title)
                .ToList();
        }

        public List<Book> GetUserBooks()
        {
            throw new NotImplementedException();
        }

        public Book TakeBook(string title)
        {
            throw new NotImplementedException();
        }

        public void ReturnBook(string title)
        {
            throw new NotImplementedException();
        }
    }
}
