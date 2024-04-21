using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public interface Question_and_ThemeRepository
    {
        List<Question_and_Theme> Read();
        void Delete(int id);
        void Update(Question_and_Theme QAT);
        void Create(Question_and_Theme QAT);
    }

    public class Question_and_ThemeRepositoryImpl : Question_and_ThemeRepository
    {
        //Сделать ссылку на свою базу данных
        private const string ConnectionString = "Data Source = C:\\Users\\13\\Desktop\\wadawd\\MyGame\\ClassLibrary\\DBLogic\\ProjectDB.db; FailIfMissing=False";

        public void Create(Question_and_Theme QAT)
        {
            try
            {
                string sql = $"INSERT INTO question_and_theme VALUES(NULL, {QAT.Packid}, {QAT.Questionid}, {QAT.Themeid})";
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
                string sql = $"DELETE FROM question_and_theme WHERE ID = {id}";
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

        public List<Question_and_Theme> Read()
        {
            List<Question_and_Theme> themeList = new List<Question_and_Theme>();
            try
            {
                string sql = "SELECT * FROM question_and_theme";
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
                                int questionid = rdr.GetInt32(index++);
                                int themeid = rdr.GetInt32(index++);
                                int answerid = rdr.GetInt32(index++);
                                themeList.Add(new Question_and_Theme(id, questionid, themeid, answerid));
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

        public void Update(Question_and_Theme QAT)
        {
            try
            {
                string sql = $"UPDATE question_and_theme SET Questionid = {QAT.Questionid}, Themeid = {QAT.Themeid}, Packid = {QAT.Packid} WHERE ID = {QAT.Id}";
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
