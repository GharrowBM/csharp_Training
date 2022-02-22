using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test01.Classes
{
    internal class MyComrade : ICustom
    {
        private string _fistName;
        private string _lastName;
        private DateTime _dateOfBirth;

        public string FirstName { get => _fistName; set => _fistName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }

        public DateTime DateOfBirth => throw new NotImplementedException();

        public int GetAge()
        {
            throw new NotImplementedException();
        }

        public void Print()
        {
            throw new NotImplementedException();
        }

        public void Say(string something)
        {
            throw new NotImplementedException();
        }
    }
}
