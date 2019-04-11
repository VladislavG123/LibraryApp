using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Book : Entity
    {
        public string Name { get; set; }
        
        public ICollection<BooksAuthors> BooksAuthors { get; set; } = new List<BooksAuthors>();
    }
}
