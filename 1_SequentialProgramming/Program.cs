using System;
using System.Threading;

namespace _1_SequentialProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            var wallet1 = new Wallet("Issam", 80);

            wallet1.RunRandomTransactions();
            Console.WriteLine("----------------");
            Console.WriteLine($"{wallet1}\n");

            var wallet2 = new Wallet("Issam", 80);
            wallet2.RunRandomTransactions();
            Console.WriteLine("----------------");
            Console.WriteLine($"{wallet2}\n");

            Console.ReadKey();
        }
    }
}
// See https://aka.ms/new-console-template for more information



class Wallet
{
    public Wallet(string name, int bitcoins)
    {
        Name = name;
        Bitcoins = bitcoins;
    }

    public string Name { get; private set; }
    public int Bitcoins { get; private set; }


    public void Debit(int amount)
    {
        Bitcoins -= amount;
    }

    public void Credit(int amount)
    {
        Bitcoins += amount;
    }

    public void RunRandomTransactions()
    {
        int[] amounts = { 10, 20, 30, -20, 10, -10, 30, -10, 40, -20 }; // 80

        foreach (var amount in amounts)
        {
            var absValue = Math.Abs(amount);
            if (amount < 0)
                Debit(absValue);
            else
                Credit(absValue);
            Console.WriteLine($"[Thread: {Thread.CurrentThread.ManagedThreadId}" +
                $", Processor Id: {Thread.GetCurrentProcessorId()}] {amount}");
        }
    }

    public override string ToString()
    {
        return $"[{Name} -> {Bitcoins} Bitcoins]";
    }
}