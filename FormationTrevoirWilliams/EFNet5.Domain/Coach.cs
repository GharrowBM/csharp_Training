using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFNet5.Domain
{
    public class Coach
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? TeamId { get; set; }
        public virtual Team Team { get; set; }

    }
}
