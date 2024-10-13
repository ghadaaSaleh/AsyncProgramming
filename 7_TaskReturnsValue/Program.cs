using System;
using System.Threading.Tasks;

namespace _7_TaskReturnsValue
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<DateTime> task = Task.Run(GetCurrentDatetime);
            Console.WriteLine(task.Result);
            Console.WriteLine("Result=====================");  

            Console.WriteLine(task.GetAwaiter().GetResult());
            Console.WriteLine("GetAwaiter().GetResult()=====================");
            Console.ReadKey();
        }
        static DateTime GetCurrentDatetime() => DateTime.Now;
    }
}
