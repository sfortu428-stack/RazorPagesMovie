using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesMovieContext _context;

        public CreateModel(RazorPagesMovieContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Movie Movie { get; set; } = default!;

        public SelectList TimeslotList { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            await LoadTimeslotsAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await LoadTimeslotsAsync();
                return Page();
            }

            _context.Movie.Add(Movie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private async Task LoadTimeslotsAsync()
        {
            var timeslots = await _context.Timeslot
                .Select(t => new
                {
                    t.Id,
                    Label = t.StartTime.ToString("HH:mm") + " - " + t.EndTime.ToString("HH:mm") +
                            (!string.IsNullOrEmpty(t.Description) ? $" ({t.Description})" : "")
                })
                .ToListAsync();

            TimeslotList = new SelectList(timeslots, "Id", "Label");
        }
    }
}
