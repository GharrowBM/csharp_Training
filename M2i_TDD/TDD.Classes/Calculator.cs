using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD.Classes
{
    public class Calculator
    {
        private decimal firstValue;
        private decimal secondValue;

        public decimal FirstValue { get { return firstValue; } set { firstValue = value; } }
        public decimal SecondValue { get { return secondValue; } set { secondValue = value; } }

        public decimal Addition()
        {
            return secondValue + firstValue;
        }

        public decimal Substraction()
        {
            return secondValue - firstValue;
        }

        public decimal Division()
        {
            return secondValue / firstValue;
        }

        public decimal Multiplication()
        {
            return secondValue * firstValue;
        }
    }
}
