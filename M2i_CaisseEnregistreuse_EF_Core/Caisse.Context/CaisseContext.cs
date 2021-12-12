using Caisse.Classes;
using Microsoft.EntityFrameworkCore;

namespace Caisse.Context
{
    public class CaisseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(SecretConnection.ConnectionString);
        }

        private DbSet<Product> Products { get; set; }
        private DbSet<Sale> Sales { get; set; }
        private DbSet<Category> Categories { get; set; }

        public bool AddProduct(Product p)
        {
            if (p != null)
            {
                Products.Add(p);
                this.SaveChanges();
                return true;
            }

            return false;
        }

        public bool AddSale(Sale s)
        {
            if (s != null)
            {
                Sales.Add(s);
                this.SaveChanges();
                return true;
            }

            return false;
        }

        public bool AddCategory(Category c)
        {
            if (c != null)
            {
                Categories.Add(c);
                this.SaveChanges();
                return true;
            }

            return false;
        }

        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();

            foreach (var product in Products.Include(p => p.RelatedSales).Include(p => p.Category)) products.Add(product);

            return products;
        }

        public Product GetProductByID(int id)
        {
            Product product = default(Product);

            product = Products.FirstOrDefault(p => p.Id == id);

            return product;
        }

        public List<Product> GetProductsByCategoryID(int id)
        {
            List<Product> products = new List<Product>();

            foreach (var product in Products.Include(p => p.RelatedSales).Include(p => p.Category).Where(p => p.CategoryId == id)) products.Add(product);

            return products;
        }

        public List<Sale> GetAllSales()
        {
            List<Sale> sales = new List<Sale>();

            foreach (var sale in Sales.Include(s => s.Products)) sales.Add(sale);

            return sales;
        }

        public Sale GetSaleByID(int id)
        {
            Sale sale = default(Sale);

            sale = Sales.FirstOrDefault(s => s.Id == id);

            return sale;
        }

        public List<Category> GetAllCategories()
        {
            List<Category> categories = new List<Category>();

            foreach (var category in Categories.Include(c => c.Products)) categories.Add(category);

            return categories;
        }

        public Category GetCategoryById(int id)
        {
            Category category = default(Category);

            category = Categories.FirstOrDefault(c => c.Id == id);

            return category;
        }

        public bool UpdateProduct(Product p)
        {
            if (p != null)
            {
                Products.Update(p);
                return true;
            }

            return false;
        }

        public bool UpdateSale(Sale s)
        {
            if (s != null)
            {
                Sales.Update(s);
                return true;
            }

            return false;
        }

        public bool UpdateCategory(Category c)
        {
            if (c != null)
            {
                Categories.Update(c);
                return true;
            }

            return false;
        }

        public bool DeleteProduct(Product p)
        {
            if (p != null)
            {
                Products.Remove(p);
                this.SaveChanges();
                return true;
            }

            return false;
        }

        public bool DeleteSale(Sale s)
        {
            if (s != null)
            {
                Sales.Remove(s);
                this.SaveChanges();
                return true;
            }

            return false;
        }

        public bool DeleteCategory(Category c)
        {
            if (c != null)
            {
                Categories.Remove(c);
                this.SaveChanges();
                return true;
            }

            return false;
        }
    }
}