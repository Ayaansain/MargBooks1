using NUnit.Framework;

namespace MargBooks2.Utils
{
    public class Retry
    {
        private int count = 0;
        private int maxRetry = 2;

        public bool CanRetry()
        {
            if (count < maxRetry)
            {
                count++;
                return true;
            }

            return false;
        }
    }
}