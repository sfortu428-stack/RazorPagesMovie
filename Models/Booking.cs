using System;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesMovie.Models
{
    public class Booking
    {
        public int Id { get; set; }

        // Relationship with Movie
        [Required]
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        // Relationship with TimeSlot
        [Required]
        public int TimeslotId { get; set; }
        public Timeslot Timeslot { get; set; }

        // Booking details
        [Required(ErrorMessage = "Customer name is required")]
        [StringLength(100)]
        public string CustomerName { get; set; }

        [Required]
        [Range(1, 20, ErrorMessage = "You can book between 1 and 20 seats")]
        public int Seats { get; set; }

        [Display(Name = "Booking Date")]
        public DateTime BookingDate { get; set; } = DateTime.Now;

        [EmailAddress]
        public string? CustomerEmail { get; set; }

        [Phone]
        public string? CustomerPhone { get; set; }
    }
}

