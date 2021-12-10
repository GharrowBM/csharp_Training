using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banque.Classes
{
    public class Client
    {
        public int Id { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public DateTime JoinedAt { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public virtual List<Account> Accounts { get; set; }

        public Client()
        {

        }

        public Client(string lastname, string firstname, string phoneNumber, string email)
        {
            Lastname = lastname;
            Firstname = firstname;
            PhoneNumber = phoneNumber;
            Email = email;
            JoinedAt = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{Id}. {Lastname} {Firstname}, {Accounts.Count} account(s)";
        }
    }
}
