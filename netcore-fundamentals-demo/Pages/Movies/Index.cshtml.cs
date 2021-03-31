using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using netcore_fundamentals_demo.core;
using netcore_fundamentals_demo.data;

namespace netcore_fundamentals_demo.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly IMovieData movieData;

        //ouput 
        public IEnumerable<Movie> Movies { get; set; }
        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }
        public IndexModel(IMovieData movieData)
        {
            this.movieData = movieData;
        }
        public void OnGet()
        {
            Movies = movieData.GetMoviesByName(SearchTerm);
        }
    }
}
