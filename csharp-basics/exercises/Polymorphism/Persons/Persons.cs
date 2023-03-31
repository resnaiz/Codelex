using System;

namespace Persons
{
    public class Persons : IPersons
    {
        protected string personName;
        protected string personLastName;
        protected string personAddress;
        protected int personId;

        public Persons(string personName, string personLastName, string personAddress, int personId)
        {
            this.personName = personName;
            this.personLastName = personLastName;
            this.personAddress = personAddress;
            this.personId = personId;
        }

        public void Display()
        {
            Console.WriteLine("Person name: " + personName);
            Console.WriteLine("Person last name: " + personLastName);
            Console.WriteLine("Person Address: " + personAddress);
            Console.WriteLine("Person ID: " + personId);
        }
    }
}