using netcore_fundamentals_demo.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netcore_fundamentals_demo.data
{
    public class InMemoryMovieData : IMovieData
    {
        readonly List<Movie> movies;
        public InMemoryMovieData()
        {
            movies = new List<Movie>()
            {
                new Movie{Id = 1, Name = "Star War", NumberAvailable = 5, NumberInStock = 5, Genre = Genre.Science_Fiction },
                new Movie{Id = 2, Name = "Black Clover", NumberAvailable = 5, NumberInStock = 5, Genre = Genre.Animation },
                new Movie{Id = 3, Name = "The Avengers", NumberAvailable = 5, NumberInStock = 5, Genre = Genre.Action }
            };
        }

        public Movie Add(Movie newMovie)
        {
            movies.Add(newMovie);
            newMovie.Id = movies.Max(m => m.Id) + 1;
            return newMovie;
        }

        public int Commit()
        {
            return 0;
        }

        public Movie Delete(int id)
        {
            var movie = movies.Find(m => m.Id == id);
            if (movie != null)
            {
                movies.Remove(movie);
            }
            
            return movie;
        }

        public Movie GetById(int? id)
        {
            return movies.SingleOrDefault(m => m.Id == id);
        }

        public IEnumerable<Movie> GetMoviesByName(string name = null)
        {            
            return string.IsNullOrEmpty(name) ? movies.ToList() : movies.Where(m => m.Name.StartsWith(name)).ToList();
        }

        public Movie Update(Movie updateMovie)
        {
            var movie = movies.SingleOrDefault(m => m.Id == updateMovie.Id);
            if (movie != null)
            {
                movie.Name = updateMovie.Name;
                movie.Genre = updateMovie.Genre;
            }
            return movie;
        }
    }
}
