using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Logic.Data
{
    // Book (title, year, author, copies)
    public class Book
    {
        public string Title { get; set; }

        public int Year { get; set; }

        public string Author { get; set; }

        public int Copies { get; set; }

        public Book()
        {
            Copies = 1;
        }
    }
}
