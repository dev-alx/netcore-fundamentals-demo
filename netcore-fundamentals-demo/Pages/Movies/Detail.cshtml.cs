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
    public class DetailModel : PageModel
    {
        private readonly IMovieData movieData;
        [TempData]
        public string Message { get; set; }
        public Movie Movie { get; set; }

        public DetailModel(IMovieData movieData)
        {
            this.movieData = movieData;
        }
        public IActionResult OnGet(int movieId)
        {
            Movie = movieData.GetById(movieId);
            if (Movie == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}
