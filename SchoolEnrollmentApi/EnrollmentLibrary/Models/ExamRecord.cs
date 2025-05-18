using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolEnrollmentApi.EnrollmentLibrary.Models
{
    public class ExamRecord
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExamRecordId { get; set; }


        [MaxLength(50)]
        [Required]
        public required string ExamTopic { get; set; }


        [MaxLength(12)]
        [Required]
        public required DateOnly ExamDate { get; set; }
        public void SetExamDate(string examDate)
        {
            ExamDate = DateOnly.Parse(examDate);
        }


        [MaxLength(3)]
        [Required]
        public required int Marks { get; set; }


        [Required]
        [MaxLength(3)]
        public required int MarkRequested { get; set; }

        [Required]
        public bool IsPassed { get; set; }
        [Required]
        public required DateTime CreatedAt { get; set; }

        [Required]
        public required DateTime UpdatedAt { get; set; } = DateTime.Now;
        [Required]
        [MaxLength(100)]
        public required string CreatedBy { get; set; }
    }
}
