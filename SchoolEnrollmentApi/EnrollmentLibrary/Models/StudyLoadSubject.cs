using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SchoolEnrollmentApi.EnrollmentLibrary.Models
{
    public class StudyLoadSubject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudyLoadSubjectId { get; set; }

        [Required]
        [ForeignKey("Subject")]
        public required int SubjectId { get; set; }

        [Required]
        [ForeignKey("Instructor")]
        public required int InstructorId { get; set; }

        [Required]
        public required string Day { get; set; } // Day of the week

        [MaxLength(12)]
        [Required]
        public required TimeOnly StartTime { get; set; }
        public void SetStartTime(string startTime)
        {
            StartTime = TimeOnly.Parse(startTime);
        }

        [MaxLength(12)]
        [Required]
        public required TimeOnly EndTime { get; set; }
        public void SetEndTime(string endTime)
        {
            EndTime = TimeOnly.Parse(endTime);
        }
        [Required]
        public required DateTime CreatedAt { get; set; }

        [Required]
        public required DateTime UpdatedAt { get; set; } = DateTime.Now;
        [Required]
        [MaxLength(100)]
        public required string CreatedBy { get; set; }
        [Required]
        [MaxLength(200)]
        public required string Description { get; set; } // Description of the subject
    }
}
