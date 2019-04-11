using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new LibraryContext())
            {
                Console.WriteLine("Список должников");
                foreach (var order in context.Orders.ToList<Order>())
                {
                    if (order.DeliveryDate is null)
                    {
                        foreach (var user in context.Users.ToList<User>())
                        {
                            foreach (var usersOrder in user.Orders)
                            {
                                if (usersOrder.Id == order.Id)
                                {
                                    Console.WriteLine(user.Name);
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("\nАвторы книги №3");
                const int THIRD_BOOK_ID = 3;
                for (int i = 0; i < context.BooksAuthors.ToList<BooksAuthors>().Count; i++)
                {
                    foreach (var author in context.Authors.ToList<Author>())
                    {
                        if (i == THIRD_BOOK_ID && author.Id == author.Id)
                        {
                            Console.WriteLine(author.Name);
                        }
                    }
                }

                Console.WriteLine("\nСвободные книги");

                foreach (var book in context.Books.ToList<Book>())
                {
                    bool isExcists = false;
                    foreach (var order in context.Orders.ToList<Order>())
                    {
                        if (book.Id == order.Book.Id)
                        {
                            isExcists = true;
                        }
                    }
                    if (!isExcists)
                    {
                        Console.WriteLine(book.Name);
                    }
                }

                Console.WriteLine("\nКниги 2 пользователя");

                const int SECOND_USER_ID = 1;

                for (int i = 0; i < context.Users.ToList<User>().Count; i++)
                {
                    foreach (var order in context.Orders.ToList<Order>())
                    {
                        foreach (var book in context.Books.ToList<Book>())
                        {
                            if (book.Id == order.Book.Id && order.User.Id == context.Users.ToList<User>()[i].Id && i == SECOND_USER_ID)
                            {
                                Console.WriteLine(book.Name);
                            }
                        }

                    }
                }

                Console.WriteLine("\nУдаление задолжностей у всех должников...");

                foreach (var order in context.Orders.ToList<Order>())
                {
                    if (order.DeliveryDate is null)
                    {
                        order.DeliveryDate = DateTime.Now;
                    }
                }
                context.SaveChanges();
                Console.WriteLine("Задолжности успешно обнулены!");
            }
            Console.WriteLine("\nЧтобы закрыть приложение, нажмити ENTER!");
            Console.Read();
        }
    }
}





//using (LibraryContext libraryContext = new LibraryContext())
//{
//    List<Author> authors = new List<Author> { new Author { Name = "Пушкин" }, new Author { Name = "Толстой" } };

//    List<Book> books = new List<Book> { new Book { Name = "Скaзки" }, new Book { Name = "Война и мир" }, new Book { Name = "Неизвестная книга" } };

//    List<User> users = new List<User> { new User { Name = "Вася Пупкин", PhoneNumber = "+123123123" }, new User { Name = "Василий Голобородько", PhoneNumber = "+23878041232" } };

//    for (int i = 0; i < authors.Count; i++)
//        libraryContext.Authors.Add(authors[i]);

//    //libraryContext.Database.SqlQuery()

//    for (int i = 0; i < books.Count; i++)
//        libraryContext.Books.Add(books[i]);

//    for (int i = 0; i < users.Count; i++)
//        libraryContext.Users.Add(users[i]);

//    libraryContext.BooksAuthors.Add(new BooksAuthors { Book = books[0], Author = authors[0] });
//    libraryContext.BooksAuthors.Add(new BooksAuthors { Book = books[1], Author = authors[1] });
//    libraryContext.BooksAuthors.Add(new BooksAuthors { Book = books[2], Author = authors[0] });
//    libraryContext.BooksAuthors.Add(new BooksAuthors { Book = books[2], Author = authors[1] });

//    libraryContext.Orders.Add(new Order { TakenDate = DateTime.Now, Book = books[0], User = users[1] });

//    libraryContext.SaveChanges();
//}
