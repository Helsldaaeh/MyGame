using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public interface ThemeRepository
    {
        List<Theme> Read();
        List<Theme> ReadByPackId(int id);
        void Delete(int id);
        void Update(Theme theme);
        void Create(Theme theme);
    }

    public class ThemeRepositoryImpl : ThemeRepository
    {
        //Сделать ссылку на свою базу данных
        private const string ConnectionString = "Data Source = C:\\Users\\13\\Desktop\\wadawd\\MyGame\\ClassLibrary\\DBLogic\\ProjectDB.db; FailIfMissing=False";

        public void Create(Theme theme)
        {
            try
            {
                string sql = $"INSERT INTO themes VALUES(NULL, \"{theme.Name}\")";
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
                string sql = $"DELETE FROM themes WHERE ID = {id}";
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

        public List<Theme> Read()
        {
            List<Theme> themeList = new List<Theme>();
            try
            {
                string sql = "SELECT * FROM themes";
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
                                themeList.Add(new Theme(id,name));
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

        public List<Theme> ReadByPackId(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Theme theme)
        {
            try
            {
                string sql = $"UPDATE themes SET Name = \"{theme.Name}\" WHERE ID = {theme.Id}";
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
