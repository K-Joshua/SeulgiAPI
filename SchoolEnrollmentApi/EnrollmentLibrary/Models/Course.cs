using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolEnrollmentApi.EnrollmentLibrary.Models
{
    public class Course
    {
        [Key]
        [Required]
        public int CourseId { get; set; }


        [MaxLength(200)]
        [Required]
        public required string CourseName { get; set; }


        [MaxLength(50)]
        [Required]
        [ForeignKey("AvailabilityStatus")]
        public required int AvailabilityStatus { get; set; }


        [MaxLength(50)]
        [Required]
        public required string CourseDetail { get; set; }

        [Required]
        public required DateTime CreatedAt { get; set; }

        [Required]
        public required DateTime UpdatedAt { get; set; } = DateTime.Now;
        [Required]
        [MaxLength(100)]
        public required string CreatedBy { get; set; }
    }
}
