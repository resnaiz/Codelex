using System;

namespace Persons
{
    internal class Employee : Persons, IPersons
    {
        private string jobTitle;

        public Employee(string personName, string personLastName, string personAddress, int personId, string jobTitle) : base(personName, personLastName, personAddress, personId)
        {
            this.jobTitle = jobTitle;
        }

        public new void Display()
        {
            base.Display();
            Console.WriteLine("Person job title: " + jobTitle);
        }
    }
}
