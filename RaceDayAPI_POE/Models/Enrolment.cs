using System.ComponentModel.DataAnnotations;

namespace RaceDayAPI.Models
{
    public class Enrolment
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public int EventId { get; set; }
        public Event? Event { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public string Status { get; set; } = "Confirmed"; // Confirmed, Pending
        public Result? Result { get; set; }
    }
}
