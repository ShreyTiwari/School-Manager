using Util;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SchoolManager.UnitTests
{
    [TestClass]
    public class ConsoleHelperTests
    {
        private static bool inRange(long value)
        {
            if (value > NetworkDelay.MinDelay && value < NetworkDelay.MaxDelay)
                return true;
            else
                return false;
        }

        [TestMethod]
        public void Test_timeinrange_SimulateNetworkDelay()
        {
            // Arrange
            Stopwatch watch;

            // Act
            watch = Stopwatch.StartNew();
            NetworkDelay.SimulateNetworkDelay();
            watch.Stop();

            // assert
            Assert.IsTrue(inRange(watch.ElapsedMilliseconds));
        }
    }
}
