using System;
using System.Threading;

namespace ThreadingAndRaceConditions
{
    public class SharedCounter
    {
        private static int Counter = 0;

        public static void IncrementCounter()
        {
            for (int i = 0; i < 1000; i++)
            {
                Counter++;
            }
        }

        private static object LockObject = new object();

        public static void SafeIncrementCounter()
        {
            for (int i = 0; i < 1000; i++)
            {
                lock (LockObject)
                {
                    Counter++;
                }
            }
        }

        public static void PrintCounter()
        {
            Console.WriteLine($"Counter Value: {Counter}");
        }
    }

    public class ExampleDeadlock
    {
        private static object Lock1 = new object();
        private static object Lock2 = new object();

        public static void CreateDeadlock()
        {
            Thread t1 = new Thread(() =>
            {
                lock (Lock1)
                {
                    Thread.Sleep(100);
                    lock (Lock2)
                    {
                        Console.WriteLine("Thread 1 acquired both locks.");
                    }
                }
            });

            Thread t2 = new Thread(() =>
            {
                lock (Lock2)
                {
                    Thread.Sleep(100);
                    lock (Lock1)
                    {
                        Console.WriteLine("Thread 2 acquired both locks.");
                    }
                }
            });

            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Demonstrating race condition...");
            Thread t1 = new Thread(SharedCounter.IncrementCounter);
            Thread t2 = new Thread(SharedCounter.IncrementCounter);
            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();
            SharedCounter.PrintCounter();

            Console.WriteLine("Demonstrating deadlock...");
            ExampleDeadlock.CreateDeadlock();
        }
    }
}
