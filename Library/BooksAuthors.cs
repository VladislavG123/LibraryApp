using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class BooksAuthors : Entity
    {
        public Author Author { get; set; }
        public Book Book { get; set; }
    }
}
