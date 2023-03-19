using System;

namespace Persons
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student("Ivars", "Lapsa", "Riga, Latvia", 18, 5);
            Employee employee = new Employee("Jānis", "Ozols", "Liepāja", 24, "Programmer");

            Console.WriteLine("Student info: ");
            student.Display();
            Console.WriteLine();
            Console.WriteLine("Employee info: ");
            employee.Display();
            Console.WriteLine();
        }
    }
}