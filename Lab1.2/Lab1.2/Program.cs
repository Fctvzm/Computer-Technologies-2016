using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Student a = new Student();
            a.Name = "Assem";
            a.Surname = "Zaitkaliyeva";
            a.gpa = 4.0;
            a.age = 17;
            Console.WriteLine(a);
            Console.ReadKey();
        }
    }

    class Student
    {
        public string Name, Surname;
        public int age;
        public double gpa;

        public override string ToString()
        {
            return this.Surname + " " + this.Name + " " + this.age+" "+this.gpa;
        }
    }
}
