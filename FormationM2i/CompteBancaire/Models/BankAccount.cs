using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace CompteBancaire.Models
{
    internal class BankAccount
    {
        private string id;
        protected decimal balance;
        protected Client owner;
        protected List<Operation> operations;

        public string Id { get => id; }
        public List<Operation> Operations { get => operations;}

        public BankAccount(Client owner)
        {
            this.id = Guid.NewGuid().ToString();
            this.owner = owner;
            this.balance = 0.0m;
            this.operations = new List<Operation>();
        }

        public BankAccount(Client owner, decimal balance)
        {
            this.id = Guid.NewGuid().ToString();
            this.owner = owner;
            this.balance = balance;
            this.operations = new List<Operation>();
        }
        public override string ToString()
        {
            return $"ID : {id} - Propriétaire : {owner} - Solde : {balance.ToString("C", CultureInfo.CurrentCulture)}";
        }
        public void UpdateBalance()
        {
            foreach (Operation operation in operations)
            {
                this.balance += operation.Amount;
            }
        }

        public bool CreateDeposit(decimal amount)
        {
            operations.Add(new Operation(amount));
            UpdateBalance();
            return true;
        }

        public bool CreateWithdrawal(decimal amount)
        {
            operations.Add(new Operation(-amount));
            UpdateBalance();
            return true;
        }

        public void ShowOperations()
        {
            Console.WriteLine("=== Liste des opérations ===");
            foreach (Operation op in operations) Console.WriteLine(op.ToString());
            Console.WriteLine("================\n");
        }
    }
}
