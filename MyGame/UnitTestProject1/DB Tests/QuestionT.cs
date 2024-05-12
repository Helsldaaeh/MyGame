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
    public class QuestionT
    {
        private QuestionRepository rep = new QuestionRepositoryImpl();
        [TestMethod]
        public void CreateTest()
        {
            Question next = new Question(0, "Программирование", "Программирование - это", 0);
            List<Question> questions = this.rep.Read();
            this.rep.Create(next);
            questions = this.rep.Read();
            next = questions.Last();
            Assert.AreEqual("Программирование", next.Name);
            Assert.AreEqual("Программирование - это", next.tQuestion);
            Assert.AreEqual(0, next.Answerid);
            this.rep.Delete(next.Id);
        }
        [TestMethod]
        public void UpdateTest()
        {
            Question next = new Question(0, "Программирование", "Программирование - это", 0);
            this.rep.Create(next);
            List<Question> questions = this.rep.Read();
            next = questions.Last();
            questions = this.rep.Read();
            this.rep.Update(new Question(questions.Last().Id, next.Name + " ", next.tQuestion + " ", next.Answerid + 1));
            questions = this.rep.Read();
            Assert.AreNotEqual("Программирование", questions.Last().Name);
            Assert.AreNotEqual("Программирование - это", questions.Last().tQuestion);
            Assert.AreNotEqual(0, questions.Last().Answerid);
            this.rep.Delete(next.Id);
        }
        [TestMethod]
        public void ThemeIdReadTest()
        {
            List<Question> questions = this.rep.ReadByThemeId(1);
            Assert.AreEqual("Имя человека, который крестил Русь", questions.Last().Name);
        }
    }
}