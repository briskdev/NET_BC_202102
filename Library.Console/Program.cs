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
                //foreach(var book in books)
                //{
                //    System.Console.WriteLine("{0} ({1}) {2}", book.Title, book.Author, book.Year);
                //}
                books.ForEach(book =>
                {
                    System.Console.WriteLine("{0} ({1}) {2}", book.Title, book.Author, book.Year);
                });
            }
        }
    }
}
