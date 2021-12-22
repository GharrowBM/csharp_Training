using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banque.Classes
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual Client Client { get; set; }
        public virtual List<Operation> Operations { get; set; }

        public Account()
        {
            Operations = new List<Operation>();
        }
    }
}
