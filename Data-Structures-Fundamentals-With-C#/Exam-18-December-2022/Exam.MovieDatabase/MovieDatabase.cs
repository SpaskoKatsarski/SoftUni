using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.MovieDatabase
{
    public class MovieDatabase : IMovieDatabase
    {
        private Dictionary<Actor, List<Movie>> dict = new Dictionary<Actor, List<Movie>>();

        public void AddActor(Actor actor)
        {
            this.dict.Add(actor, new List<Movie>());
        }

        public void AddMovie(Actor actor, Movie movie)
        {
            if (!this.dict.Keys.Any(a => a.Id == a.Id))
            {
                throw new ArgumentException();
            }
            
            if (!this.dict.ContainsKey(actor))
            {
                this.dict.Add(actor, new List<Movie>());
            }

            this.dict[actor].Add(movie);
        }

        public bool Contains(Actor actor)
        {
            return this.dict.ContainsKey(actor);
        }

        public bool Contains(Movie movie)
        {
            return this.dict.Values.Any(v => v.Contains(movie));
        }

        public IEnumerable<Actor> GetActorsOrderedByMaxMovieBudgetThenByMoviesCount()
        {
            return this.dict
                .OrderByDescending(kvp => kvp.Value.Max(m => m.Budget))
                .ThenByDescending(kvp => kvp.Value.Count)
                .Select(kvp => kvp.Key);
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            List<Movie> movies = new List<Movie>();

            foreach (KeyValuePair<Actor, List<Movie>> kvp in this.dict)
            {
                foreach (var movie in kvp.Value)
                {
                    movies.Add(movie);
                }
            }

            return movies;
        }

        public IEnumerable<Movie> GetMoviesInRangeOfBudget(double lower, double upper)
        {
            IEnumerable<Movie> movies = this.GetAllMovies();

            return movies
                .Where(m => m.Budget >= lower && m.Budget <= upper)
                .OrderByDescending(m => m.Rating);
        }

        public IEnumerable<Movie> GetMoviesOrderedByBudgetThenByRating()
        {
            IEnumerable<Movie> movies = this.GetAllMovies();

            return movies
                .OrderByDescending(m => m.Budget)
                .ThenByDescending(m => m.Rating);
        }

        public IEnumerable<Actor> GetNewbieActors()
        {
            return this.dict
                .Where(kvp => kvp.Value.Count == 0)
                .Select(kvp => kvp.Key)
                .ToList();
        }
    }
}
