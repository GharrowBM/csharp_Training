using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaisseEnregistreuse.Models
{
    internal class CashRegister
    {
        private List<Product> products;
        private List<Sale> sales;

        public List<Product> Products { get { return products; } }
        public List<Sale> Sales { get { return sales; } }

        public CashRegister()
        {
            products = new List<Product>();
            sales = new List<Sale>();
        }

        public CashRegister(List<Product> products)
        {
            this.products = products;
            this.sales = new List<Sale>();
        }

        public bool CreateSale(List<Product> productsToSell)
        {
            bool saleAvailability = true;

            foreach (Product product in productsToSell)
            {
                if (products.Find(x => x.Name == product.Name).Quantity < product.Quantity) saleAvailability = false;
            }

            if (saleAvailability) sales.Add(new Sale(productsToSell));

            return saleAvailability;
        }

        public void CompleteSale(Sale saleToComplete)
        {
            Sale currentSale = sales.Find(x => x == saleToComplete);

            if (currentSale != null) 
            { 
                currentSale.IsDone = true; 
                foreach(Product product in currentSale.Products)
                {
                    products.Find(x => x.Name == product.Name).Quantity -= product.Quantity;
                }
            }
        }

        public void ShowStock()
        {
            Console.WriteLine("=== Stock actuel ===");
            foreach (Product product in products) Console.WriteLine(product);
            Console.WriteLine("=====================\n");
        }

        public void ShowSales()
        {
            Console.WriteLine("=== Ventes enregistrées ===");
            foreach (Sale sale in sales) Console.WriteLine(sale);
            Console.WriteLine("=====================\n");
        }
    }
}
