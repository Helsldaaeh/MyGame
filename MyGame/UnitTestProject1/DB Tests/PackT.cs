using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{

    [TestClass]
    public class PackT
    {
        private PackRepository rep = new PackRepositoryImpl();
        [TestMethod]
        public void CreateTest()
        {
            Pack next = new Pack(0, "IT");
            List<Pack> packs = this.rep.Read();
            this.rep.Create(next);
            packs = this.rep.Read();
            next = packs.Last();
            Assert.AreEqual("IT", next.Name);
            this.rep.Delete(next.Id);
        }
        [TestMethod]
        public void UpdateTest()
        {
            Pack next = new Pack(0, "ITT");
            List<Pack> packs = this.rep.Read();
            this.rep.Create(next);
            packs = this.rep.Read();
            this.rep.Update(new Pack(packs.Last().Id, next.Name + " "));
            packs = this.rep.Read();
            Assert.AreNotEqual("ITT", packs.Last().Name);
            this.rep.Delete(packs.Last().Id);
        }
    }
}
