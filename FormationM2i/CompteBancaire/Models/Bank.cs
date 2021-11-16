using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompteBancaire.Models
{
    internal class Bank
    {
        private List<BankAccount> bankAccounts;
        private string name;

        internal List<BankAccount> BankAccounts { get => bankAccounts;}

        public Bank (string name)
        {
            this.name = name;
            bankAccounts = new List<BankAccount> ();
        }

        public bool CreateNewAccount(BankAccount account)
        {
            bankAccounts.Add (account);
            return true;
        }

        public bool CreateNewSavingAccount(SavingBankAccount account)
        {
            bankAccounts.Add(account);
            return true;
        }

        public bool CreateNewPaidAccount(PaidBankAccount account)
        {
            bankAccounts.Add(account);
            return true;
        }

        public bool DeleteAccount(BankAccount account)
        {
            bankAccounts.Remove(account);
            return true;
        }

        public void ShowBankAccounts()
        {
            Console.WriteLine("=== Liste des comptes ===");
            foreach (BankAccount bankAccount in bankAccounts) Console.WriteLine(bankAccount);
            Console.WriteLine("================\n");
        }
    }
}
