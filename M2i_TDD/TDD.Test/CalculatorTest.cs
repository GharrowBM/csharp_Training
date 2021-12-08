using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD.Classes;

namespace TDD.Test
{
    [TestClass]
    public class CalculatorTest
    {

        Calculator calculator = new Calculator();

        [TestMethod]
        public void AdditionTest()
        {
            calculator.FirstValue = 1;
            calculator.SecondValue = 2;
            Assert.AreEqual(3, calculator.Addition());
        }
    }
}
