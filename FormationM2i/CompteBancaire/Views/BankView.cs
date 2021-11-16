using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompteBancaire.Models;

namespace CompteBancaire.Views
{
    internal class BankView
    {

        Bank workingBank;

        public BankView(string name)
        {
            this.workingBank = new Bank(name);
        }

        public BankView()
        {
            this.workingBank = new Bank("Default bank");
        }

        public void ShowMenu()
        {
            if (workingBank.BankAccounts.Count > 0) workingBank.ShowBankAccounts();
            Console.WriteLine("--- Menu principal ---");
            Console.WriteLine("1---Créer un compte bancaire");
            Console.WriteLine("2---Modifier un compte bancaire");
            Console.WriteLine("3---Supprimer un compte bancaire");
            Console.WriteLine("0---Quitter le programme");
        }

        public void CreateNewAccount()
        {
            Console.WriteLine("--- Création de nouveau compte ---");
            Console.WriteLine("1---Compte courant");
            Console.WriteLine("2---Compte epargne");
            Console.WriteLine("3---Compte payant");
            Console.WriteLine("0---Annuler");
        }

        public void ModifyAccount(BankAccount account)
        {
            if (account.Operations.Count > 0) account.ShowOperations();
            Console.WriteLine($"--- Modification du compte {account.Id} ---");
            Console.WriteLine("1---Effectuer un dépot");
            Console.WriteLine("2---Effectuer un retrait");
            Console.WriteLine("3---Afficher les opération et le solde");
            Console.WriteLine("0---Quitter le programme");
        }

        public void Start()
        {

            Console.OutputEncoding = Encoding.UTF8;

            int mainMenuChoice = 1;

            while (mainMenuChoice != 0)
            {
                Console.Clear();

                ShowMenu();
                if (int.TryParse(Console.ReadLine(), out mainMenuChoice))
                {
                    switch (mainMenuChoice)
                    {
                        case 1:
                            Console.Clear();

                            CreateNewAccount();

                                if (int.TryParse(Console.ReadLine(), out int createAccountChoice))
                                {
                                    if (createAccountChoice < 4 && createAccountChoice > 0)
                                    {
                                        Console.Write("Veuilliez donner le nom du propriétaire du compte : ");
                                        string tmpClientLName = Console.ReadLine();
                                        Console.Write("Veuilliez donner le prénom du propriétaire du compte : ");
                                        string tmpClientFName = Console.ReadLine();
                                        Console.Write("Veuilliez donner le numéro de téléphone du propriétaire du compte : ");
                                        string tmpClientPhoneNumber = Console.ReadLine();

                                        Console.Write("Veuilliez donner le montant de base du compte : ");
                                        if (decimal.TryParse(Console.ReadLine(), out decimal baseAmount))
                                        {
                                            switch (createAccountChoice)
                                            {
                                                case 1:
                                                    if (workingBank.CreateNewAccount(new BankAccount(new Client(tmpClientLName, tmpClientFName, tmpClientPhoneNumber), baseAmount))) Console.WriteLine("Le compte a été créé !");
                                                    break;
                                                case 2:

                                                    Console.Write("Quel est le montant des intérêts : ");
                                                    if (decimal.TryParse(Console.ReadLine(), out decimal baseRate))
                                                    {
                                                        if (workingBank.CreateNewAccount(new SavingBankAccount(new Client(tmpClientLName, tmpClientFName, tmpClientPhoneNumber), baseAmount, baseRate))) Console.WriteLine("Le compte a été créé !");
                                                    }
                                                    else Console.WriteLine("Le montant entré est invalide, fin de la création de compte...");

                                                    break;
                                                case 3:

                                                    Console.Write("Quel est le montant de base des opérations : ");
                                                    if (decimal.TryParse(Console.ReadLine(), out decimal basePayingAmount))
                                                    {
                                                        if (workingBank.CreateNewAccount(new PaidBankAccount(new Client(tmpClientLName, tmpClientFName, tmpClientPhoneNumber), baseAmount, basePayingAmount))) Console.WriteLine("Le compte a été créé !");
                                                    }
                                                    else Console.WriteLine("Le montant entré est invalide, fin de la création de compte...");

                                                    break;
                                            }

                                        }
                                        else Console.WriteLine("Le montant entré est invalide, fin de la création de compte...");

                                    }
                                    else Console.WriteLine("Le choix doit être entre 0 et 3 compris !");

                                }
                                else Console.WriteLine("ERR: Problème de conversion...");
                            break;
                        case 2:

                            Console.Write("Quel compte souhaitez-vous modifier ? Donnez le début de son ID : ");

                            BankAccount accountToModify = workingBank.BankAccounts.Find(x => x.Id.StartsWith(Console.ReadLine()));

                            if (accountToModify != null)
                            {
                                Console.Clear();

                                ModifyAccount(accountToModify);

                                    if (int.TryParse(Console.ReadLine(), out int modifyAccountChoice))
                                    {
                                        switch (modifyAccountChoice)
                                        {
                                            case 1:
                                                Console.Write("Quel est le montant du dépôt : ");
                                                if (decimal.TryParse(Console.ReadLine(), out decimal deposit))
                                                {
                                                    accountToModify.CreateDeposit(deposit);
                                                } 
                                                else Console.WriteLine("ERR: Problème de conversion...");
                                                break;
                                            case 2:
                                                Console.Write("Quel est le montant du retrait : ");
                                                if (decimal.TryParse(Console.ReadLine(), out decimal withdrawal))
                                                {
                                                    accountToModify.CreateWithdrawal(withdrawal);
                                                }
                                                else Console.WriteLine("ERR: Problème de conversion...");
                                                break;
                                            case 3:
                                                Console.WriteLine($"Opérations sur le compte {accountToModify.Id} : ");
                                                accountToModify.ShowOperations();
                                                break;
                                            case 0:
                                                break;
                                            default:
                                                Console.WriteLine("Le choix doit être entre 0 et 3 compris !");
                                                break;

                                        }
                                    }
                                    else Console.WriteLine("ERR: Problème de conversion...");
                            }
                            else Console.WriteLine("Ce compte n'existe pas...");
                            
                            break;
                        case 3:

                            Console.Write("Quel compte souhaitez-vous supprimer ? Donnez le début de son ID : ");

                            BankAccount accountToDelete = workingBank.BankAccounts.Find(x => x.Id.StartsWith(Console.ReadLine()));

                            if (accountToDelete != null) workingBank.BankAccounts.Remove(accountToDelete);
                            else Console.WriteLine("Ce compte n'existe pas...");

                            break;
                        case 0:
                            break;
                        default:
                            Console.WriteLine("Le choix doit être entre 0 et 3 compris !");
                            break;

                    }
                }
                else Console.WriteLine("ERR: Problème de conversion...");
            }

        }
    }
}
