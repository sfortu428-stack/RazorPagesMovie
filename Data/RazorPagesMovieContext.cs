using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Data
{
    public class RazorPagesMovieContext : DbContext
    {
        public DbSet<Timeslot> Timeslot { get; set; }


        public RazorPagesMovieContext(DbContextOptions<RazorPagesMovieContext> options)
            : base(options)
        {
        }

        public DbSet<Director> Director { get; set; } = default!;
        public DbSet<Movie> Movie { get; set; } = default!;
        public DbSet<Actor> Actors { get; set; } = default!;
        public DbSet<RazorPagesMovie.Models.Customers> Customers { get; set; } = default!;
        public DbSet<Admin> Admin { get; set; } = default!;
        public DbSet<RazorPagesMovie.Models.Review> Review { get; set; } = default!;

    }
    
}
