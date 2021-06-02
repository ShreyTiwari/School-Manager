using System;
using System.Threading;

namespace Util
{
    class NetworkDelay
    {
        private const int minDelay = 1000;
        private const int maxDelay = 5000;

        static public void SimulateNetworkDelay()
        {
            Random rnd = new Random();
            Thread.Sleep(rnd.Next(minDelay, maxDelay));
        }
    }
}
