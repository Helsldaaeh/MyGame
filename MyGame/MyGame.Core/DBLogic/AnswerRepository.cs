using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public interface AnswerRepository
    {
        List<Answer> Read();
        void Delete(int id);
        void Update(Answer answer);
        void Create(Answer answer);
    }

    public class AnswerRepositoryImpl : AnswerRepository
    {
        //Сделать ссылку на свою базу данных
        private const string ConnectionString = "Data Source = C:\\Users\\1\\Source\\Repos\\Helsldaaeh\\MyGame\\MyGame\\MyGame.Core\\DBLogic\\ProjectDB.db; FailIfMissing=False";

        public void Create(Answer answer)
        {
            try
            {
                string sql = $"INSERT INTO answer VALUES(NULL, \"{answer.Name}\")";
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
                string sql = $"DELETE FROM answer WHERE ID = {id}";
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

        public List<Answer> Read()
        {
            List<Answer> themeList = new List<Answer>();
            try
            {
                string sql = "SELECT * FROM answer";
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
                                themeList.Add(new Answer(id,name));
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

        public void Update(Answer answer)
        {
            try
            {
                string sql = $"UPDATE answer SET Answer = \"{answer.Name}\" WHERE ID = {answer.Id}";
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
