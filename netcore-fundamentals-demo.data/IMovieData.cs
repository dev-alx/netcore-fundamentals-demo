using netcore_fundamentals_demo.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netcore_fundamentals_demo.data
{
    public interface IMovieData
    {
        IEnumerable<Movie> GetMoviesByName(string name);
        Movie GetById(int? id);
        Movie Update(Movie updateMovie);
        Movie Add(Movie newMovie);
        Movie Delete(int id);
        int Commit();
    }
}
