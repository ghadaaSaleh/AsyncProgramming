using System;
using System.Threading;
using System.Threading.Tasks;

namespace _5_ThreadPool
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("============ ThreadPool ============ ");
           ThreadPool.QueueUserWorkItem(new WaitCallback(Print));
            //ThreadPool.QueueUserWorkItem(new WaitCallback(Print));
            //ThreadPool.QueueUserWorkItem(new WaitCallback(Print));
            //ThreadPool.QueueUserWorkItem(new WaitCallback(Print));
            Console.WriteLine(" ============ Task============");
            Task.Run(Print);
            //Task.Run(Print); 
            //Task.Run(Print);

            var employee = new Employee { Rate = 10, TotalHours = 40 };

            ThreadPool.QueueUserWorkItem(new WaitCallback(CalculateSalary), employee);

            Console.WriteLine("Total Salary:"+employee.TotalSalary);
            Thread.Sleep(5000);
            Console.WriteLine("Total Salary:" + employee.TotalSalary);
            Console.ReadKey();
        }

        private static void CalculateSalary(object employee)
        {
            var emp = employee as Employee;
            if (employee is null)
                return;
            emp.TotalSalary = emp.TotalHours * emp.Rate;
            Console.WriteLine(emp.TotalSalary.ToString("C"));
        }

        private static void Print()
        {
            Console.WriteLine($"Thread Id: {Thread.CurrentThread.ManagedThreadId}");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"# {i + 1}");
            }
        }

        private static void Print(object state)
        {
            Console.WriteLine($"Thread Id: {Thread.CurrentThread.ManagedThreadId}");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"# {i + 1}");
            }
        }
    }

    class Employee
    {
        public decimal TotalHours { get; set; }
        public decimal Rate { get; set; }

        public decimal TotalSalary { get; set; }

    }
}
