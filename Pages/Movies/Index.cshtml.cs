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

        public IList<Movie> Movie { get; set; } = default!;



        // SEARCH FIELDS
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        // GENRE FILTER
        public SelectList? Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? MovieGenre { get; set; }

        // TIMESLOT FILTER
        public SelectList? Timeslots { get; set; }
        [BindProperty(SupportsGet = true)]
        public int? TimeslotId { get; set; }

        public async Task OnGetAsync()
        {
            // GENRE QUERY
            IQueryable<string> genreQuery =
                from m in _context.Movie
                orderby m.Genre
                select m.Genre;

            // BASE QUERY INCLUDING TIMESLOT
            IQueryable<Movie> movies =
                _context.Movie
                .Include(m => m.Timeslot); // ← IMPORTANT

            // SEARCH BY TITLE
            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Title.Contains(SearchString));
            }

            // FILTER BY GENRE
            if (!string.IsNullOrEmpty(MovieGenre))
            {
                movies = movies.Where(x => x.Genre == MovieGenre);
            }

            // FILTER BY TIMESLOT
            if (TimeslotId.HasValue && TimeslotId.Value > 0)
            {
                movies = movies.Where(m => m.TimeslotId == TimeslotId.Value);
            }

            // POPULATE DROPDOWNS
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Timeslots = new SelectList(await _context.Timeslot.ToListAsync(), "Id", "Name");

            // RETURN MOVIES
            Movie = await movies.ToListAsync();
        }
    }
}
