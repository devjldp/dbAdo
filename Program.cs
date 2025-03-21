using System;
using System.ComponentModel.Design;
using DbAdo.Controller;


namespace DbAdo{
    public class Program
    {
        public static string Menu()
        {
            Console.WriteLine(@"Enter an option:
            1 - Insert a new book.
            2 - Display all books in the system.
            3 - Delete a book.
            4 - Exit.");
            string userInput = Console.ReadLine();

            return userInput;
        }
        public static void Main(string[] args)
        {
            // Create an instance of the CrudOperations class
            CrudOperations crud = new CrudOperations();

            string userOption = Menu();

            while(userOption != "4")
            {
                switch(userOption)
                {
                    case "1":
                        Console.Write("Enter the book's title: ");
                        string title = Console.ReadLine();
                        Console.Write("Enter the author's name: ");
                        string author = Console.ReadLine();
                        Console.Write("Enter book's category: ");
                        string category = Console.ReadLine();
                        Console.Write("Emnter year of publised: ");
                        int year = int.Parse(Console.ReadLine());
                        crud.InsertBook(title, author, category, year);
                        break;
                    case "2":
                        crud.GetBooks();
                        break;
                }
                
                userOption = Menu();
            }


        }
    }
}