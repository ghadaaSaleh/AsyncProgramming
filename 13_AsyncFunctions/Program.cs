using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace _13_AsyncFunctions
{
    class Program
    {
        static async Task Main(string[] args)
        {
            ShowThreadInfo(Thread.CurrentThread);
            Console.WriteLine(await ReadContentAsync("https://www.youtube.com/c/Metigator"));
            Console.WriteLine("after");
            Console.ReadKey();

        }

        private static void ShowThreadInfo(Thread th)
        {
            Console.WriteLine($"TID: {th.ManagedThreadId}, Pooled: {th.IsThreadPoolThread}, Background: {th.IsBackground}");
        }

        static async Task<string> ReadContentAsync(string url)
        {
            var client = new HttpClient();

            var content = await client.GetStringAsync(url);
            ShowThreadInfo(Thread.CurrentThread);
            return content;
        }
    }
}
