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
    public class PenduTest
    {
        [TestMethod]
        public void TestCharTest_MatchingChar_True()
        {
            Pendu pendu = new Pendu();
            pendu.GenererMasque("blabla");
            bool result = pendu.TestChar('a');
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void TestCharTest_WrongChar_False()
        {
            Pendu pendu = new Pendu();
            pendu.GenererMasque("blabla");
            bool result = pendu.TestChar('o');
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestWin_WinningConditions_True()
        {
            Pendu pendu = new Pendu();
            pendu.GenererMasque("blabla");
            pendu.TestChar('b');
            pendu.TestChar('l');
            pendu.TestChar('a');
            Assert.IsTrue(pendu.testWin());
        }

        [TestMethod]
        public void TestWin_LosingConditionsFromIncorrentMatches_False()
        {
            Pendu pendu = new Pendu();
            pendu.GenererMasque("blabla");
            pendu.TestChar('c');
            pendu.TestChar('d');
            pendu.TestChar('e');
            pendu.TestChar('f');
            Assert.IsFalse(pendu.testWin());
        }

        [TestMethod]
        public void TestWin_LosingConditionsFromTooMuchTries_False()
        {
            Pendu pendu = new Pendu();
            pendu.GenererMasque("blabla");
            pendu.TestChar('c');
            pendu.TestChar('d');
            pendu.TestChar('e');
            pendu.TestChar('f');
            pendu.TestChar('c');
            pendu.TestChar('d');
            pendu.TestChar('e');
            pendu.TestChar('f');
            pendu.TestChar('c');
            pendu.TestChar('d');
            pendu.TestChar('b');
            pendu.TestChar('l');
            pendu.TestChar('a');
            Assert.IsFalse(pendu.testWin());
        }

        [TestMethod]
        public void GenererMasqueTest_GenerateProperMask()
        {
            Pendu pendu = new Pendu();
            pendu.GenererMasque("blabla");
            Assert.AreEqual("******", pendu.Masque);
        }
    }
}
