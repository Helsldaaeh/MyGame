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
    public class ThemeT
    {
        private ThemeRepository rep = new ThemeRepositoryImpl();
        [TestMethod]
        public void CreateTest()
        {
            Theme next = new Theme(0, "Программирование");
            List<Theme> themes = this.rep.Read();
            this.rep.Create(next);
            themes = this.rep.Read();
            next = themes.Last();
            Assert.AreEqual("Программирование", next.Name);
            this.rep.Delete(next.Id);
        }
        [TestMethod]
        public void UpdateTest()
        {
            Theme next = new Theme(0, "Программирование");
            this.rep.Create(next);
            List<Theme> themes = this.rep.Read();
            next = themes.Last();
            themes = this.rep.Read();
            this.rep.Update(new Theme(themes.Last().Id, next.Name + "не"));
            themes = this.rep.Read();
            Assert.AreNotEqual("Программирование", themes.Last().Name);
            this.rep.Delete(next.Id);
        }
    }
}
