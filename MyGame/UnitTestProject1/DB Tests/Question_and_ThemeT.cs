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
    public class Question_and_ThemeT
    {
        private Question_and_ThemeRepository rep = new Question_and_ThemeRepositoryImpl();
        [TestMethod]
        public void CreateTest()
        {
            Question_and_Theme next = new Question_and_Theme(0, 0, 0, 0);
            List<Question_and_Theme> QATs = this.rep.Read();
            this.rep.Create(next);
            QATs = this.rep.Read();
            next = QATs.Last();
            Assert.AreEqual(QATs.Last().Questionid, next.Packid);
            Assert.AreEqual(QATs.Last().Packid, next.Packid);
            Assert.AreEqual(QATs.Last().Themeid, next.Packid);
            this.rep.Delete(next.Id);
        }
        [TestMethod]
        public void UpdateTest()
        {
            Question_and_Theme next = new Question_and_Theme(0, 1, 1, 1);
            List<Question_and_Theme> QATs = this.rep.Read();
            this.rep.Create(next);
            QATs = this.rep.Read();
            this.rep.Update(new Question_and_Theme(next.Id, next.Themeid + 1, next.Packid + 1, next.Questionid + 1));
            QATs = this.rep.Read();
            next = QATs.Last();
            Assert.AreNotEqual(QATs.Last().Questionid - 1, next.Questionid);
            Assert.AreNotEqual(QATs.Last().Packid - 1, next.Packid);
            Assert.AreNotEqual(QATs.Last().Themeid -1, next.Themeid);
            this.rep.Delete(next.Id);
        }
    }
}
