using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace UnitTestProject1
{
    [TestClass]
    public class GameOptionsTest
    {
        [TestMethod]
        public void AreEqual_NumberP_to_NumberP()
        {
            Assert.AreEqual(new GameOptions().Number_of_players, new GameOptions().Number_of_players);
        }
        [TestMethod]
        public void AreNotEqual_Number_to_NumberSet()
        {
            Assert.AreNotEqual(new GameOptions().Number_of_players, new GameOptions().Number_of_players = 1000000);
        }
        [TestMethod]
        public void AreEqual_NumberR_to_NumberR()
        {
            Assert.AreEqual(new GameOptions().Number_of_rounds, new GameOptions().Number_of_rounds);
        }
        [TestMethod]
        public void AreNotEqual_NumberR_to_NumberRSet()
        {
            Assert.AreNotEqual(new GameOptions().Number_of_rounds, new GameOptions().Number_of_rounds = 10000);
        }
        [TestMethod]
        public void AreEqual_NumberQ_to_NumberQ()
        {
            Assert.AreEqual(new GameOptions().Number_of_Questions, new GameOptions().Number_of_Questions);
        }
        [TestMethod]
        public void AreNotEqual_NumberQ_to_NumberQSet()
        {
            Assert.AreNotEqual(new GameOptions().Number_of_Questions, new GameOptions().Number_of_Questions = 10000);
        }
        [TestMethod]
        public void AreEqual_PriceF_to_PriceF()
        {
            Assert.AreEqual(new GameOptions().Price_of_fine, new GameOptions().Price_of_fine);
        }
        [TestMethod]
        public void AreNotEqual_PriceF_to_PriceFSet()
        {
            Assert.AreNotEqual(new GameOptions().Price_of_fine, new GameOptions().Price_of_fine = 100000);
        }
        [TestMethod]
        public void AreEqual_NumberT_to_NumberT()
        {
            Assert.AreEqual(new GameOptions().Number_of_themes, new GameOptions().Number_of_themes);
        }
        [TestMethod]
        public void AreNotEqual_NumberT_to_NumberTset()
        {
            Assert.AreNotEqual(new GameOptions().Number_of_themes, new GameOptions().Number_of_themes = 10000);
        }
        [TestMethod]
        public void AreEqual_Time_to_Time()
        {
            Assert.AreEqual(new GameOptions().Time_for_answer, new GameOptions().Time_for_answer);
        }
        [TestMethod]
        public void AreNotEqual_Time_to_TimeSet()
        {
            Assert.AreNotEqual(new GameOptions().Time_for_answer, new GameOptions().Time_for_answer = 1);
        }
        [TestMethod]
        public void AreEqual_P_to_P()
        {
            Assert.AreEqual(new GameOptions().Progression, new GameOptions().Progression);
        }
        [TestMethod]
        public void AreNotEqual_P_to_PSet()
        {
            Assert.AreNotEqual(new GameOptions().Progression, new GameOptions().Progression = true);
        }

    }
}
