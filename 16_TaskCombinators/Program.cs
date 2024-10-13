using System;
using System.Threading.Tasks;

namespace _16_TaskCombinators
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var has1000SubscriberTask = Task.Run(() => Has1000Subscriber());
            var has4000ViewHoursTask = Task.Run(() => Has4000ViewHours());

            var anyResult = await Task.WhenAny(has1000SubscriberTask, has4000ViewHoursTask);
            Console.WriteLine(anyResult.Result);

            var allResult = await Task.WhenAll(has1000SubscriberTask, has4000ViewHoursTask);
            foreach (var t in allResult)
            {
                Console.WriteLine(t);

            }
            Console.ReadKey();
        }

        static Task<string> Has1000Subscriber()
        {
            Task.Delay(4000).Wait();
            return Task.FromResult("congratulation !! you have 1000 subscribers");
        }

        static Task<string> Has4000ViewHours()
        {
            Task.Delay(3000).Wait();
            return Task.FromResult("congratulation !! you have 4000 view hours");
        }
    }
}
