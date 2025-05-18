using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolEnrollmentApi.EnrollmentLibrary.Models
{
    public class StudentType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentTypeId { get; set; }

        [MaxLength(50)]
        public required string Type { get; set; }

        public required bool IsRegestered { get; set; }
        [Required]
        public required DateTime CreatedAt { get; set; }

        [Required]
        public required DateTime UpdatedAt { get; set; } = DateTime.Now;
        [Required]
        [MaxLength(100)]
        public required string CreatedBy { get; set; }
    }
}
