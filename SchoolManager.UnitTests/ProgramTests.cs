using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.IO;
using Util;

namespace SchoolManager.UnitTests
{
    [TestClass]
    public class ProgramTests
    {
        static string name = "TestName";
        static string address = "TestAddress";
        static int phone = 123;
        static string input = name + Environment.NewLine + address + Environment.NewLine + phone.ToString();

        [TestMethod]
        public void Test_SchoolMemberReceivedIsSchoolMemeberProvided_AcceptAttributes()
        {
            // Arrange
            SchoolMember expectedMember = new SchoolMember(name, address, phone);

            using (StringWriter sw = new StringWriter())
            {
                using (StringReader sr = new StringReader(input))
                {
                    System.Console.SetOut(sw);
                    System.Console.SetIn(sr);

                    // Act
                    SchoolMember receivedMember = Program.AcceptAttributes();

                    // Assert
                    Assert.AreEqual(expectedMember.Name, receivedMember.Name);
                    Assert.AreEqual(expectedMember.Address, receivedMember.Address);
                    Assert.AreEqual(expectedMember.Phone, receivedMember.Phone);
                }
            }
        }

        [TestMethod]
        public void Test_PrincipalReceivedIsPrincipalProvided_AcceptAttributes()
        {
            // Arrange
            using (StringWriter sw = new StringWriter())
            {
                using (StringReader sr = new StringReader(input))
                {
                    System.Console.SetOut(sw);
                    System.Console.SetIn(sr);

                    // Act
                    Program.AddPrincpal();

                    // Assert
                    Assert.AreEqual(name, Program.Principal.Name);
                    Assert.AreEqual(address, Program.Principal.Address);
                    Assert.AreEqual(phone, Program.Principal.Phone);
                }
            }
        }

        [TestMethod]
        public void Test_InvalidInput_Add()
        {
            // Arrange
            string input = "1";
            string errorMessage = "Invalid input";

            using (StringWriter sw = new StringWriter())
            {
                using (StringReader sr = new StringReader(input))
                {
                    System.Console.SetOut(sw);
                    System.Console.SetIn(sr);

                    // Act
                    Program.Add();

                    // Assert
                    Assert.IsTrue(sw.ToString().Contains(errorMessage));
                }
            }
        }

        [TestMethod]
        public void Test_Student_Add()
        {
            // Arrange
            string inputTypeStudent = "3";
            int grade = 10;
            string inputString = inputTypeStudent + Environment.NewLine + input + Environment.NewLine + grade.ToString();

            int initCount = Program.Students.Count;

            using (StringWriter sw = new StringWriter())
            {
                using (StringReader sr = new StringReader(inputString))
                {
                    System.Console.SetOut(sw);
                    System.Console.SetIn(sr);

                    // Act
                    Program.Add();

                    // Assert
                    Assert.AreEqual(initCount + 1, Program.Students.Count);
                    Assert.AreEqual(name, Program.Students[0].Name);
                    Assert.AreEqual(address, Program.Students[0].Address);
                    Assert.AreEqual(phone, Program.Students[0].Phone);
                    Assert.AreEqual(grade, Program.Students[0].Grade);
                }
            }
        }

        [TestMethod]
        public void Test_Teacher_Add()
        {
            // Arrange
            string inputTypeStudent = "2";
            string subject = "abc";
            string inputString = inputTypeStudent + Environment.NewLine + input + Environment.NewLine + subject;

            int initCount = Program.Teachers.Count;

            using (StringWriter sw = new StringWriter())
            {
                using (StringReader sr = new StringReader(inputString))
                {
                    System.Console.SetOut(sw);
                    System.Console.SetIn(sr);

                    // Act
                    Program.Add();

                    // Assert
                    Assert.AreEqual(initCount + 1, Program.Teachers.Count);
                    Assert.AreEqual(name, Program.Teachers[initCount].Name);
                    Assert.AreEqual(address, Program.Teachers[initCount].Address);
                    Assert.AreEqual(phone, Program.Teachers[initCount].Phone);
                    Assert.AreEqual(subject, Program.Teachers[initCount].Subject);
                }
            }
        }
    }
}
