using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class LibraryContext : DbContext
    {

        public LibraryContext() : base("appConnection")
        { }

        public virtual DbSet<Author> Authors { get; set; }

        public virtual DbSet<Book> Books { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<BooksAuthors> BooksAuthors { get; set; }

        public virtual DbSet<User> Users { get; set; }
    }
}
