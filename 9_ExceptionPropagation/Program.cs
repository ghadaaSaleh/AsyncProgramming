using System;
using System.Threading;
using System.Threading.Tasks;

namespace _9_ExceptionPropagation
{
    class Program
    {
        static void Main(string[] args)
        {
            // -- 1 --
            //try
            //{
            //    var th = new Thread(ThrowExceptionWithTryCatchBlock);
            //    th.Start();
            //    th.Join();
            //}
            //catch
            //{
            //    Console.WriteLine("Exception is thrown!!");
            //}

            try
            {
                Task.Run(ThrowException).Wait();
            }
            catch
            {
                Console.WriteLine("Exception is thrown!!");

            }
            Console.ReadKey();
        }

        static void ThrowException()
        {
            throw new NullReferenceException();
        }

        static void ThrowExceptionWithTryCatchBlock()
        {
            try
            {
                throw new NullReferenceException();

            }
            catch
            {
                Console.WriteLine("Exception is thrown!!");

                 throw;
            }
        }
    }
}
