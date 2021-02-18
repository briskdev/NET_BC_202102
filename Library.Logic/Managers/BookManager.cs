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

        private UserBooks User { get; set; }

        public BookManager()
        {
            Library = new LibraryBooks();
            User = new UserBooks();
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
            return User.Books.ToList();
        }

        public Book TakeBook(string title)
        {
            // Take - user takes a book providing its title. Validation if book exists. Validation if book is
            // still available(check number of copies). Book is added to the user's list and available
            // book count is decreased.

            var book = Library.Books.Find(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if(book != null && book.Copies > 0)
            {
                book.Copies--;
                User.Books.Add(book);

                return book;
            }

            return null;
        }

        public void ReturnBook(string title)
        {
            throw new NotImplementedException();
        }
    }
}
