using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Logic.Data
{
    public class LibraryBooks
    {
        /// <summary>
        /// Books available in the library
        /// </summary>
        public List<Book> Books { get; set; }

        public LibraryBooks()
        {
            // Application must contain a predefined list(starting list) of some books.
            Books = new List<Book>()
            {
                new Book()
                {
                    Author = "Author #1",
                    Title = "Book #1",
                    Year = 2020,
                    Copies = 1,
                },
                new Book()
                {
                    Author = "Author #2",
                    Title = "Book #2",
                    Year = 1975,
                    Copies = 2,
                },
                new Book()
                {
                    Author = "Author #2",
                    Title = "Book #3",
                    Year = 1985,
                    Copies = 1,
                },
            };
        }
    }
}
