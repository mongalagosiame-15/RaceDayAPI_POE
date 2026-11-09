using System.ComponentModel.DataAnnotations;

namespace RaceDayAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string PasswordHash { get; set; } = string.Empty;
        [Required]
        public string Role { get; set; } = "Participant"; // "Organiser" or "Participant"
        public string? ProfilePictureUrl { get; set; }
    }
}
