using System;
using System.Drawing;

namespace exercise_8
{
    internal class Program
    {
        public static void SwapPoints(ref Point p1, ref Point p2)
        {
            int locX = p1.X;
            int locY = p1.Y;
            p1.X = p2.X;
            p1.Y = p2.Y;
            p2.X = locX;
            p2.Y = locY;
        }

        static void Main(string[] args)
        {
            Point p1 = new Point(5, 2);
            Point p2 = new Point(-3, 6);
            SwapPoints(ref p1, ref p2);
            Console.WriteLine("(" + p1.X + ", " + p1.Y + ")");
            Console.WriteLine("(" + p2.X + ", " + p2.Y + ")");
        }
    }
}
