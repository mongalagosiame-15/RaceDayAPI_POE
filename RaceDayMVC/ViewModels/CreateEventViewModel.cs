using System.ComponentModel.DataAnnotations;

namespace RaceDayMVC.ViewModels
{
    public class CreateEventViewModel
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public DateTime Date { get; set; } = DateTime.Now.AddDays(7);
        [Required]
        public string Location { get; set; } = string.Empty;
        [Required]
        public double Distance { get; set; }
        [Required]
        public string EventType { get; set; } = string.Empty;
        public IFormFile? BannerImage { get; set; }
        public int OrganiserId { get; set; }
    }
}
