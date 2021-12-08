using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWPF.Model;

namespace TestWPF.ViewModel
{
    public class MainVM
    {
        public Product testProd { get; set; }

        public MainVM ()
        {
            testProd = new Product () { Title= "Test Product", Price=1.50m};
        }
    }
}
