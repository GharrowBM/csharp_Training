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
    public class PileTest
    {


        [TestMethod]
        public void EmpilerTest_NewElement_True()
        {
            Pile<string> p = new Pile<string>(5);
            Assert.IsTrue(p.Empiler("test"));
        }

        [TestMethod]
        public void EmpilerTest_TooMuchElements_False()
        {
            Pile<string> p = new Pile<string>(5);
            p.Empiler("test");
            p.Empiler("test");
            p.Empiler("test");
            p.Empiler("test");
            p.Empiler("test");
            Assert.IsFalse(p.Empiler("test"));
        }

        [TestMethod]
        public void DepilerTest_PileHasElements_True()
        {
            Pile<string> p = new Pile<string>(5);
            p.Empiler("test");
            Assert.IsTrue(p.Depiler());
        }

        [TestMethod]
        public void DepilerTest_PileHasNoElement_False()
        {
            Pile<string> p = new Pile<string>(5);
            Assert.IsFalse(p.Depiler());
        }

        [TestMethod]
        public void GetElementTest_ElementExists_Element()
        {
            Pile<string> p = new Pile<string>(5);
            string element = "test";
            p.Empiler(element);
            string elementGot = p.GetElement(0);
            Assert.AreEqual(element, elementGot);
        }

        [TestMethod]
        public void GetElementTest_ElementDoesntExist_DefaultValue()
        {
            Pile<string> p = new Pile<string>(5);
            string elementGot = p.GetElement(0);
            Assert.AreEqual(null, elementGot);
        }

        [TestMethod]
        public void SearchTest_ElementExists_Element()
        {
            Pile<string> p = new Pile<string>(5);
            string element = "test";
            p.Empiler(element);
            string elementGot = p.Search(e => e.Equals("test"));
            Assert.AreEqual(element, elementGot);
        }

        [TestMethod]
        public void SearchTest_ElementDoesntExist_DefaultValue()
        {
            Pile<string> p = new Pile<string>(5);
            string element = "test";
            string elementGot = p.Search(e =>
            {
                if (e != null) return e.Equals("test");
                return false;
            });
            Assert.AreEqual(default(string), elementGot);
        }

        [TestMethod]
        public void SearchAllTest_ElementsExist_Elements()
        {
            Pile<string> p = new Pile<string>(5);
            string elementA = "test";
            string elementB = "test";
            p.Empiler(elementA);
            p.Empiler(elementB);
            List<string> elementsGot = new List<string>();
            elementsGot.AddRange(p.SearchAll(e =>
            {
                if (e != null) return e.Equals("test");
                return false;
            }));
            Assert.AreEqual(2, elementsGot.Count);
        }

        [TestMethod]
        public void SearchAllTest_ElementsDontExist_EmptyList()
        {
            Pile<string> p = new Pile<string>(5);
            List<string> elementsGot = new List<string>();
            elementsGot.AddRange(p.SearchAll(e =>
            {
                if (e != null) return e.Equals("test");
                return false;
            }));
            Assert.AreEqual(0, elementsGot.Count);
        }
    }
}
