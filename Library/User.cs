using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class User : Entity
    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
