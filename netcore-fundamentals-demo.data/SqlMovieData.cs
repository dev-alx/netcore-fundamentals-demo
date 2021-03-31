using Microsoft.EntityFrameworkCore;
using netcore_fundamentals_demo.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netcore_fundamentals_demo.data
{
    public class SqlMovieData : IMovieData
    {
        private readonly MovieDbContext db;

        public SqlMovieData(MovieDbContext db)
        {
            this.db = db;
        }
        public Movie Add(Movie newMovie)
        {
            db.Add(newMovie);
            return newMovie;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Movie Delete(int id)
        {
            var movie = GetById(id);
            if (movie !=null)
            {
                db.Movies.Remove(movie);
            }
            return movie;
        }

        public Movie GetById(int? id)
        {
            return db.Movies.Find(id); 
        }

        public IEnumerable<Movie> GetMoviesByName(string name)
        {
            return string.IsNullOrEmpty(name) ? db.Movies.ToList() : db.Movies.Where(m => m.Name.StartsWith(name)).ToList();
        }

        public Movie Update(Movie updateMovie)
        {
            var entity = db.Movies.Attach(updateMovie);
            entity.State = EntityState.Modified;
            return updateMovie;
        }
    }
}
