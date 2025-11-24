using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovieContext _context;

        public IndexModel(RazorPagesMovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get; set; } = new List<Movie>();

        // SEARCH
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        // GENRE FILTER
        public SelectList? Genres { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? MovieGenre { get; set; }

        // TIMESLOT FILTER
        [BindProperty(SupportsGet = true)]
        public int TimeslotId { get; set; }

        public List<SelectListItem> Timeslots { get; set; }

        public async Task OnGetAsync()
        {
            // Get unique genres
            IQueryable<string> genreQuery =
                from m in _context.Movie
                orderby m.Genre
                select m.Genre;

            // Base movie query
            IQueryable<Movie> movies = _context.Movie
                .Include(m => m.Director)
                .Include(m => m.Actor);

            // Filter by search string
            if (!string.IsNullOrEmpty(SearchString))
                movies = movies.Where(m => m.Title.Contains(SearchString));

            // Filter by genre
            if (!string.IsNullOrEmpty(MovieGenre))
                movies = movies.Where(m => m.Genre == MovieGenre);

           
         
            // Load movies
            Movie = await movies.ToListAsync();
        }
    }
}
