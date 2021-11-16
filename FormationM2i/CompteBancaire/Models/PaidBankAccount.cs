using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompteBancaire.Models
{
    internal class PaidBankAccount : BankAccount
    {
        private decimal payingAmount;

        public PaidBankAccount(Client owner) : base(owner)
        {
            this.payingAmount = 2.0m;
        }

        public PaidBankAccount(Client owner, decimal balance, decimal payingAmount) : base(owner, balance)
        {
            this.payingAmount = payingAmount;
        }
    }
}
