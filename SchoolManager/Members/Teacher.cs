using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolManager
{
    class Teacher : SchoolMember, IPayroll
    {
        public string Subject;
        private int income;
        private int balance;

        public Teacher(string name, string address, int phonenum, string subject = "", int income = 25000)
        {
            Name = name;
            Address = address;
            Phone = phonenum;
            Subject = subject;
            this.income = income;
            balance = 0;
        }

        public void display()
        {
            Console.WriteLine("Name: {0}, Address: {1}, Phone: {2}, Subject: {3}", Name, Address, Phone, Subject);
        }

        public void Pay()
        {
            balance += income;
            Console.WriteLine("Paid Teacher: {0}. Total income: {1}", Name, balance);
        }
    }
}
