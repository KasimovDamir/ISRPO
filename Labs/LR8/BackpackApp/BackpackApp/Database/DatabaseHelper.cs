using System.Collections.Generic;
using System.Data.SqlClient;
using BackpackApp.Models;
using BackpackApp.Debugging;

namespace BackpackApp.Database
{
    public static class DatabaseHelper
    {
        private static string masterConnection =
            @"Server=LuM1e\SQLLUM1E;Database=master;Trusted_Connection=True;";

        private static string dbConnection =
            @"Server=LuM1e\SQLLUM1E;Database=backpack;Trusted_Connection=True;";

        public static void InitializeDatabase()
        {
            DebugLogger.Log("Проверка подключения к базе данных...");

            using (SqlConnection connection = new SqlConnection(masterConnection))
            {
                connection.Open();
                DebugLogger.Log("Подключение к базе данных успешно установлено");

                string checkDb =
                    "IF DB_ID('backpack') IS NULL CREATE DATABASE backpack";

                using (SqlCommand cmd = new SqlCommand(checkDb, connection))
                {
                    cmd.ExecuteNonQuery();
                }
            }

            using (SqlConnection connection = new SqlConnection(dbConnection))
            {
                connection.Open();

                string createTable =
                @"IF OBJECT_ID('objects') IS NULL
                CREATE TABLE objects (
                    Id INT PRIMARY KEY IDENTITY(1,1),
                    Name NVARCHAR(100) NOT NULL,
                    Weight INT NOT NULL,
                    Cost INT NOT NULL
                )";

                using (SqlCommand cmd = new SqlCommand(createTable, connection))
                {
                    cmd.ExecuteNonQuery();
                }

                string insertData =
                @"IF NOT EXISTS (SELECT 1 FROM objects)
                INSERT INTO objects (Name, Weight, Cost) VALUES
                ('Книга',1,600),
                ('Бинокль',2,5000),
                ('Аптечка',4,1500),
                ('Ноутбук',2,40000),
                ('Котелок',1,500)";

                using (SqlCommand cmd = new SqlCommand(insertData, connection))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<Item> GetItems()
        {
            List<Item> items = new List<Item>();

            using (SqlConnection connection = new SqlConnection(dbConnection))
            {
                connection.Open();

                string query = "SELECT Id, Name, Weight, Cost FROM objects";

                DebugLogger.LogSqlQuery(query);

                using (SqlCommand cmd = new SqlCommand(query, connection))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        items.Add(new Item
                        {
                            Id = (int)reader["Id"],
                            Name = reader["Name"].ToString(),
                            Weight = (int)reader["Weight"],
                            Cost = (int)reader["Cost"]
                        });
                    }
                }
            }

            DebugLogger.Log($"В таблице objects найдено {items.Count} записей");
            DebugLogger.Log("Загрузка данных из базы данных");
            DebugLogger.Log($"Загружено {items.Count} предметов");

            return items;
        }
    }
}