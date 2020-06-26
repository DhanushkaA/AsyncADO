using System;
using System.Threading;

namespace AsyncRetry
{
    public static class Logger
    {
        public static void Log(string operation)
        {
            Console.WriteLine($"Thread id : {Thread.CurrentThread.ManagedThreadId} => {operation}");
        }
    }
}
