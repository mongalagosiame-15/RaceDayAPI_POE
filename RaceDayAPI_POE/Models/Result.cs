using System.ComponentModel.DataAnnotations;

namespace RaceDayAPI.Models
{
    public class Result
    {
        [Key]
        public int Id { get; set; }
        public int EnrolmentId { get; set; }
        public Enrolment? Enrolment { get; set; }
        [Required]
        public string FinishTime { get; set; } = string.Empty; // e.g. "00:45:12"
        public int FinishingPosition { get; set; }
        public int TotalFinishers { get; set; }
    }
}
