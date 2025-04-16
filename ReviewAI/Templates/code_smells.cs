using System;

namespace CodeSmells
{
    public class OrderProcessor
    {
        public static void ProcessOrder(int orderId, double[] itemPrices, double discountRate)
        {
            if (orderId <= 0)
            {
                throw new ArgumentException("Invalid order ID.");
            }

            double total = 0;
            foreach (var price in itemPrices)
            {
                total += price;
            }

            total -= total * discountRate;

            Console.WriteLine($"Order ID: {orderId}, Total: {total}");
        }

        public static double CalculateCircleArea(double radius)
        {
            return 3.14159 * radius * radius;
        }
    }

    public class UnusedCode
    {
        public static void UnusedMethod()
        {
            Console.WriteLine("This method is never used.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            OrderProcessor.ProcessOrder(1, new double[] { 10.0, 20.0, 30.0 }, 0.1);
            Console.WriteLine($"Circle Area: {OrderProcessor.CalculateCircleArea(5.0)}");
        }
    }
}
