using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heritage02.Models
{
    internal class Follower
    {
        private string id;
        private string lastName;
        private string firstName;
        private int age;

        public Follower(string lastName, string firstName, int age)
        {
            this.id = Guid.NewGuid().ToString();
            this.lastName = lastName;
            this.firstName = firstName;
            this.age = age;
        }

        public virtual News CreateNews(string subject, string desc)
        {
            return new News(subject, desc);
        }
    }
}
