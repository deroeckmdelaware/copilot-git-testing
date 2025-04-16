using System;
using System.Collections.Generic;
using System.Threading;

namespace PerformanceIssues
{
    public class InefficientAlgorithms
    {
        public static List<int> FindCommonElements(
            List<int> list1,
            List<int> list2,
            List<int> list3
        )
        {
            List<int> common = new List<int>();
            foreach (var a in list1)
            {
                foreach (var b in list2)
                {
                    foreach (var c in list3)
                    {
                        if (a == b && b == c)
                        {
                            common.Add(a);
                        }
                    }
                }
            }
            return common;
        }

        public static List<int> DuplicateList(List<int> data)
        {
            return new List<int>(data);
        }
    }

    public class ThreadingIssues
    {
        private static int Counter = 0;

        public static void IncrementCounter()
        {
            for (int i = 0; i < 1000; i++)
            {
                Counter++;
            }
        }

        public static void SimulateWork()
        {
            Console.WriteLine("Simulating work...");
            Thread.Sleep(5000);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Running inefficient algorithm...");
            var list1 = new List<int> { 1, 2, 3, 4 };
            var list2 = new List<int> { 3, 4, 5, 6 };
            var list3 = new List<int> { 5, 6, 7, 8 };
            var result = InefficientAlgorithms.FindCommonElements(list1, list2, list3);
            Console.WriteLine($"Common elements: {string.Join(", ", result)}");

            Console.WriteLine("Running threading example...");
            Thread t1 = new Thread(ThreadingIssues.IncrementCounter);
            Thread t2 = new Thread(ThreadingIssues.IncrementCounter);
            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();
            Console.WriteLine($"Final Counter Value: {ThreadingIssues.IncrementCounter}");
        }
    }
}
