using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Banque.Classes
{
    public class Account
    {
        private decimal _balance;

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Balance 
        { 
            get 
            {
                decimal balance = 0.0m;
                foreach (Operation op in Operations) balance += op.Amount;
                return balance;
            } 
            set => _balance = value; 
        }

        public virtual Client Client { get; set; }
        public virtual List<Operation> Operations { get; set; }

        public Account()
        {

        }

        public Account (Client client, string name)
        {
            Client = client;
            Name = name;
        }

        public override string ToString()
        {
            return $"{Id}. {Name} (Owned by {Client.Firstname.Substring(0,1)}.{Client.Lastname.Substring(0,1)}.) {Balance.ToString("C", CultureInfo.CurrentCulture)}";
        }

        public void ShowOperations()
        {
            foreach (Operation op in Operations) Console.WriteLine(op.ToString());
        }
    }
}