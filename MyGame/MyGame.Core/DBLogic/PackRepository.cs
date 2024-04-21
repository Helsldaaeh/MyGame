using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public interface PackRepository
    {
        List<Pack> Read();
        void Delete(int id);
        void Update(Pack pack);
        void Create(Pack pack);
    }

    public class PackRepositoryImpl : PackRepository
    {
        //Сделать ссылку на свою базу данных
        private const string ConnectionString = "Data Source = C:\\Users\\13\\Desktop\\wadawd\\MyGame\\ClassLibrary\\DBLogic\\ProjectDB.db; FailIfMissing=False";

        public void Create(Pack pack)
        {
            try
            {
                string sql = $"INSERT INTO pack VALUES(NULL, \"{pack.Name}\")";
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
                string sql = $"DELETE FROM pack WHERE ID = {id}";
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

        public List<Pack> Read()
        {
            List<Pack> themeList = new List<Pack>();
            try
            {
                string sql = "SELECT * FROM pack";
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
                                themeList.Add(new Pack(id, name));
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

        public void Update(Pack pack)
        {
            try
            {
                string sql = $"UPDATE pack SET Name = \"{pack.Name}\" WHERE ID = {pack.Id}";
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
