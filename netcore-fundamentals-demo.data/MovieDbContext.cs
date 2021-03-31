using Microsoft.EntityFrameworkCore;
using netcore_fundamentals_demo.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netcore_fundamentals_demo.data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options)
            :base(options)
        {

        }
        public DbSet<Movie> Movies { get; set; }

    }
}
