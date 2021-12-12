using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caisse.Classes
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        public virtual List<Sale> RelatedSales { get; set; }

        public Product()
        {
            RelatedSales = new List<Sale>();
        }

        public override string ToString()
        {
            return $"{Id}. {Name.Substring(0,1).ToUpper()+Name.Substring(1,Name.Length-1).ToLower()} ({Stock} remaining) - {Price.ToString("C", CultureInfo.CurrentCulture)}";
        }
    }
}
