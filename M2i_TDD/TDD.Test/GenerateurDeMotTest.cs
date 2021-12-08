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
    public class GenerateurDeMotTest
    {
        [TestMethod]
        public void GenererTest_ShouldSendWord()
        {
            GenerateurDeMot generator = new GenerateurDeMot();
            string[] possibleWords = { "google", "apple", "microsoft", "amazon", "facebook" };
            string result = generator.Generer();
            Assert.IsTrue(possibleWords.Contains(result));
        } 
    }
}
