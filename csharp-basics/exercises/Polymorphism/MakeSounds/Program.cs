using System;
using System.Collections.Generic;

namespace MakeSounds
{
    class Program
    {
        private static void Main(string[] args)
        {
            List<ISound> soundList = new List<ISound>();

            soundList.Add(new Parrot("Test parrot class"));
            soundList.Add(new Radio("104.3 radio station"));
            soundList.Add(new Firework());

            foreach(ISound s in soundList)
            {
                s.PlaySound();
            }
        }
    }
}