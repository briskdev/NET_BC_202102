using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Logic.Data
{
    public class UserBooks
    {
        /// <summary>
        /// Books the user has taken
        /// </summary>
        public List<Book> Books { get; set; }

        public UserBooks()
        {
            Books = new List<Book>();
        }
    }
}
