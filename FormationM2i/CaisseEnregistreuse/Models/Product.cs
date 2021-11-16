using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace CaisseEnregistreuse.Models
{
    internal class Product
    {
        private string id;
        private string name;
        private decimal price;
        private int quantity;

        public int Quantity { get { return quantity; } set { quantity = value; } }
        public string Name { get { return name; } }

        public decimal Price { get { return price; } }

        public Product(string name, decimal price, int quantity)
        {
            this.id = Guid.NewGuid().ToString();
            this.name = name;
            this.price = price;
            this.quantity = quantity;
        }

        public override string ToString()
        {
            return $"{quantity} {name} - {price.ToString("C", CultureInfo.CurrentCulture)}";
        }
    }
}
