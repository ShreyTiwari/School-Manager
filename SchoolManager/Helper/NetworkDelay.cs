using System;
using System.Threading;

namespace Util
{
    public class NetworkDelay
    {
        private const int minDelay = 1000;
        private const int maxDelay = 5000;

        public static int MinDelay
        {
            get { return minDelay; }
        }

        public static int MaxDelay
        {
            get { return maxDelay; }
        }

        static public void SimulateNetworkDelay()
        {
            Random rnd = new Random();
            Thread.Sleep(rnd.Next(minDelay, maxDelay));
        }
    }
}
