using System;
using System.Collections.Generic;
using System.Text;

namespace MakeSounds
{
    public class Radio : ISound
    {
        private string _radio;

        public Radio(string radio)
        {
            _radio = radio;
        }

        public void PlaySound()
        {
            Console.WriteLine(_radio);
        }
    }
}
