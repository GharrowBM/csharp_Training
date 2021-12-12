using System;
using System.Collections.Generic;
using System.Globalization;
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

        public Sale()
        {
            Products = new List<Product>();
            Date = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{Id}. ({Date.ToString("d")}) - {TotalPrice.ToString("C", CultureInfo.CurrentCulture)}";
        }

        public bool AddProduct(Product p)
        {
            if (p != null)
            {
                Products.Add(p);

                CalcTotal();

                return true;
            }

            return false;
        }

        public bool RemoveProduct(Product p)
        {
            if (p != null)
            {
                Products.Remove(p);

                CalcTotal();

                return true;
            }

            return false;
        }

        public bool CompleteSale()
        {
            if (Products.Count >= 0)
            {
                foreach (Product p in Products) 
                {
                    if (p.Stock - 1 >= 0) p.Stock--;
                    else return false;
                }
                return true;
            }

            return false;
        }

        public List<Product> GetRelatedProducts()
        {
            List<Product> products = new List<Product>();

            foreach (var product in Products) products.Add(product);

            return products;
        }

        private void CalcTotal()
        {
            TotalPrice = 0.0m;
            foreach (var item in Products) TotalPrice += item.Price;
        }
    }
}