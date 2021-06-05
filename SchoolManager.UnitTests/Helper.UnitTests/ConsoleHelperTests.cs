using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.IO;
using Util;

namespace SchoolManager.UnitTests
{
    [TestClass]
    public class ConsoleHelperTests
    {
        [TestMethod]
        public void Test_StringEnteredIsStringReceived_AskQuestion()
        {   
            // Arrange
            string expectedQuestionAsked = "Enter Something";
            string expectedResultReceived = "Test Input String";
            
            using (StringWriter sw = new StringWriter())
            {
                using (StringReader sr = new StringReader(expectedResultReceived))
                {
                    System.Console.SetOut(sw);
                    System.Console.SetIn(sr);

                    // Act
                    string actualResultReceived = Util.Console.AskQuestion(expectedQuestionAsked);

                    // Assert
                    Assert.AreEqual(expectedQuestionAsked, sw.ToString());
                    Assert.AreEqual(expectedResultReceived, actualResultReceived);
                }
            }
        }

        [TestMethod]
        public void Test_IntEnteredIsIntReceived_AskQuestionInt()
        {
            // Arrange
            string expectedQuestionAsked = "Enter Something";
            string expectedResultReceived = "1";

            using (StringWriter sw = new StringWriter())
            {
                using (StringReader sr = new StringReader(expectedResultReceived))
                {
                    System.Console.SetOut(sw);
                    System.Console.SetIn(sr);

                    // Act
                    int actualResultReceived = Util.Console.AskQuestionInt(expectedQuestionAsked);

                    // Assert
                    Assert.AreEqual(expectedQuestionAsked, sw.ToString());
                    Assert.AreEqual(expectedResultReceived, actualResultReceived.ToString());
                }
            }
        }

        [TestMethod]
        public void Test_IntEnteredIsIntReceivedAfterInvalidString_AskQuestionInt()
        {
            // Arrange
            string expectedQuestionAsked = "Enter Something";
            string expectedErrorMessage = "Invalid input. Please try again: ";
            string invalidString = "a" + Environment.NewLine;
            string expectedResultReceived = "1";

            using (StringWriter sw = new StringWriter())
            {
                using (StringReader sr = new StringReader(invalidString + expectedResultReceived))
                {
                    System.Console.SetOut(sw);
                    System.Console.SetIn(sr);

                    // Act
                    int actualResultReceived = Util.Console.AskQuestionInt(expectedQuestionAsked);

                    // Assert
                    Assert.AreEqual(expectedQuestionAsked+expectedErrorMessage, sw.ToString());
                    Assert.AreEqual(expectedResultReceived, actualResultReceived.ToString());
                }
            }
        }
    }
}
