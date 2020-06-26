using System;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncRetry
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Task taskManager = null;

            try
            {
                const int maxRetryAttempts = 10;
                var pauseBetweenFailures = TimeSpan.FromSeconds(2);

                var commonDataAccess = new CommonDataAccess();
                var taskCoolie1 = RetryHelper.RetryOnExceptionAsync(maxRetryAttempts, pauseBetweenFailures, () => commonDataAccess.GetDataTableFromSP1());
                var taskCoolie2 = RetryHelper.RetryOnExceptionAsync(maxRetryAttempts, pauseBetweenFailures, () => commonDataAccess.GetDataTableFromSP2());
                var taskCoolie3 = RetryHelper.RetryOnExceptionAsync(maxRetryAttempts, pauseBetweenFailures, () => commonDataAccess.GetDataTableFromSP3());
                var taskCoolie4 = RetryHelper.RetryOnExceptionAsync(maxRetryAttempts, pauseBetweenFailures, () => commonDataAccess.GetDataTableFromSP4());

                taskManager = Task.WhenAll(taskCoolie1, taskCoolie2, taskCoolie3, taskCoolie4);
                await taskManager;

                Console.WriteLine("All Tasks Completed Successfully.");
            }

            catch (Exception mainEx)
            {
                Console.WriteLine($"Exception: {mainEx.Message}");
                if (taskManager?.Exception?.InnerExceptions.Any() ?? false)
                {
                    foreach (var innerEx in taskManager.Exception.InnerExceptions)
                    {
                        Console.WriteLine(innerEx.Message);
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
