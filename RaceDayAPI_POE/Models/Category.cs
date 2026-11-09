using System.ComponentModel.DataAnnotations;

namespace RaceDayAPI.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty; // e.g. "Senior Men 10km"
        [Required]
        public int EventId { get; set; }
        public Event? Event { get; set; }
    }
}
