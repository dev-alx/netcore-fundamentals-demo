using System;
using System.ComponentModel.DataAnnotations;

namespace netcore_fundamentals_demo.core
{
    public class Movie
    {           
        public int Id { get; set; }
        [Required, StringLength(80)]
        public string Name { get; set; }
        public Genre Genre { get; set; }
        public int NumberInStock { get; set; }
        public int NumberAvailable { get; set; }
    }
}
