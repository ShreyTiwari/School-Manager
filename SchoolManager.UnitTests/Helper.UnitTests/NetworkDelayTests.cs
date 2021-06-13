using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.IO;
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

        [TestMethod]
        public void Test_PayEntity()
        {
            // Arrange
            string entity = "test_entity";
            string name = "test_name";
            int balance = 0;
            int income = 10;

            int expectedBalance = balance + income;
            string expectedOutput = $"Paid {entity}: {name}. Total balance: {expectedBalance}\r\n";


            using (StringWriter sw = new StringWriter())
            {
                System.Console.SetOut(sw);

                // Act
                NetworkDelay.PayEntity(entity, name, ref balance, income);

                // Assert
                Assert.AreEqual(expectedOutput, sw.ToString());
                Assert.AreEqual(expectedBalance, balance);
            }
        }
    }
}
