using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseEnregistreuse.Models
{
    internal class Sale
    {
        private string id;
        private List<Product> products;
        private bool isDone;

        public string Id { get { return id; } }

        public List<Product> Products { get { return products; } }
        public bool IsDone { get { return isDone; } set { isDone = value; } }

        public Sale(List<Product> products)
        {
            this.id = Guid.NewGuid().ToString();
            this.products = products;
            this.isDone = false;
        }

        public override string ToString()
        {
            string tmpStr = "";
            tmpStr += $"{id}: {(isDone ? "Terminée" : "En cours")} [";
            foreach (Product product in products)
            {
                tmpStr += products.FindIndex(x => x == product) == products.Count -1 ? $"{product.Quantity} {product.Name}]" : $"{product.Quantity} {product.Name},";
            }

            return tmpStr;
        }

        public bool AddProduct(Product product)
        {
            products.Add(product);
            return true;
        }

        public decimal CalcTotal()
        {
            decimal total = 0;

            foreach (Product product in products)
            {
                total += product.Price * product.Quantity;
            }

            return total;
        }
    }
}
