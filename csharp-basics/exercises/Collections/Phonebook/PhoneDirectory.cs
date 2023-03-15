using System;
using System.Collections.Generic;

namespace PhoneBook
{
    public class PhoneDirectory
    {
        private SortedDictionary<string, PhoneEntry> _data;

        public PhoneDirectory()
        {
            _data = new SortedDictionary<string, PhoneEntry>();
        }

        public string GetNumber(string name) 
        {
            if (_data.ContainsKey(name))
            {
                return _data[name].number;
            }
            else
            {
                return null;
            }
        }

        public void PutNumber(string name, string number) 
        {
            if (name == null || number == null) 
            {
                throw new Exception("name and number cannot be null");
            }

            if (_data.ContainsKey(name)) 
            {
                _data[name].number = number;
            }
            else 
            {
                var newEntry = new PhoneEntry {name = name, number = number};
                _data.Add(name, newEntry);
            }
        }
    }
}