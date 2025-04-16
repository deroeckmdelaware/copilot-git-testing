using System;

namespace ErrorHandlingAndValidation
{
    public class InputValidator
    {
        public static void ValidateUsername(string username)
        {
            if (username.Length > 20)
            {
                throw new ArgumentException("Username too long.");
            }
        }
    }

    public class ErrorHandling
    {
        public static void ProcessData()
        {
            try
            {
                int result = 100 / int.Parse("0");
            }
            catch
            {
                Console.WriteLine("An error occurred.");
            }
        }

        public static void ReadFile(string path)
        {
            try
            {
                Console.WriteLine(System.IO.File.ReadAllText(path));
            }
            catch (Exception) { }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            InputValidator.ValidateUsername("admin' OR '1'='1");

            Console.WriteLine("Processing data...");
            ErrorHandling.ProcessData();

            Console.WriteLine("Reading file...");
            ErrorHandling.ReadFile("invalid_path.txt");
        }
    }
}
