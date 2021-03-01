using Library.Logic.Data;
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
            /*
             return Library.Books
                .Where(b => b.Copies > 0)
                .OrderBy(b => b.Title)
                .ToList();
            */

            List<Book> result = new List<Book>();

            string cs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Briska\source\LibraryDB.mdf;Integrated Security=True;Connect Timeout=30";
            using(SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();

                string query = "SELECT * FROM Books WHERE Copies > 0 ORDER BY Title";
                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            Book book = new Book()
                            {
                                Author = Convert.ToString(reader["Author"]),
                                Title = Convert.ToString(reader["Title"]),
                                Copies = Convert.ToInt32(reader["Copies"]),
                                Year = Convert.ToInt32(reader["Year"]),
                            };

                            result.Add(book);
                        }
                    }
                }

                conn.Close();
            }

            return result;
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
