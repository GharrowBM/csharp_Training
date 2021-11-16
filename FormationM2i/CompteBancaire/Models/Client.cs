using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompteBancaire.Models
{
    internal class Client
    {
        private string lastName;
        private string firstName;
        private string phoneNumer;

        public Client (string lastName, string firstName, string phoneNumer)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.phoneNumer = phoneNumer;
        }

        public override string ToString()
        {
            return $"{firstName.Substring(0,1).ToUpper() + firstName.Substring(1,firstName.Length -1)} {lastName.ToUpper()} - Phone: {phoneNumer}";
        }
    }
}
