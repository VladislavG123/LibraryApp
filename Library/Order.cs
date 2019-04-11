using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Order : Entity
    {
        public User User { get; set; }
        public Book Book { get; set; }

        public DateTime TakenDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
    }
}
