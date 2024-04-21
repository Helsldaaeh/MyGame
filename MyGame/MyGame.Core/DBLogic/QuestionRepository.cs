using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public interface QuestionRepository
    {
        List<Question> Read();
        void Delete(int id);
        void Update(Question question);
        void Create(Question question);
    }

    public class QuestionRepositoryImpl : QuestionRepository
    {
        //Сделать ссылку на свою базу данных
        private const string ConnectionString = "Data Source = C:\\Users\\13\\Desktop\\wadawd\\MyGame\\ClassLibrary\\DBLogic\\ProjectDB.db; FailIfMissing=False";

        public void Create(Question question)
        {
            try
            {
                string sql = $"INSERT INTO question VALUES(NULL, \"{question.Name}\", \"{question.tQuestion}\", {question.Answerid})";
                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SQLiteException ex)
            {
            }
        }
        public void Delete(int id)
        {
            try
            {
                string sql = $"DELETE FROM question WHERE ID = {id}";
                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SQLiteException ex)
            {
            }
        }

        public List<Question> Read()
        {
            List<Question> themeList = new List<Question>();
            try
            {
                string sql = "SELECT * FROM question";
                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, connection))
                    {
                        using (SQLiteDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                int index = 0;
                                int id = rdr.GetInt32(index++);
                                string name = rdr.GetString(index++);
                                string question = rdr.GetString(index++);
                                int answerid = rdr.GetInt32(index++);
                                themeList.Add(new Question(id, name, question, answerid));
                            }
                        }
                    }
                }
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine($"Ошибка доступа к базе данных. Исключение: {ex.Message}");
            }
            return themeList;
        }

        public void Update(Question question)
        {
            try
            {
                string sql = $"UPDATE question SET Name = \"{question.Name}\", Question = \"{question.tQuestion}\", Answerid = {question.Answerid} WHERE ID = {question.Id}";
                using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SQLiteException ex)
            {
            }
        }
    }
}
