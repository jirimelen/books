using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Book_list
    {
        private List<Book> list = new List<Book>();
        private Data_manager manager;

        public Book_list(Data_manager Manager)
        {
            manager = Manager;
        }

        public void Update(List<Book> newList)
        {
            list = newList;
        }

        public void Add(Book book)
        {
            list.Add(book);

            manager.Save(list);
        }

        public void Delete(int index)
        {
            list.Remove(list[index]);

            manager.Save(list);
        }

        public void PrintTable()
        {

            Console.WriteLine("{0, -3}{1, -25}{2, -17}{3, -6}", "ID", "Name", "Author", "type");

            int index = 0;
            foreach (var book in list)
            {
                Console.WriteLine("{0, -3}{1, -25}{2, -17}{3, -6}",
                    index, book.Name,
                    book.BookAuthor.FirstName + " " + book.BookAuthor.LastName,
                    book is EBook ? "eBook" : "paper"
                );
                index++;
            }
        }
    }
}
