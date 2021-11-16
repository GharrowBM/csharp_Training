using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaisseEnregistreuse.Models;

namespace CaisseEnregistreuse.Views
{
    internal class IHM
    {
        private CashRegister workingDevice;

        public IHM()
        {
            Product p1 = new Product("Pomme", 1.54m, 47);
            Product p2 = new Product("Fraise", 4.72m, 18);
            Product p3 = new Product("Poire", 2.42m, 24);
            Product p4 = new Product("Citron", 3.27m, 7);
            Product p5 = new Product("Banane", 2.18m, 25);

            List<Product> baseStock = new List<Product>();

            baseStock.Add(p1);
            baseStock.Add(p2);
            baseStock.Add(p3);
            baseStock.Add(p4);
            baseStock.Add(p5);

            this.workingDevice = new CashRegister(baseStock);
        }

        public void ShowMainMenu()
        {
            Console.Clear();
            workingDevice.ShowStock();
            Console.WriteLine("=== Menu principal ===");
            Console.WriteLine("1---Ajouter un produit dans la caisse");
            Console.WriteLine("2---Faire une vente");
            Console.WriteLine("0---Quitter");
        }

        public void ShowSaleMenu()
        {
            Console.Clear();
            workingDevice.ShowSales();
            Console.WriteLine("=== Nouvelle vente ===");
            Console.WriteLine("1---Paiement par carte");
            Console.WriteLine("2---Paiement en espèces");
        }

        public void Start()
        {
            Console.OutputEncoding = Encoding.UTF8;

            int baseMenuChoice = 1;

            while (baseMenuChoice != 0)
            {
                ShowMainMenu();

                List<Product> productsInCart;

                if (int.TryParse(Console.ReadLine(), out baseMenuChoice))
                {
                    switch (baseMenuChoice)
                    {
                        case 1:
                            Console.WriteLine("=== Nouveau produuit ===");
                            Console.Write("Quel est le nom du produit : ");
                            string productName = Console.ReadLine();

                            if (workingDevice.Products.Find(x => x.Name == productName) == null)
                            {
                                Console.Write($"Quelle est la quantité de base de {productName.ToUpper()} : ");
                                if (int.TryParse(Console.ReadLine(), out int productQuantity))
                                {
                                    Console.Write($"Quel est le prix à l'unité de {productName} : ");
                                    if (decimal.TryParse(Console.ReadLine(), out decimal productPrice))
                                    {
                                        workingDevice.Products.Add(new Product(productName, productPrice, productQuantity));
                                        Console.WriteLine($"{productName} ajouté au stock !");
                                    }
                                    else Console.WriteLine("ERR: Impossible de convertir le prix...");
                                }
                            }

                            break;
                        case 2:

                            List<Product> currentCart = new List<Product>();

                            while(true)
                            {
                                Console.Write("Quel produit voulez-vous ajouter dans le panier (STOP pour arreter l'ajout) : ");
                                string productNameToAddToCart = Console.ReadLine();

                                if (workingDevice.Products.Find(x => x.Name == productNameToAddToCart) != null && productNameToAddToCart.ToUpper() != "STOP")
                                {
                                    Console.Write("Combien en voulez-vous : ");
                                    if (int.TryParse(Console.ReadLine(), out int productQuantity))
                                    {
                                        currentCart.Add(new Product(productNameToAddToCart, workingDevice.Products.Find(x => x.Name == productNameToAddToCart).Price, productQuantity));
                                    }
                                    else Console.WriteLine("ERR: Problème de conversion pour la quantité...");
                                }
                                else if (productNameToAddToCart.ToUpper() == "STOP")
                                {
                                    if (currentCart.Count > 0) workingDevice.CreateSale(currentCart);

                                    ShowSaleMenu();

                                    if (int.TryParse(Console.ReadLine(), out int saleMenuChoice))
                                    {
                                        switch (saleMenuChoice)
                                        {
                                            case 1:
                                                Console.Write("Veuilliez entrer le début de l'ID de la vente à payer : ");
                                                string startofSaleID = Console.ReadLine();
                                                Sale saleToModify = workingDevice.Sales.Find(x => x.Id.StartsWith(startofSaleID));
                                                if (saleToModify != null)
                                                {
                                                    Console.WriteLine($"Vous payez par carte un montant de {saleToModify.CalcTotal()}");
                                                    workingDevice.CompleteSale(saleToModify);

                                                    Console.ReadLine();
                                                }
                                                
                                                break;
                                            case 2:
                                                Console.Write("Veuilliez entrer le début de l'ID de la vente à payer : ");
                                                string startofSaleID2 = Console.ReadLine();
                                                Sale saleToModify2 = workingDevice.Sales.Find(x => x.Id.StartsWith(startofSaleID2));
                                                if (saleToModify2 != null)
                                                {
                                                    Console.WriteLine($"Vous payez par espèces un montant de {saleToModify2.CalcTotal()}");
                                                    workingDevice.CompleteSale(saleToModify2);

                                                    Console.ReadLine();
                                                }
                                                break;
                                            default:
                                                Console.WriteLine("Erreur de choix, veuilliez entrer une valeur entre 1 et 2 compris...");
                                                break;
                                        }
                                    }
                                    else Console.WriteLine("ERR: Problème de conversion...");

                                    break;
                                }
                            }
                            
                            break;
                        case 0:
                            break;
                        default:
                            break;
                    }
                }
                else Console.WriteLine("ERR: Problème de conversion...");
            }
        }
    }
}
