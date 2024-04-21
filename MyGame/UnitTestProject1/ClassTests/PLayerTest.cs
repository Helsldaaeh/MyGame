using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class PLayerTest
    {
        [TestMethod]
        public void AreEqual_Nick_to_Nick()
        {
            Assert.AreEqual(new Player().NickName, new Player().NickName);
        }
        [TestMethod]
        public void AreNotEqual_Nick_to_NickSet()
        {
            Assert.AreNotEqual(new Player("NONE", 1000, 1).NickName, new Player("NONE", 1000, 1).NickName = "NONEE");
        }
        [TestMethod]
        public void AreEqual_Points_to_Points()
        {
            Assert.AreEqual(new Player("NONE",1000,1).Count_of_points, new Player("NONE", 1000, 1).Count_of_points);
        }
        [TestMethod]
        public void AreNotEqual_Points_to_PointsSet()
        {
            Assert.AreNotEqual(new Player("NONE", 1000, 1).Count_of_points, new Player("NONE", 1000, 1).Count_of_points = 10000);
        }
        [TestMethod]
        public void AreNotEqual_Number_to_Number()
        {
            Assert.AreNotEqual(new Player().Number_of_player, new Player().Number_of_player);
        }
        [TestMethod]
        public void AreEqual_Number_to_NumberSet()
        {
            Assert.AreNotEqual(new Player().Number_of_player, new Player().Number_of_player = 1);

        }
    }
}
