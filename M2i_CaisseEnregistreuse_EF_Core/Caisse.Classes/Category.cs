using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caisse.Classes
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Product> Products { get; set; }

        public Category()
        {
            Products = new List<Product>();
        }

        public override string ToString()
        {
            return $"{Id}. {Name.Substring(0,1).ToUpper()+Name.Substring(1,Name.Length-1).ToLower()}";
        }
    }
}
