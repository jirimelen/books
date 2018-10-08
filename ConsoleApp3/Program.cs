using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Data_manager Data = new Data_manager();
            Book_list bookList = new Book_list(Data);
            List<string> menuOptions = new List<string>();
            int option = -1;

            Data.Load(bookList);

            //List<Author> authors = new List<Author>();

            /*Author author1 = new Author { FirstName = "Hans", LastName = "Deutsch" };
            Author author2 = new Author { FirstName = "Roman", LastName = "Opisec" };
            Author author3 = new Author { FirstName = "Ondřej", LastName = "Rádkoláč" };
            Author author4 = new Author { FirstName = "Jana", LastName = "Zelená" };
            Author author5 = new Author { FirstName = "Zdena", LastName = "Zděná" };

            PaperBook book1 = new PaperBook { BookAuthor = author1, ISBN = 9781491954621, Name = "book 1", Stock = 68, Weight = 0 };
            PaperBook book2 = new PaperBook { BookAuthor = author1, ISBN = 9781491954621, Name = "book 2", Stock = 72, Weight = 0 };
            PaperBook book3 = new PaperBook { BookAuthor = author1, ISBN = 9781491954621, Name = "book 3", Stock = 23, Weight = 0 };
            PaperBook book4 = new PaperBook { BookAuthor = author1, ISBN = 9781491954621, Name = "book 4", Stock = 64, Weight = 0 };
            PaperBook book5 = new PaperBook { BookAuthor = author1, ISBN = 9781491954621, Name = "book 5", Stock = 18, Weight = 0 };

            EBook ebook1 = new EBook { BookAuthor = author1, ISBN = 9781491954621, Name = "ebook 1", SizeMB = 32, URI = "https://sumsite.com/books/ebook1" };
            EBook ebook2 = new EBook { BookAuthor = author1, ISBN = 9781491954621, Name = "ebook 2", SizeMB = 30, URI = "https://sumsite.com/books/ebook2" };
            EBook ebook3 = new EBook { BookAuthor = author1, ISBN = 9781491954621, Name = "ebook 3", SizeMB = 28, URI = "https://sumsite.com/books/ebook3" };
            EBook ebook4 = new EBook { BookAuthor = author1, ISBN = 9781491954621, Name = "ebook 4", SizeMB = 12, URI = "https://sumsite.com/books/ebook4" };
            EBook ebook5 = new EBook { BookAuthor = author1, ISBN = 9781491954621, Name = "ebook 5", SizeMB = 17, URI = "https://sumsite.com/books/ebook5" };*/
            do { 
                //menu
                menuOptions = new List<string>() { "browse books", "add book", "delete book","exit" };
                Menu menu = new Menu(menuOptions);
                bool selected = false;
                option = -1;
                Book bookToAdd = new PaperBook();


                do
                {
                    Console.Clear();
                    menu.printMenu();
                    ConsoleKey cki = Console.ReadKey().Key;
                    switch (cki)
                    {
                        case ConsoleKey.UpArrow:
                            menu.moveUp();
                            break;
                        case ConsoleKey.DownArrow:
                            menu.moveDown();
                            break;
                        case ConsoleKey.Enter:
                            option = menu.getSelectedIndex();
                            selected = true;
                            break;
                    }
                } while (selected == false);
                //menu end

                switch (option)
                {
                    case 0:
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("press \"Backspace\" to display menu");
                            bookList.PrintTable();
                        } while (Console.ReadKey().Key != ConsoleKey.Backspace);
                        break;
                    case 1:
                        bool isEbook = false;
                        Console.Clear();
                        Console.Write("Is this book an Ebook? (Y/N)");
                        ConsoleKey cki = Console.ReadKey().Key;
                        if (cki.Equals(ConsoleKey.Y)) isEbook = true;
                        
                        Console.Clear();

                        Console.WriteLine("Name of the book:");
                        string bookName = Console.ReadLine();
                        Console.WriteLine("Author's first name:");
                        string authorFirst = Console.ReadLine();
                        Console.WriteLine("Author's last name:");
                        string AuthorLast = Console.ReadLine();
                        Console.WriteLine("ISBN of the book:");
                        double bookISBN;
                        try
                        {
                            bookISBN = System.Convert.ToDouble(Console.ReadLine());
                        }
                        catch (Exception)
                        {
                            bookISBN = 000000000000;
                        }

                        if (isEbook)
                        {
                            Console.WriteLine("URI of the Ebook:");
                            string bookURI = Console.ReadLine();
                            Console.WriteLine("Size of the Ebook (MB):");
                            int bookSize;
                            try
                            {
                                bookSize = System.Convert.ToInt32(Console.ReadLine());
                            }
                            catch (Exception)
                            {
                                bookSize = 00;
                            }

                            bookToAdd = new EBook()
                            {
                                Name = bookName,
                                BookAuthor = new Author() { FirstName = authorFirst, LastName = AuthorLast },
                                ISBN = bookISBN,
                                URI = bookURI,
                                SizeMB = bookSize
                            };
                        }
                        else
                        {
                            Console.WriteLine("Stock of the book:");
                            int bookStock;
                            try
                            {
                                bookStock = System.Convert.ToInt32(Console.ReadLine());
                            }
                            catch (Exception)
                            {
                                bookStock = 000;
                            }
                            
                            Console.WriteLine("Weight of the book (g):");
                            int bookWeight;
                            try
                            {
                                bookWeight = System.Convert.ToInt32(Console.ReadLine());
                            }
                            catch (Exception)
                            {
                                bookWeight = 00;
                            }
                            

                            bookToAdd = new PaperBook() {
                                Name = bookName,
                                BookAuthor = new Author() { FirstName = authorFirst, LastName = AuthorLast },
                                ISBN = bookISBN,
                                Stock = bookStock,
                                Weight = bookWeight
                            };
                        }
                        bookList.Add(bookToAdd);
                        break;
                    case 2:
                        bool esc = false;
                        string mess = "type \"back\" to display menu";
                        do
                        {
                            Console.Clear();
                            Console.WriteLine(mess);
                            bookList.PrintTable();



                            string key = Console.ReadLine();

                            if (key.Equals("back"))
                            {
                                esc = true;
                            }
                            else
                            {
                                try
                                {
                                    bookList.Delete((System.Convert.ToInt32(key)));
                                    mess = "type \"back\" to display menu";
                                }
                                catch (Exception)
                                {
                                    mess = "it has to be a number...";
                                }
                            }

                            

                        } while (esc == false);
                        break;
                    default:

                        break;
                }
            } while(option < 3);
        }
    }
}
