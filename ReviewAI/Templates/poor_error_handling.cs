using System;
using System.IO;

namespace PoorErrorHandling
{
    public class FileHandler
    {
        public static void ReadFile(string path)
        {
            try
            {
                var content = File.ReadAllText(path);
                Console.WriteLine("File Content: " + content);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }

    public class RetryLogic
    {
        public static void ConnectToServer()
        {
            Console.WriteLine("Attempting to connect to server...");

            Random rand = new Random();
            if (rand.Next(0, 2) == 0)
            {
                throw new IOException("Failed to connect to server.");
            }
            Console.WriteLine("Connection successful.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Reading file...");
            FileHandler.ReadFile("nonexistent_file.txt");

            Console.WriteLine("Connecting to server...");
            try
            {
                RetryLogic.ConnectToServer();
            }
            catch (IOException ex)
            {
                Console.WriteLine("Connection failed: " + ex.Message);
            }
        }
    }
}
