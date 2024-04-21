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
    public class AnswerT
    {
        private AnswerRepository rep = new AnswerRepositoryImpl();
        [TestMethod]
        public void CreateTest()
        {
            Answer next = new Answer(0, "Власть");
            this.rep.Create(next);
            List<Answer> answers = this.rep.Read();
            next = answers.Last();
            Assert.AreEqual("Власть", next.Name);
            this.rep.Delete(next.Id);
        }
        [TestMethod]
        public void UpdateTest()
        {
            Answer next = new Answer(0, "Власть");
            List<Answer> answers = this.rep.Read();
            this.rep.Create(next);
            answers = this.rep.Read();
            next = answers.Last();
            this.rep.Update(new Answer(next.Id, "НЕ" +  next.Name));
            answers = this.rep.Read();
            Assert.AreNotEqual("Власть", answers.Last().Name);
            this.rep.Delete(next.Id);
        }
    }
}
