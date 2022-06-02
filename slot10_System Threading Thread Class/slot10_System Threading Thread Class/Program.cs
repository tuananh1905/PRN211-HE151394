using System;
using System.Threading;
using static System.Console;

namespace slot10_System_Threading_Thread_Class
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread primaryThread = Thread.CurrentThread;
            primaryThread.Name = "ThePrimaryThread";
            WriteLine($"ID of current thread: {primaryThread.ManagedThreadId}");
            WriteLine($"Thread Name: {primaryThread.Name}");
            WriteLine("Has thread started?: {primaryThread.IsAlive}");
            WriteLine("Thread Name: {primaryThread.Name}");
            ReadLine();
        }
    }
}
