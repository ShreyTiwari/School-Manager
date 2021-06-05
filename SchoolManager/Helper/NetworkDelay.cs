using System;
using System.Threading;

namespace Util
{
    public class NetworkDelay
    {
        public const int MinDelay = 1000;
        public const int MaxDelay = 5000;

        static public void SimulateNetworkDelay()
        {
            Random rnd = new Random();
            Thread.Sleep(rnd.Next(MinDelay, MaxDelay));
        }
    }
}
