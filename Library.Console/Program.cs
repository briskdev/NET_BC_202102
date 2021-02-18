using Library.Logic.Managers;
using System;

namespace Library.Console
{
    class Program
    {
        static BookManager manager = new BookManager();

        static void Main(string[] args)
        {
            System.Console.WriteLine("Welcome to the Library!");

            var books = manager.GetAvailableBooks();
            if(books.Count == 0)
            {
                System.Console.WriteLine("There are no available books at the moment!");
            }
            else
            {
                books.ForEach(book =>
                {
                    System.Console.WriteLine("{0} ({1}) {2}", book.Title, book.Author, book.Year);
                });

                while(true)
                {
                    System.Console.Write("Enter book's title (or stop): ");
                    string input = System.Console.ReadLine();

                    if(input == "stop")
                    {
                        break;
                    }

                    var book = manager.TakeBook(input);
                    if(book != null)
                    {
                        System.Console.WriteLine("Book {0} borrowed!", book.Title);
                    }
                    else
                    {
                        // book == NULL
                        System.Console.WriteLine("Book is not available!");
                    }
                }

                System.Console.WriteLine("Your books: ");
                var myBooks = manager.GetUserBooks();
                if (myBooks.Count == 0)
                {
                    System.Console.WriteLine("You haven't taken any books!");
                }
                else
                {
                    myBooks.ForEach(book =>
                    {
                        System.Console.WriteLine("{0} ({1}) {2}", book.Title, book.Author, book.Year);
                    });
                }
            }
        }
    }
}
