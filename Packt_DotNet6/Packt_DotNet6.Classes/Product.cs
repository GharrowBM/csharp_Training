using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packt_DotNet6.Classes
{
    public class Product
    {
        private int _id;
        private string _name;
        private string _description;
        private decimal _price;

        public static int Stock;
        public static int Incremental;

        public int Id { get { return _id; } }
        public string Name { get { return _name; } }
        public string Description { get { return _description; } }
        public decimal Price { get { return _price; } }

        public Product(string name, string description, decimal price, int stock)
        {
            _id = ++Incremental;
            _name = name;
            _description = description;
            _price = price;

            Stock += stock;
        }

        public void Deconstruct(out string name, out string description, out decimal price)
        {
            name = _name;
            description = _description;
            price = _price;
        }

        public void Deconstruct(out string name, out decimal price)
        {
            price = _price;
            name = _name;
        }

        public override string ToString()
        {
            return $"{_id}. {_name} {_name} {_price:C2} (Stock : {Stock})";
        }
    }
}
