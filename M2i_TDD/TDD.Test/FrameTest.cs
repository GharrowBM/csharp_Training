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
        IIntGenerator g;

        [TestMethod]
        public void RollTest_ShouldMakeRoll()
        {
            InitFrame();
            f.Roll(Mock.Get(g).Setup(g => g.Generate()).Returns(1));
            Assert.AreEqual(1, f.Rolls.Count);
        }

        [TestMethod]
        public void RollTest_CannotMakeMoreThan3RollsOrHaveMoreThan10PinsDown()
        {
            InitFrame();
            f.Roll();
            f.Roll();
            f.Roll();
            f.Roll();
            Assert.IsTrue(f.Score == 10 || f.Rolls.Count <= 3);
        }

        [TestMethod]
        public void RollTest_FirstRoll_ShouldHavePinsBetween1And10()
        {
            InitFrame();
            f.Roll();
            Assert.IsTrue(f.Rolls[0].Pins > 0 && f.Rolls[0].Pins < 11);
        }

        [TestMethod]
        public void RollTest_NextRolls_ShouldHavePinsBetween1AndRemaining_ScenarioWithTwoRolls()
        {
            InitFrame();
            f.Roll();
            f.Roll();
            Assert.IsTrue(f.Rolls[1].Pins > 0 && f.Rolls[1].Pins < 11 - f.Rolls[0].Pins);
        }

        [TestMethod]
        public void RollTest_NextRolls_ShouldHavePinsBetween1AndRemaining_ScenarioWithThreeRolls()
        {
            InitFrame();
            f.Roll();
            f.Roll();
            f.Roll();
            Assert.IsTrue(f.Rolls[2].Pins > 0 && f.Rolls[2].Pins < 11 - (f.Rolls[0].Pins + f.Rolls[1].Pins));
        }

        private void InitFrame()
        {
            f = new Frame();
            g = Mock.Of<IIntGenerator>();
        }
    }
}
