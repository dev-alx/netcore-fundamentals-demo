using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using netcore_fundamentals_demo.core;
using netcore_fundamentals_demo.data;

namespace netcore_fundamentals_demo.Pages.Movies
{
    public class EditModel : PageModel
    {
        private readonly IMovieData movieData;

        [BindProperty]
        public Movie Movie { get; set; }
        public IEnumerable<SelectListItem> Genre { get; set; }
        public IHtmlHelper htmlHelper { get; }

        public EditModel(IMovieData movieData, IHtmlHelper htmlHelper)
        {
            this.movieData = movieData;
            this.htmlHelper = htmlHelper;            
        }
        public IActionResult OnGet(int? movieId)
        {
            Genre = htmlHelper.GetEnumSelectList<Genre>();
            if (movieId.HasValue)
            {
                Movie = movieData.GetById(movieId);
            }
            else
            {
                Movie = new Movie();
            }
            
            if (Movie == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Genre = htmlHelper.GetEnumSelectList<Genre>();
                return Page();                
            }

            if (Movie.Id > 0)
            {
                movieData.Update(Movie);
            }
            else
            {
                movieData.Add(Movie);
            }
            TempData["Message"] = "Movie Saved!";
            movieData.Commit();
            return RedirectToPage("./Detail", new { movieId = Movie.Id });

        }
    }
}
