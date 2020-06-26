using System;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncRetry
{
    public static class RetryHelper
    {
        public static int[] DelayPerAttemptInSeconds =
        {
            (int) TimeSpan.FromSeconds(2).TotalSeconds,
            (int) TimeSpan.FromSeconds(30).TotalSeconds,
            (int) TimeSpan.FromMinutes(2).TotalSeconds,
            (int) TimeSpan.FromMinutes(10).TotalSeconds,
            (int) TimeSpan.FromMinutes(30).TotalSeconds
        };

        public static async Task RetryOnExceptionAsync(int times, TimeSpan delay, Func<Task> operation)
        {
            var attempts = 0;
            do
            {
                try
                {
                    attempts++;
                    await operation();
                    break;
                }
                catch (Exception ex)
                {
                    if (attempts == times)
                        throw;

                    await CreateDelayForException(times, attempts, ex);
                }
            } while (true);
        }

        private static Task CreateDelayForException(int times, int attempts, Exception ex)
        {
            var delay = IncreasingDelayInSeconds(attempts);
            Console.Write($"Exception on attempt {attempts} of {times}. Will retry after sleeping for {delay}.");
            Console.WriteLine($"Exception Message: {ex.Message}");
            return Task.Delay(delay);
        }

        private static int IncreasingDelayInSeconds(int failedAttempts)
        {
            return failedAttempts > DelayPerAttemptInSeconds.Length ? DelayPerAttemptInSeconds.Last() : DelayPerAttemptInSeconds[failedAttempts];
        }
    }
}
