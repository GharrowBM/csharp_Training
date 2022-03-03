using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using Packt.DotNet6.EFClasses;
using Packt.DotNet6.EFClasses.Datas;
using Packt.DotNet6.EFConsoleApp;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

FilterAndSort();

//Console.WriteLine($"Using SQLServer database provider.");
//ManipulationOfProducts();

#region Linq with EF Core and New Classes

static void FilterAndSort()
{
    using (Northwind db = new())
    {
        //DbSet<Product> allProducts = db.Products;
        //IQueryable<Product> filteredProducts =
        //  allProducts.Where(product => product.UnitPrice < 10M);
        //IOrderedQueryable<Product> sortedAndFilteredProducts =
        //  filteredProducts.OrderByDescending(product => product.UnitPrice);

        IOrderedQueryable<Product> sortedAndFilteredProducts = db.Products
            .Where(product => product.UnitPrice < 10M)
            .OrderByDescending(product => product.UnitPrice);

        Console.WriteLine("Products that cost less than $10:");
        foreach (Product p in sortedAndFilteredProducts)
        {
            Console.WriteLine("{0}: {1} costs {2:$#,##0.00}",
              p.ProductId, p.ProductName, p.UnitPrice);
        }
        Console.WriteLine();
    }
}

#endregion

#region Linq Examples

static void DefferedExecutionExample()
{
    // Linq ne récupère pas directement les valeurs demandé mais met en attente une requête
    // qui sera executée lors d'un ForEach ou lors de l'utilisation de l'une des méthodes .ToSomth()

    // a string array is a sequence that implements IEnumerable<string>
    string[] names = new[] { "Michael", "Pam", "Jim", "Dwight", "Angela", "Kevin", "Toby", "Creed" };
    Console.WriteLine("Deferred execution");
    // Question: Which names end with an M?
    // (written using a LINQ extension method)
    var query1 = names.Where(name => name.EndsWith("m"));
    // Question: Which names end with an M?
    // (written using LINQ query comprehension syntax)
    var query2 = from name in names where name.EndsWith("m") select name;

    // Answer returned as an array of strings containing Pam and Jim
    string[] result1 = query1.ToArray();
    // Answer returned as a list of strings containing Pam and Jim
    List<string> result2 = query2.ToList();
    // Answer returned as we enumerate over the results
    foreach (string name in query1)
    {
        Console.WriteLine(name); // outputs Pam
        names[2] = "Jimmy"; // change Jim to Jimmy
                            // on the second iteration Jimmy does not end with an M
    }

    var query = names.Where(name => name.Length > 4);

    foreach (string item in query)
    {
        Console.WriteLine(item);
    }

    query = names
        .Where(name => name.Length > 4)
        .OrderBy(name => name.Length)
        .ThenBy(name => name);

    foreach (string item in query)
    {
        Console.WriteLine(item);
    }
}

static void SetsBagsExample()
{
    void Output(IEnumerable<string> cohort, string description = "")
    {
        if (!string.IsNullOrEmpty(description))
        {
            Console.WriteLine(description);
        }
        Console.Write(" ");
        Console.WriteLine(string.Join(", ", cohort.ToArray()));
        Console.WriteLine();
    }

    string[] cohort1 = new[] { "Rachel", "Gareth", "Jonathan", "George" };
    string[] cohort2 = new[] { "Jack", "Stephen", "Daniel", "Jack", "Jared" };
    string[] cohort3 = new[] { "Declan", "Jack", "Jack", "Jasmine", "Conor" };

    Output(cohort1, "Cohort 1");
    Output(cohort2, "Cohort 2");
    Output(cohort3, "Cohort 3");
    Output(cohort2.Distinct(), "cohort2.Distinct()");
    Output(cohort2.DistinctBy(name => name.Substring(0, 2)),
      "cohort2.DistinctBy(name => name.Substring(0, 2)):");
    Output(cohort2.Union(cohort3), "cohort2.Union(cohort3)");
    Output(cohort2.Concat(cohort3), "cohort2.Concat(cohort3)");
    Output(cohort2.Intersect(cohort3), "cohort2.Intersect(cohort3)");
    Output(cohort2.Except(cohort3), "cohort2.Except(cohort3)");
    Output(cohort1.Zip(cohort2, (c1, c2) => $"{c1} matched with {c2}"),
      "cohort1.Zip(cohort2)");
}

#endregion

#region EF Core Examples with Old Classes

//static void ManipulationOfProducts()
//{
//    void ListProducts()
//    {
//        using (Northwind db = new())
//        {
//            Console.WriteLine("{0,-3} {1,-35} {2,8} {3,5} {4}",
//              "Id", "Product Name", "Cost", "Stock", "Disc.");
//            foreach (Product p in db.Products
//              .OrderByDescending(product => product.Cost))
//            {
//                Console.WriteLine("{0:000} {1,-35} {2,8:$#,##0.00} {3,5} {4}",
//                  p.ProductId, p.ProductName, p.Cost, p.Stock, p.Discontinued);
//            }
//        }
//    }

//    bool AddProduct(int categoryId, string productName, decimal? price)
//    {
//        using (Northwind db = new())
//        {
//            Product p = new()
//            {
//                CategoryId = categoryId,
//                ProductName = productName,
//                Cost = price
//            };
//            // Marque le produit comme Ajouté pour le tracking des changements
//            db.Products.Add(p);

//            // Sauvegarde des objets traqués dans la BdD
//            int affected = db.SaveChanges();
//            return (affected == 1);
//        }
//    }

//    void AddProductTest()
//    {
//        if (AddProduct(categoryId: 6, productName: "Bob's Burgers", price: 500M))
//        {
//            Console.WriteLine("Add product successful.");
//        }

//        Console.WriteLine();
//        ListProducts();
//    }

//    bool IncreaseProductPrice(string productNameStartsWith, decimal amount)
//    {
//        using (Northwind db = new())
//        {
//            // Obtention du premier objet commençant par cette string
//            Product updateProduct = db.Products.First(
//              p => p.ProductName.StartsWith(productNameStartsWith));
//            updateProduct.Cost += amount;
//            int affected = db.SaveChanges();
//            return (affected == 1);
//        }
//    }

//    void UpdateProductTest()
//    {
//        if (IncreaseProductPrice(productNameStartsWith: "Bob", amount: 20M))
//        {
//            Console.WriteLine("Update product price successful.");
//        }

//        Console.WriteLine();
//        ListProducts();
//    }

//    int DeleteProducts(string productNameStartsWith)
//    {
//        using (Northwind db = new())
//        {
//            // Utilisation d'une transaction pour éviter les problèmes de logique interne
//            using (IDbContextTransaction t = db.Database.BeginTransaction())
//            {
//                Console.WriteLine("Transaction isolation level: {0}",
//                  arg0: t.GetDbTransaction().IsolationLevel);

//                // Récupération des produits correspondant à la recherche
//                IQueryable<Product>? products = db.Products?.Where(
//              p => p.ProductName.StartsWith(productNameStartsWith));
//                if (products is null)
//                {
//                    Console.WriteLine("No products found to delete.");
//                    return 0;
//                }
//                else
//                {
//                    // Suppression de la série de produits récupérés précédemment de la liste des produits
//                    db.Products.RemoveRange(products);
//                }

//                // Sauvegarde des changements
//                int affected = db.SaveChanges();
//                t.Commit(); // Réalisation de l'ensemble de la transaction
//                return affected;
//            }
//        }
//    }

//    void DeleteProductTest()
//    {
//        int deleted = DeleteProducts(productNameStartsWith: "Bob");
//        Console.WriteLine($"{deleted} product(s) were deleted.");

//        Console.WriteLine();
//        ListProducts();
//    }

//}

//static void QueryingWithLike()
//{
//    using (Northwind db = new())
//    {
//        ILoggerFactory loggerFactory = db.GetService<ILoggerFactory>();
//        loggerFactory.AddProvider(new ConsoleLoggerProvider());

//        Console.Write("Entrez une partie du nom de produit : ");
//        string? input = Console.ReadLine();
//        IQueryable<Product>? products = db.Products?
//          .Where(p => EF.Functions.Like(p.ProductName, $"%{input}%"));
//        if (products is null)
//        {
//            Console.WriteLine("Aucun produit trouvé.");
//            return;
//        }
//        foreach (Product p in products)
//        {
//            Console.WriteLine("{0} a {1} unités en stock. Abandonné ? {2}",
//              p.ProductName, p.Stock, p.Discontinued);
//        }
//    }
//}

//static void QueryingProducts()
//{
//    using (Northwind db = new())
//    {
//        ILoggerFactory loggerFactory = db.GetService<ILoggerFactory>();
//        loggerFactory.AddProvider(new ConsoleLoggerProvider());

//        Console.WriteLine("Produits coutant plus de X, les plus chers en premier :");
//        string? input;
//        decimal price;
//        do
//        {
//            Console.Write("Donnez un prix de produit : ");
//            input = Console.ReadLine();
//        } while (!decimal.TryParse(input, out price));

//        IQueryable<Product>? products = db.Products?
//            .TagWith("Products filtered by price and sorted.")
//            .Where(product => product.Cost > price) // Tri de la liste des produits basée sur leur coût
//            .OrderByDescending(product => product.Cost); // Tri des produits de façon descendante basée sur leur prix

//        if (products is null)
//        {
//            Console.WriteLine("Aucun produit trouvé.");
//            return;
//        }
//        foreach (Product p in products)
//        {
//            Console.WriteLine($"{p.ProductId}: {p.ProductName} coute {p.Cost:C2} et a un stock de {p.Stock} unités.");
//        }
//    }
//}

//static void QueryingCategories()
//{
//    using (Northwind db = new())
//    {
//        ILoggerFactory loggerFactory = db.GetService<ILoggerFactory>();
//        loggerFactory.AddProvider(new ConsoleLoggerProvider());

//        Console.WriteLine("Catégories et leurs produits:");

//        // Une requête pour obtenir toutes les catégories et leurs produits
//        IQueryable<Category>? categories = db.Categories?
//            .Include(c => c.Products); // Inclusion des Produits via les propriétés de Navigation

//        if (categories is null)
//        {
//            Console.WriteLine("Aucune catégorie trouvée.");
//            return;
//        }

//        // Execution de la requête et énumération du résultat
//        foreach (Category c in categories)
//        {
//            Console.WriteLine($"{c.CategoryName} a {c.Products.Count} produits.");
//        }
//    }
//}

//static void FilteredIncludes()
//{
//    using (Northwind db = new())
//    {
//        Console.Write("Entrez un stock minimal : ");
//        string unitsInStock = Console.ReadLine() ?? "10";
//        int stock = int.Parse(unitsInStock);

//        // Tri des produits de la catégorie ayant un stock supérieur ou égal à la valeur demandée
//        IQueryable<Category>? categories = db.Categories?
//            .Include(c => c.Products.Where(p => p.Stock >= stock)); // Inclusion des produits ayant comme stock une valeur supérieur à celle entrée

//        if (categories is null)
//        {
//            Console.WriteLine("Aucune catégorie trouvée.");
//            return;
//        }

//        Console.WriteLine($"ToQueryString: {categories.ToQueryString()}");

//        Console.WriteLine();
//        foreach (Category c in categories)
//        {
//            Console.WriteLine($"{c.CategoryName} a {c.Products.Count} produits avec un stock minimal de {stock} unités.");
//            foreach (Product p in c.Products)
//            {
//                Console.WriteLine($"  {p.ProductName} a {p.Stock} unités en stock.");
//            }
//        }
//    }
//}

#endregion