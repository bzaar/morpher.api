using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Morpher.Russian;

namespace Morpher.API.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDative ()
        {
            Assert.AreEqual ("D", Case.Dative.Get (new EnglishInitials ()));
        }

        [TestMethod]
        public void TestOrderOfRussianCases ()
        {
            Assert.AreEqual ("NGDAIPL", 
                String.Join("", Case.All.Select (c => c.Get (new EnglishInitials ()))));
        }
    }
}
