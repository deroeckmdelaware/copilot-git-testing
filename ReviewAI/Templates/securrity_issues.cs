using System;
using System.Data.SqlClient;
using System.IO;

namespace SecurityIssues
{
    public class DatabaseConnector
    {
        private const string ConnectionString =
            "Server=myServer;Database=myDB;User=myUser;Password=myPassword;";

        public static void GetUser(string username)
        {
#pragma warning disable CS0618
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = $"SELECT * FROM Users WHERE Username = '{username}'";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"User: {reader["Username"]}");
                    }
                }
            }
#pragma warning restore CS0618
        }

        public static void SaveSensitiveData(string data)
        {
            File.WriteAllText("sensitive.txt", data);
        }
    }

    public class Authentication
    {
        public static string HashPassword(string password)
        {
            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                return Convert.ToBase64String(hashBytes);
            }
        }

        public static bool Authenticate(string username, string password)
        {
            return username == "admin" && password == "12345";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fetching user data...");
            DatabaseConnector.GetUser("admin' OR '1'='1");

            Console.WriteLine("Hashing password...");
            Console.WriteLine(Authentication.HashPassword("password123"));
        }
    }
}
