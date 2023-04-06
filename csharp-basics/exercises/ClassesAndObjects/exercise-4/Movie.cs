using System;

namespace exercise_4
{
    internal class Movie
    {
        private string _title;
        private string _studio;
        private string _rating;

        public Movie(string movieTitle, string movieStudio, string movieRating)
        {
            _title = movieTitle;
            _studio = movieStudio;
            _rating = movieRating;
        }

        public Movie(string movieTitle, string movieStudio)
        {
            _title = movieTitle;
            _studio = movieStudio;
        }

        public static Movie[] GetPG(Movie[] movies)
        {
            Movie[] moviesWithPG = new Movie[movies.Length];
            int counter = 0;

            foreach(Movie oneMovie in movies)
            {
                if(oneMovie._rating == "PG")
                {
                    moviesWithPG[counter] = oneMovie;
                    counter++;
                    Console.WriteLine("{0}, {1}, {2}", oneMovie._title, oneMovie._studio, oneMovie._rating);
                }
            }

            Array.Resize(ref moviesWithPG, counter);
            return moviesWithPG;
        }
    }
}
