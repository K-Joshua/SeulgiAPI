using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolEnrollmentApi.EnrollmentLibrary.Models
{
    public class Enrollment
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EnrollmentId { get; set; }

        [Required]
        [ForeignKey("Student")]
        public required int StudentId { get; set; }


        [Required]
        [ForeignKey("Requirement")]
        public required int RequirementId { get; set; }


        [Required]
        [ForeignKey("StudentType")]
        public required int StudentTypeId { get; set; }

        [Required]
        public required DateOnly YearToEnroll { get; set; }
        public void SetYearToEnroll(string yeartoenroll)
        {
            YearToEnroll = DateOnly.Parse(yeartoenroll);
        }

        [Required]
        public int CourseQuantity { get; set; } = 1;

        [Required]
        [ForeignKey("StudyLoad")]
        public required int StudyLoadId { get; set; }

        [Required]
        [ForeignKey("ExamRecord")]
        public required int ExamRecordId { get; set; }

        [Required]
        [ForeignKey("Scholarship")]
        public required int ScholarshipId { get; set; }

        [Required]
        public required int ScholarshipQuantity { get; set; } = 0;

        [Required]
        [ForeignKey("Payment")]
        public required int PaymentId { get; set; }

        [Required]
        public required double TotalAmount { get; set; } = 0.0;

        [Required]
        public required DateTime CreatedAt { get; set; }

        [Required]
        public required DateTime UpdatedAt { get; set; } = DateTime.Now;
        [Required]
        [MaxLength(100)]
        public required string CreatedBy { get; set; }

        [Required]
        [ForeignKey("TaskStatus")]
        public required int TaskStatusId { get; set; } //    w/ Paid, Unpaid, etc.
    }
}
