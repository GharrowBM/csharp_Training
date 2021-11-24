using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanqueTest.Models
{
    internal class Client
    {
        public string Id { get; }
        public string Name { get; set; }
        public string FName { get; set; }
        public string PhoneNumber { get; set; }

        public Client(string name, string fName, string phoneNumber)
        {
            Name = name;
            FName = fName;
            PhoneNumber = phoneNumber;
        }

    }
}
