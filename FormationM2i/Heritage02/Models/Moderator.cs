using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heritage02.Models
{
    internal class Moderator : Follower
    {
        public Moderator(string lastName, string firstName, int age) : base(lastName, firstName, age)
        {

        }
    }
}
