using Banque.Classes;
using Banque.Context;
using Microsoft.EntityFrameworkCore;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

BankDbContext context = new BankDbContext();

int mainMenuChoice = -1;
int nbRows = 0;

do
{
    Console.WriteLine("=== MENU PRINCIPAL ===");
    Console.WriteLine("1. Voir les clients");
    Console.WriteLine("2. Ajouter un client");
    Console.WriteLine("3. Modifier un client");
    Console.WriteLine("4. Supprimer un client");
    Console.WriteLine("5. Voir les comptes");
    Console.WriteLine("6. Ajouter un compte");
    Console.WriteLine("7. Modifier un compte");
    Console.WriteLine("8. Supprimer un compte");
    Console.WriteLine("9. Faire une opération sur un compte");
    Console.WriteLine("10. Voir les opérations sur un compte");
    Console.WriteLine("0. Quitter");

    if (int.TryParse(Console.ReadLine(), out mainMenuChoice))
    {

        switch (mainMenuChoice)
        {
            case 1:
                foreach (Client client in context.Clients.Include(c=>c.Accounts)) Console.WriteLine(client);
                break;
            case 2:
                Console.Write("Quel nom : ");
                string tmpFirstname = Console.ReadLine();
                Console.Write("Quel prénom : ");
                string tmpLastname = Console.ReadLine();
                Console.Write("Quel numéro de téléphone : ");
                string tmpPhoneNumber = Console.ReadLine();
                Console.Write("Quel émail : ");
                string tmpEmail = Console.ReadLine();
                context.Clients.Add(new Client(tmpLastname, tmpFirstname, tmpPhoneNumber, tmpEmail));
                nbRows = context.SaveChanges();
                if (nbRows > 0) Console.WriteLine("Client ajouté avec succès");
                break;
            case 3:
                Console.Write("Donnez l'ID du client à modifier : ");
                if (int.TryParse(Console.ReadLine(), out int clientIdToFind))
                {
                    Client? c = context.Clients.FirstOrDefault(c => c.Id == clientIdToFind);
                    if (c != null)
                    {
                        Console.Write("Nouveau nom : ");
                        c.Lastname = Console.ReadLine();
                        Console.Write("Nouveau prénom : ");
                        c.Firstname = Console.ReadLine();
                        Console.Write("Nouveau numéro de téléphone : ");
                        c.PhoneNumber = Console.ReadLine();
                        Console.Write("Nouvel émail : ");
                        c.Email = Console.ReadLine();
                        nbRows = context.SaveChanges();
                        if (nbRows > 0) Console.WriteLine("Client modifié avec succès");
                    }
                    else
                    {
                        Console.WriteLine("Client introuvable...");
                    }
                }
                break;
            case 4:
                Console.Write("Quel est l'ID du client à supprimer : ");
                if (int.TryParse(Console.ReadLine(), out int clientIdToDelete))
                {
                    Client? c = context.Clients.FirstOrDefault(c => c.Id == clientIdToDelete);
                    if (c != null) context.Clients.Remove(c);
                    nbRows = context.SaveChanges();
                    if (nbRows > 0) Console.WriteLine("Client supprimé avec succès");
                    else Console.WriteLine("Aucune suppression, êtes vous sur d'avoir mis le bon ID ?");
                }
                else
                {
                    Console.WriteLine("ERR: Valeur incorrecte, abandon de l'opération");
                }
                break;
            case 5:
                foreach (Account account in context.Accounts.Include(a=> a.Client).Include(a => a.Operations)) Console.WriteLine(account);
                break;
            case 6:
                Console.Write("Quel est l'ID du client titulaire du compte : ");
                if (int.TryParse(Console.ReadLine(), out int ownerIdToFind))
                {
                    Client? c = context.Clients.Include(c=>c.Accounts).FirstOrDefault(c => c.Id == ownerIdToFind);
                    if (c != null)
                    {
                        Console.Write("Quel est le nom du compte : ");
                        string tmpAccountName = Console.ReadLine();
                        c.Accounts.Add(new Account(c, tmpAccountName));
                    }
                    nbRows = context.SaveChanges();
                    if (nbRows > 0) Console.WriteLine("Compte ajouté avec succès");
                }
                else
                {
                    Console.WriteLine("ERR: Valeur incorrecte, abandon de l'opération");
                }
                break;
            case 7:
                Console.Write("Quel est l'ID du compte à modifier : ");
                if (int.TryParse(Console.ReadLine(), out int acountIdToFind))
                {
                    Account? a = context.Accounts.FirstOrDefault(a => a.Id == acountIdToFind);
                    if (a != null)
                    {
                        Console.Write("Nouveau nom : ");
                        a.Name = Console.ReadLine();
                        nbRows = context.SaveChanges();
                        if (nbRows > 0) Console.WriteLine("Compte modifié avec succès");
                    }
                    else
                    {
                        Console.WriteLine("Compte introuvable...");
                    }
                }
                break;
            case 8:
                Console.Write("Quel est l'ID du compte à supprimer : ");
                if (int.TryParse(Console.ReadLine(), out int accountDdToDelete))
                {
                    Account? a = context.Accounts.FirstOrDefault(a => a.Id == accountDdToDelete);
                    if (a != null) context.Accounts.Remove(a);
                    nbRows = context.SaveChanges();
                    if (nbRows > 0) Console.WriteLine("Compte supprimé avec succès");
                    else Console.WriteLine("Aucune suppression, êtes vous sur d'avoir mis le bon ID ?");
                }
                else
                {
                    Console.WriteLine("ERR: Valeur incorrecte, abandon de l'opération");
                }
                break;
            case 9:
                Console.Write("Quel est l'ID du compte : ");
                if (int.TryParse(Console.ReadLine(), out int accountIdToRecover)) 
                {
                    Account? a = context.Accounts.Include(a => a.Operations).FirstOrDefault(a => a.Id == accountIdToRecover);
                    if (a!= null)
                    {
                        Console.WriteLine("=== Opérations disponibles ===");
                        Console.WriteLine("1. Retrait");
                        Console.WriteLine("2. Dépôt");
                        if (int.TryParse(Console.ReadLine(), out int typeOfOperation))
                        {
                            Console.Write("Quel est le montant de l'opération : ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal amountOFOperation))
                            {
                                if (typeOfOperation == 1)
                                {
                                    a.Operations.Add(new Operation(-amountOFOperation));
                                }
                                else if (typeOfOperation == 2)
                                {
                                    a.Operations.Add(new Operation(amountOFOperation));
                                }
                                context.SaveChanges();
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("ERR: Ce compte n'existe pas !");
                    }
                }
                else
                {
                    Console.WriteLine("ERR: Valeur incorrecte, abandon de l'opération");
                }
                    break;
            case 10:
                Console.Write("Quel est l'ID du compte : ");
                if (int.TryParse(Console.ReadLine(), out int accountIdToRecoverFOrOperations))
                {
                    Account? a = context.Accounts.Include(a => a.Operations).FirstOrDefault(a => a.Id == accountIdToRecoverFOrOperations);
                    if (a != null)
                    {
                        a.ShowOperations();
                    }
                    else
                    {
                        Console.WriteLine("ERR: Ce compte n'existe pas !");
                    }
                }
                else
                {
                    Console.WriteLine("ERR: Valeur incorrecte, abandon de l'opération");
                }
                break;
            case 0:
                break;
            default:
                Console.WriteLine("ERR: Ce choix n'est pas parmis ceux proposés...");
                break;
        }

    }
    else
    {
        Console.WriteLine("ERR : Le nombre n'est pas un nombre correct...");
    }

} while (mainMenuChoice != 0);





