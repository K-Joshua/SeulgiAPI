using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolEnrollmentApi.EnrollmentLibrary.Models
{
    public class SubjectsAmount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubjectAmountId { get; set; }

        [ForeignKey("StudyLoadSubject")]
        [Required]
        public required int StudyLoadSubjectId { get; set; }

        [Required]
        public required double SubjectsTotalAmount { get; set; }
        [Required]
        public required DateTime CreatedAt { get; set; }

        [Required]
        public required DateTime UpdatedAt { get; set; } = DateTime.Now;
        [Required]
        public required string CreatedBy { get; set; }
    }
}
