using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _10_TaskContinuation
{
    class Program
    {
        static void Main(string[] args)
        {
            //  Console.WriteLine(CountPrimeNumberInARange(2, 2_000_000));

            Task<int> task = Task.Run(() => PrimeNumbersInRange(2, 3_000_000));
            Console.WriteLine("=======Before block task===========");
            Console.WriteLine(task.Result);
            Console.WriteLine("=======After block task===========");

            Task<int> task2 = Task.Run(() => PrimeNumbersInRange(2, 3_000_000));
          
            var awaiter = task2.GetAwaiter();
            awaiter.OnCompleted(() =>
            {
                Console.WriteLine(awaiter.GetResult()); 
            });
            Console.WriteLine("=======After OnCompleted===========");

            Task<int> task3 = Task.Run(() => PrimeNumbersInRange(2, 3_000_000));
            task3.ContinueWith((x) => Console.WriteLine(x.Result));
            Console.WriteLine("=======After Line Result===========");
            Console.ReadKey();
        }
        static bool IsPrime(int n)
        {
            if (n <= 1) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }
        static int PrimeNumbersInRange(int start, int end)
        {
            List<int> primes = new List<int>();
            for (int number = start; number <= end; number++)
            {
                if (IsPrime(number))
                {
                    primes.Add(number);
                }
            }
            return primes.Count;
        }
      
    }
}
