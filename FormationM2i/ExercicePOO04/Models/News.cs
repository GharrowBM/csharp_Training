using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicePOO04
{
    internal class News
    {
        private string subject;
        private string body;

        public News (string subject, string body)
        {
            this.subject = subject;
            this.body = body;
        }

        public override string ToString()
        {
            return $"{this.subject} : {this.body}";
        }
    }
}
