using System.ComponentModel.DataAnnotations;

namespace MidTerm.Entities
{
    public class Timesheet
    {
        [Key]
        public int? ProjectId {  get; set; }

        [Required(ErrorMessage = "Please enter Project name")]
        public string? ProjectName { get; set; }

        [Required(ErrorMessage = "Please enter Date")]
        public DateTime? ProjectDate { get; set; }

        [Required(ErrorMessage = "PLease enter Hours of Duration")]
        [Range(1, 40, ErrorMessage = "Hours Duration must be between 1 and 40")]
        public int? ProjectDuration {  get; set; }
    }
}
