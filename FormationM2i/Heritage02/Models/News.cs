using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heritage02.Models
{
    internal class News
    {
        private string id;
        private string subject;
        private string description; 

        public string Id { get { return id; } }
        public string Subject { get { return subject; } }

        public News(string subject, string description)
        {
            this.id = Guid.NewGuid().ToString();
            this.subject = subject;
            this.description = description;
        }

        public override string ToString()
        {
            return $"{id} - {subject}: {description}";
        }
    }
}
