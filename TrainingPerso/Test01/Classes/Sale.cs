using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test01.Classes
{
    internal class Sale
    {
        private string _productName;
        private decimal _price;

        public string ProductName { get => _productName; }
        public decimal Price { get => _price; }

        public Sale(string productName, decimal price)
        {
            _productName = productName;
            _price = price;
        }


        public event Action<decimal> Promotion;

        public void Reduction(decimal amount)
        {
            _price -= amount;

            Promotion?.Invoke(_price);
        }
    }
}
