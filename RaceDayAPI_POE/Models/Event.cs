using System.ComponentModel.DataAnnotations;

namespace RaceDayAPI.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Location { get; set; } = string.Empty;
        [Required]
        public double Distance { get; set; } // in km
        [Required]
        public string EventType { get; set; } = string.Empty; // e.g. Running, Cycling
        public string? BannerImageUrl { get; set; }

        public int OrganiserId { get; set; }
        public ICollection<Category> Categories { get; set; } = new List<Category>();
        public ICollection<Enrolment> Enrolments { get; set; } = new List<Enrolment>();
    }
}
