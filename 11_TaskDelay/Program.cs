using System;
using System.Threading;
using System.Threading.Tasks;

namespace _11_TaskDelay
{
    class Program
    {
        static void Main(string[] args)
        {
            SleepUsingThread(5000);
            DelayUsingTask(5000);
       
            Console.ReadKey();
        }
        static void DelayUsingTask(int ms)
        {
            Task.Delay(ms).GetAwaiter().OnCompleted(() => {
                Console.WriteLine($"Completed after Task.Delay({ms})");

            });
            Console.WriteLine($"Line after Completed after Thread.Sleep({ms})");
        }

        static void SleepUsingThread(int ms)
        {
            Thread.Sleep(ms);
            Console.WriteLine($"Completed after Thread.Sleep({ms})");

        }
    }
}
