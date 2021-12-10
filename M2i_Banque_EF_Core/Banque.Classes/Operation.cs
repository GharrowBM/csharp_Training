using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banque.Classes
{
    public class Operation
    {
        public int Id { get; set; }
        public DateTime DateOfOperation { get; set; }
        public decimal Amount { get; set; }

        public virtual Account Account { get; set; }

        public Operation()
        {

        }

        public Operation(decimal amount)
        {
            Amount = amount;
            DateOfOperation = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{Id}. {DateOfOperation.ToString("d")} - ({Amount.ToString("C", CultureInfo.CurrentCulture)})";
        }
    }
}
