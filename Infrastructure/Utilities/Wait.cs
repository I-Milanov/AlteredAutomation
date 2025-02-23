namespace Infrastructure.Utilities
{
    public sealed class Wait
    {
        public static void Until(
        Func<bool> condition,
        int timeoutInSeconds = 10,
        string exceptionMessage = "Timeout exceeded.",
        int retryRateDelay = 50)
        {
            var start = DateTime.Now;
            while (!condition())
            {
                var now = DateTime.Now;
                var totalSeconds = (now - start).TotalSeconds;
                if (totalSeconds >= timeoutInSeconds)
                {
                    throw new TimeoutException(exceptionMessage + $" Elapsed time: {totalSeconds} s.");
                }

                Thread.Sleep(retryRateDelay);
            }
        }
    }
}
