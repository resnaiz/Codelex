using System;

namespace exercise_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Movie firstMovie = new Movie("Casino Royale", "Eon Productions", "PG-13");
            Movie secondMovie = new Movie("Glass", "Buena Vista International", "PG-13");
            Movie thirdMovie = new Movie("Spider-Man: Into the Spider-Verse", "Columbia Pictures", "PG");

            Movie[] allMovies = new Movie[] { firstMovie, secondMovie, thirdMovie };

            Console.WriteLine("PG movies: ");
            Movie[] moviesWithPG = Movie.GetPG(allMovies);
            Console.ReadKey();
        }
    }
}
