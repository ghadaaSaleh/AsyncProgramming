using System;
using System.Threading;
using System.Threading.Tasks;

namespace _8_TaskNotFromPool
{
    class Program
    {
        static void Main(string[] args)
        {
            var task = Task.Factory.StartNew(() => RunLongTask(),
              TaskCreationOptions.LongRunning);
            Console.ReadKey();
        }
        static void RunLongTask()
        {
            Thread.Sleep(3000);
            ShowThreadInfo(Thread.CurrentThread);
            Console.WriteLine("Completed");
        }
        private static void ShowThreadInfo(Thread th)
        {
            Console.WriteLine($"TID: {th.ManagedThreadId}, Pooled: {th.IsThreadPoolThread}, Background: {th.IsBackground}");
        }
    }
}
