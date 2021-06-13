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

        static public void PayEntity(string entity, string name, ref int balance, int income)
        {
            SimulateNetworkDelay();

            balance += income;
            System.Console.WriteLine($"Paid {entity}: {name}. Total balance: {balance}");
        }
    }
}
