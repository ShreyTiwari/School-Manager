using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager
{
    public class Receptionist : SchoolMember, IPayroll
    {
        private int income;
        private int balance;

        public Receptionist(int income = 10000) 
        {
            this.income = income;
            balance = 0;
        }

        public Receptionist(string name, string address, int phoneNum, int income = 10000)
        {
            Name = name;
            Address = address;
            Phone = phoneNum;
            this.income = income;
            balance = 0;
        }

        public void display()
        {
            Console.WriteLine("Name: {0}, Address: {1}, Phone: {2}", Name, Address, Phone);
        }

        public void Pay()
        {
            Util.NetworkDelay.PayEntity("Receptionist", Name, ref balance, income);
        }
    }
}
