using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace CompteBancaire.Models
{
    internal class Operation
    {
        private string  id;
        private decimal amount;

        public decimal Amount { get { return amount; } }

        public Operation(decimal amount)
        {
            this.amount = amount;
            this.id = Guid.NewGuid().ToString();
        }

        public override string ToString()
        {
            return $"{id} - {amount.ToString("C", CultureInfo.CurrentCulture)}";
        }
    }
}
