using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolManager
{
    class Principal : SchoolMember, IPayroll
    {
        private int income;
        private int balance;

        public Principal(int income = 50000)
        {
            this.income = income;
            balance = 0;
        }

        public void display()
        {
            Console.WriteLine("Name: {0}, Address: {1}, Phone: {2}", Name, Address, Phone);
        }

        public void Pay()
        {
            Util.NetworkDelay.SimulateNetworkDelay();

            balance += income;
            Console.WriteLine("Paid Principal: {0}. Total income: {1}", Name, balance);
        }
    }
}
