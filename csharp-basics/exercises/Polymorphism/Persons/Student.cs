using System;

namespace Persons
{
    internal class Student : Persons, IPersons
    {
        private double gpa;

        public Student(string personName, string personLastName, string personAddress, int personId, double gpa) : base(personName, personLastName, personAddress, personId) 
        {
            this.gpa = gpa;
        }

        public new void Display()
        {
            base.Display();
            Console.WriteLine("Person GPA: " + gpa);
        }
    }
}
