using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caisse.Classes
{
    public class Sale
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime Date { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}