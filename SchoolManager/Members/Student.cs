using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolManager
{
    class Student : SchoolMember
    {
        private int grade;

        public Student() { }

        public Student(string name, string address, int phonenum, int grade = 0)
        {
            Name = name;
            Address = address;
            Phone = phonenum;
            this.grade = grade;
        }

        public int Grade
        {
            get { return grade; }
            set { grade = value; }
        }

        public void display()
        {
            Console.WriteLine("Name: {0}, Address: {1}, Phone: {2}, Grade: {3}", Name, Address, Phone, Grade);
        }
    }
}
