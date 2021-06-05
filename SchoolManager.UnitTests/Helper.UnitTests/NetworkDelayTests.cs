using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using Util;

namespace SchoolManager.UnitTests
{
    [TestClass]
    public class NetworkDelayTests
    {
        private static bool inRange(long value)
        {
            if (value > NetworkDelay.MinDelay && value < NetworkDelay.MaxDelay)
                return true;
            else
                return false;
        }

        [TestMethod]
        public void Test_TimeInRange_SimulateNetworkDelay()
        {
            // Arrange
            Stopwatch watch;

            // Act
            watch = Stopwatch.StartNew();
            NetworkDelay.SimulateNetworkDelay();
            watch.Stop();

            // Assert
            Assert.IsTrue(inRange(watch.ElapsedMilliseconds));
        }
    }
}
