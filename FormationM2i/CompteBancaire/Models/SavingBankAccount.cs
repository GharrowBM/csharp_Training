using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompteBancaire.Models
{
    internal class SavingBankAccount : BankAccount
    {
        private decimal rate;

        public SavingBankAccount(Client owner) : base(owner)
        {
            this.rate = 1.5m;
        }

        public SavingBankAccount(Client owner, decimal balance, decimal rate) : base(owner, balance)
        {
            this.rate = rate;
        }

        public void CalcGrowth()
        {
            this.balance += this.balance * this.rate;
        }
    }
}
