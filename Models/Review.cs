using System;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesMovie.Models
{
    public class Review
    {
        public int Id { get; set; }

        [Required]
        public int MovieId { get; set; }

        [Required]
        public string UserName { get; set; } = string.Empty;

        [Range(1, 5)]
        public int Rating { get; set; } // 1-5

        public string comment { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigatuion Property
        public Movie movie { get; set; } = null!;
    }
}
