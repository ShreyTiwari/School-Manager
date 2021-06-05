using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManager
{
    class Program
    {
        static List<Student> students = new List<Student>();
        static List<Teacher> teachers = new List<Teacher>();
        static Principal principal = new Principal();

        enum SchoolMemberType
        {
            typePrincipal,
            typeTeacher,
            typeStudent
        }

        static private SchoolMember AcceptAttributes()
        {
            SchoolMember member = new SchoolMember();
            member.Name = Util.Console.AskQuestion("Enter name: ");
            member.Address = Util.Console.AskQuestion("Enter address: ");
            member.Phone = Util.Console.AskQuestionInt("Enter phone number: ");

            return member;
        }

        static int AcceptChoices()
        {
            return Util.Console.AskQuestionInt("\n1. Add\n2. Display\n3. Pay\nPlease enter the member type: ");
        }

        static int AcceptMemberType()
        {
            return Util.Console.AskQuestionInt("\n1. Principal\n2. Teacher\n3. Student\nPlease enter the member type: ");
        }

        static void AddPrincpal()
        {
            SchoolMember member = AcceptAttributes();
            principal.Name = member.Name;
            principal.Address = member.Address;
            principal.Phone = member.Phone;
        }

        static void AddStudent()
        {
            SchoolMember member = AcceptAttributes();
            Student newStudent = new Student(member.Name, member.Address, member.Phone);
            newStudent.Grade = Util.Console.AskQuestionInt("Enter grade: ");

            students.Add(newStudent);
        }

        static void AddTeacher()
        {
            SchoolMember member = AcceptAttributes();
            Teacher newTeacher = new Teacher(member.Name, member.Address, member.Phone);
            newTeacher.Subject = Util.Console.AskQuestion("Enter subject: ");

            teachers.Add(newTeacher);
        }

        static void Add()
        {
            Console.WriteLine("\nPlease note that the Principal details cannot be added or modified now.");
            int memberType = AcceptMemberType();

            switch (memberType)
            {
                case 2:
                    AddTeacher();
                    break;
                case 3:
                    AddStudent();
                    break;
                default:
                    Console.WriteLine("Invalid input. Terminating operation.");
                    break;
            }
        }

        static void Display()
        {
            int memberType = AcceptMemberType();

            switch (memberType)
            {
                case 1:
                    Console.WriteLine("\nThe Principal's details are:");
                    principal.display();
                    break;
                case 2:
                    Console.WriteLine("\nThe teachers are:");
                    foreach (Teacher teacher in teachers)
                        teacher.display();
                    break;
                case 3:
                    Console.WriteLine("\nThe students are:");
                    foreach (Student student in students)
                        student.display();
                    break;
                default:
                    Console.WriteLine("Invalid input. Terminating operation.");
                    break;
            }
        }

        static void Pay()
        {
            Console.WriteLine("\nPlease note that the students cannot be paid.");
            int memberType = AcceptMemberType();

            Console.WriteLine("\nPayments in progress...");

            switch (memberType)
            {
                case 1:
                    principal.Pay();
                    break;
                case 2:
                    List<Task> payments = new List<Task>();

                    foreach (Teacher teacher in teachers)
                    {
                        Task payment = new Task(teacher.Pay);
                        payments.Add(payment);
                        payment.Start();
                    }

                    Task.WaitAll(payments.ToArray());

                    break;
                default:
                    Console.WriteLine("Invalid input. Terminating operation.");
                    break;
            }

            Console.WriteLine("Payments completed.\n");
        }

        static void addData()
        {
            for (int i = 0; i < 10; i++)
            {
                students.Add(new Student(i.ToString(), i.ToString(), i));
                teachers.Add(new Teacher(i.ToString(), i.ToString(), i));
            }
        }

        static void Main(string[] args)
        {
            addData();

            Console.WriteLine("-------------- Welcome ---------------\n");

            Console.WriteLine("Please enter the Princpals information.");
            AddPrincpal();

            bool flag = true;
            while (flag)
            {

                int choice = AcceptChoices();
                switch (choice)
                {
                    case 1:
                        Add();
                        break;
                    case 2:
                        Display();
                        break;
                    case 3:
                        Pay();
                        break;
                    default:
                        flag = false;
                        break;
                }
            }

            Console.WriteLine("\n-------------- Bye --------------");
        }
    }
}
