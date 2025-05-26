using System;
using Npgsql;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDocuments
{
    class DataBaseHelper
    {
        private static readonly string ConnectionString =
            "Host=192.168.1.58;Port=55555;Database=DemoDocuments;Username=postgres;Password=1161";

        public static (bool Success, string FullName, string AccessRole) CheckLogin(string login, string password)
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT FullName, AccessRole FROM Users WHERE Login = @login AND Password = @password";

                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@login", login);
                        cmd.Parameters.AddWithValue("@password", password);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string fullName = reader.GetString(0);
                                string accessRole = reader.GetString(1);
                                return (true, fullName, accessRole);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }
            return (false, null, null);
        }

        public static bool ResetPassword(string login, string newPassword)
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE Users SET Password = @newPassword WHERE Login = @login";

                    using (var cmd = new NpgsqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@newPassword", newPassword);
                        cmd.Parameters.AddWithValue("@login", login);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
                catch
                {
                    return false;
                }
            }
        }

        public static DataTable GetDataTable(string query)
        {
            var dataTable = new DataTable();
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();
                using (var adapter = new NpgsqlDataAdapter(query, connection))
                {
                    adapter.Fill(dataTable);
                }
            }
            return dataTable;
        }
    }
}
