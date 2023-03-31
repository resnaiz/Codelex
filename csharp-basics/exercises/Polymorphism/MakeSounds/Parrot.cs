using System;

namespace MakeSounds
{
    public class Parrot : ISound
    {
        private string _sound;

        public Parrot(string sound)
        {
            _sound = sound;
        }

        public void PlaySound()
        {
            Console.WriteLine(_sound);
        }
    }
}
