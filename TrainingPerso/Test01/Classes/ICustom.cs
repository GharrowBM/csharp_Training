using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test01.Classes
{
    internal interface ICustom
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; }

        public void Print();
        public void Say(string something);
        public int GetAge();
    }
}
