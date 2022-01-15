using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaApp.Models
{
    public class Pizza
    {     
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public List<string> Ingredients { get; set; }
    }
}
