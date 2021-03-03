using Library.Logic.Data;
using Library.Logic.DB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Library.Logic.Managers
{
    /// <summary>
    /// All the logic for taking/returning books
    /// </summary>
    public class BookManager
    {

        public BookManager()
        {
            
        }

        /// <summary>
        /// Returns list of all available books
        /// </summary>
        /// <returns></returns>
        public List<Books> GetAvailableBooks()
        {
            // Book list - shows all the available books in the library (ordered by title). 
            // Corresponding message if there are no more books in the list.
            using(var db = new LibraryDb())
            {
                return db.Books.Where(b => b.Copies > 0).OrderBy(b => b.Title).ToList();
            }
        }

        /// <summary>
        /// User's books
        /// </summary>
        /// <returns></returns>
        public List<Book> GetUserBooks()
        {
            return User.Books.ToList();
        }

        /// <summary>
        /// Take a book
        /// </summary>
        /// <param name="title">Book's title</param>
        /// <returns></returns>
        public Books TakeBook(string title)
        {
            // Take - user takes a book providing its title. Validation if book exists. Validation if book is
            // still available(check number of copies). Book is added to the user's list and available
            // book count is decreased.

            //var book = Library.Books.Find(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            //if(book != null && book.Copies > 0)
            //{
            //    book.Copies--;
            //    User.Books.Add(book);

            //    return book;
            //}
            using(var db = new LibraryDb())
            {
                // 1. Look for book inside table 'Books' by Title

                // 2. If book is found and is still available:

                // 2.1. Decrease available copies

                // 2.2. Insert new record in table 'UserBooks'

                db.SaveChanges();
            }

            return null;
        }

        /// <summary>
        /// User returns a book
        /// </summary>
        /// <param name="title">Book's title</param>
        /// <returns>Book returned (if found)</returns>
        public Book ReturnBook(string title)
        {
            // Return - user returns a book providing its title. Validation if the book is in the user’s list.
            // Book is removed from the user’s list and the available count is increased.
            var userBook = User.Books.Find(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if(userBook != null)
            {
                User.Books.Remove(userBook);
                // increase available copies
                var libraryBook = Library.Books.Find(b => b.Title == userBook.Title);
                libraryBook.Copies++;

                return userBook;
            }

            return null;
        }
    }
}
