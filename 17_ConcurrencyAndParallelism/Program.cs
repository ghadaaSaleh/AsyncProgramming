﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace _17_ConcurrencyAndParallelism
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var things = new List<DailyDuty>
            {
                new DailyDuty("Cleaning House"),
                new DailyDuty("Washing Dishes"),
                new DailyDuty("Doing Laundry"),
                new DailyDuty("Preparing Meals"),
                new DailyDuty("Checking Emails"),
                new DailyDuty("Cleaning House")
            };

           
            await ProcessThingsInParallel(things);

           // await ProcessThingsInConcurrent(things);

            Console.ReadKey();
        }

        static Task ProcessThingsInParallel(IEnumerable<DailyDuty> things)
        {
            Parallel.ForEach(things, thing => thing.Process());
            return Task.CompletedTask;
        }

        static Task ProcessThingsInConcurrent(IEnumerable<DailyDuty> things)
        {
            foreach (var thing in things)
            {
                thing.Process();
            }
            return Task.CompletedTask;
        }
    }

    class DailyDuty
    {
        public string title { get; private set; }

        public bool Processed { get; private set; }

        public DailyDuty(string title)
        {
            this.title = title;
        }

        public void Process()
        {
            Console.WriteLine($"TID: {Thread.CurrentThread.ManagedThreadId}," +
                $"ProcessorId: {Thread.GetCurrentProcessorId()}");
            Task.Delay(100).Wait();
            Console.WriteLine($"TID: {Thread.CurrentThread.ManagedThreadId}," +
              $"ProcessorId: {Thread.GetCurrentProcessorId()}");
            Console.WriteLine("test");
            this.Processed = true;
        }
    }
}
