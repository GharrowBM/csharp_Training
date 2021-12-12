
using Caisse.Classes;
using Caisse.Context;
using System.Text;

CaisseContext context = new CaisseContext();
int mainMenuChoice = -1;
Console.OutputEncoding = Encoding.UTF8;

do
{
    Console.WriteLine("\n=== MAIN MENU ===");
    Console.WriteLine("1. Show Products");
    Console.WriteLine("2. Add Product");
    Console.WriteLine("3. Edit Product");
    Console.WriteLine("4. Remove Product");
    Console.WriteLine("5. Show Sales");
    Console.WriteLine("6. Add Sale");
    Console.WriteLine("7. Edit Sale");
    Console.WriteLine("8. Remove Sale");
    Console.WriteLine("9. Show Categories");
    Console.WriteLine("10. Add Category");
    Console.WriteLine("11. Edit Category");
    Console.WriteLine("12. Remove Category");
    Console.WriteLine("0. Quit");

    if (int.TryParse(Console.ReadLine(), out mainMenuChoice))
    {
        switch (mainMenuChoice)
        {
            case 1:
                foreach (var product in context.GetAllProducts()) Console.WriteLine(product);
                break;
            case 2:
                Console.Write("\nName: ");
                string newProductName = Console.ReadLine();
                if (context.GetAllProducts().Find(p => p.Name == newProductName) == null)
                {
                    Console.Write("\nDescription: ");
                    string newProductDesc = Console.ReadLine();
                    Console.Write("\nStock: ");
                    if (int.TryParse(Console.ReadLine(), out int newProductStock))
                    {
                        Console.Write("\nPrice: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal newProductPrice))
                        {
                            Console.Write("\nCategory ID: ");
                            if (int.TryParse(Console.ReadLine(), out int newProductCatId))
                            {
                                Category c = context.GetCategoryById(newProductCatId);
                                if (c != null)
                                {
                                    Product newProduct = new Product()
                                    {
                                        Name = newProductName,
                                        Description = newProductDesc,
                                        Stock = newProductStock,
                                        Price = newProductPrice,
                                        CategoryId = newProductCatId,
                                        Category = c
                                    };
                                    if (context.AddProduct(newProduct)) Console.WriteLine("Product added with success!");
                                }
                                else
                                {
                                    Console.WriteLine("This category ID doesn't exists!");
                                }
                            }

                        }

                    }
                }
                else
                {
                    Console.WriteLine("This product already exists!");
                }

                break;
            case 3:
                Console.Write("\nID: ");
                if (int.TryParse(Console.ReadLine(), out int prodIdToEdit))
                {
                    Product p = context.GetAllProducts().Find(p => p.Id == prodIdToEdit);
                    if (p != null)
                    {
                        Console.Write("\nNew Name: ");
                        string prodEditNewName = Console.ReadLine();
                        if (context.GetAllProducts().Find(p => p.Name == prodEditNewName) == null)
                        {
                            Console.Write("\nNew Description: ");
                            string productEditNewDesc = Console.ReadLine();
                            Console.Write("\nNew Stock: ");
                            if (int.TryParse(Console.ReadLine(), out int prodEditNewStock))
                            {
                                Console.Write("\nNew Price: ");
                                if (decimal.TryParse(Console.ReadLine(), out decimal prodEditNewPrice))
                                {
                                    Console.Write("\nNew Category ID: ");
                                    if (int.TryParse(Console.ReadLine(), out int productEditNewCatId))
                                    {
                                        Category c = context.GetCategoryById(productEditNewCatId);
                                        if (c != null)
                                        {
                                            p.Name = prodEditNewName;
                                            p.Description = productEditNewDesc;
                                            p.Stock = prodEditNewStock;
                                            p.Price = prodEditNewPrice;
                                            p.CategoryId = productEditNewCatId;
                                            p.Category = c;
                                            if (context.UpdateProduct(p)) Console.WriteLine("Product edited with success!");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Category missing!");
                                        }
                                    }

                                }

                            }

                        }
                        else
                        {
                            Console.WriteLine("Product already exists!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("This product doesn't exists!");
                    }
                }
                break;
            case 4:
                Console.Write("\nID: ");
                if (int.TryParse(Console.ReadLine(), out int prodIdToRemove))
                {
                    Product p = context.GetAllProducts().Find(p => p.Id == prodIdToRemove);
                    if (p != null)
                    {
                        if (context.DeleteProduct(p)) Console.WriteLine("Product deleted with success!");
                    }
                    else
                    {
                        Console.WriteLine("This product doesn't exists!");
                    }
                }
                break;
            case 5:
                foreach (var sale in context.GetAllSales()) Console.WriteLine(sale);
                break;
            case 6:
                Sale saleToAdd = new Sale();
                int productIdToAddToSale = -1;
                do
                {
                    Console.Write("Product ID (0 to stop): ");
                    if (int.TryParse(Console.ReadLine(), out productIdToAddToSale))
                    {
                        if (productIdToAddToSale != 0)
                        {
                            Product p = context.GetProductByID(productIdToAddToSale);
                            if (p != null)
                            {
                                saleToAdd.AddProduct(p);
                            }
                            else
                            {
                                Console.WriteLine("Product missing!");
                            }
                        }
                        else 
                        {
                            if (saleToAdd.CompleteSale())
                            {
                                context.AddSale(saleToAdd);
                                context.SaveChanges();
                                Console.WriteLine("Sale completed!");
                            }
                        }
                    }
                } while (productIdToAddToSale != 0);
                break;
            case 7:
                break;
            case 8:
                Console.Write("\nID: ");
                if (int.TryParse(Console.ReadLine(), out int saleIdToDelete))
                {
                    Sale saleToDelete = context.GetSaleByID(saleIdToDelete);
                    if (saleToDelete != null)
                    {
                        if (context.DeleteSale(saleToDelete)) Console.WriteLine("Sale deleted with success!");
                    }
                }
                break;
            case 9:
                foreach (var category in context.GetAllCategories()) Console.WriteLine(category);
                break;
            case 10:
                Console.Write("\nName: ");
                string newCatName = Console.ReadLine();
                if (!string.IsNullOrEmpty(newCatName))
                {
                    if (context.GetAllCategories().Find(c => c.Name == newCatName) == null)
                    {
                        if (context.AddCategory(new Category { Name = newCatName })) Console.WriteLine("Category added with succes!");
                    }
                    else
                    {
                        Console.WriteLine("This category already exists!");
                    }
                }
                else
                {
                    Console.WriteLine("Category name can't be empty!");
                }
                break;
            case 11:
                Console.Write("\nID: ");
                if (int.TryParse(Console.ReadLine(), out int catIDToEdit))
                {
                    Category c = context.GetCategoryById(catIDToEdit);
                    if (c != null)
                    {
                        Console.Write("\nNew name: ");
                        string newCatEditedName = Console.ReadLine();
                        if (!string.IsNullOrEmpty(newCatEditedName))
                        {
                            if (context.GetAllCategories().Find(c => c.Name == newCatEditedName) == null)
                            {
                                c.Name = newCatEditedName;
                                if (context.UpdateCategory(c)) Console.WriteLine("Category edited with succes!");
                            }
                            else
                            {
                                Console.WriteLine("Category already exists!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Category name can't be empty!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Category missing!");
                    }
                }
                break;
            case 12:
                Console.Write("\nID: ");
                if (int.TryParse(Console.ReadLine(), out int catIDToDelete))
                {
                    Category c = context.GetCategoryById(catIDToDelete);
                    if (c != null)
                    {
                        if (context.DeleteCategory(c)) Console.WriteLine("Category deleted with succes!");
                    }
                    else
                    {
                        Console.WriteLine("Category missing!");
                    }
                }
                break;
            case 0:
                break;
            default:
                Console.WriteLine("That choice doesn't exist !");
                break;
        }
    }

} while (mainMenuChoice != 0);
