using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD.Classes;
using TDD.Classes.Interfaces;

namespace TDD.Test
{
    [TestClass]
    public class FrameTest
    {

        private Frame f;

        [TestMethod]
        public void RollTest_CanMakeRoll_True()
        {
            InitFrame();
            Assert.IsTrue(f.Roll());
        }

        [TestMethod]
        public void RollTest_CanMakeRoll_False_TooMuchRolls()
        {
            InitFrame();

            f.Roll();
            f.Roll();
            f.Roll();
            Assert.IsFalse(f.Roll());
        }

        [TestMethod]
        public void RollTest_ShouldAddRoll()
        {
            InitFrame();
            f.Roll();
            Assert.AreEqual(1, f.Rolls.Count);
        }

        [TestMethod]
        public void RollTest_CannothaveMorethan10PinsDown()
        {
            InitFrame();

            f.Roll();
            f.Roll();
            f.Roll();
            Assert.IsTrue(f.Score <= 10);
        }

        [TestMethod]
        public void RollTest_Roll_ShouldHavePinsBetween1AndRemaining()
        {
            InitFrame();
            f.Roll();
            f.Roll();
            f.Roll();

            if (f.Rolls.Count == 3) Assert.IsTrue(f.Rolls[2].Pins >= 0 && f.Rolls[2].Pins < 11 - (f.Rolls[0].Pins + f.Rolls[1].Pins));
            else if (f.Rolls.Count == 2) Assert.IsTrue(f.Rolls[1].Pins >= 0 && f.Rolls[1].Pins < 11 - f.Rolls[0].Pins);
            else Assert.IsTrue(f.Rolls[0].Pins >= 0 && f.Rolls[0].Pins < 11);
        }

        private void InitFrame()
        {
            f = new Frame();
        }
    }
}
