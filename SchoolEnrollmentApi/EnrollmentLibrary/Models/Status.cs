using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolEnrollmentApi.EnrollmentLibrary.Models
{
    public class TStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskStatusId { get; set; }


        [MaxLength(50)]
        public required string Status { get; set; }
        [Required]
        public required DateTime CreatedAt { get; set; }

        [Required]
        public required DateTime UpdatedAt { get; set; } = DateTime.Now;
        [Required]
        [MaxLength(100)]
        public required string CreatedBy { get; set; }
    }

    public class AvailabilityStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AvailabilityStatusId { get; set; }


        [MaxLength(50)]
        public required string Status { get; set; }
        [Required]
        public required DateTime CreatedAt { get; set; }

        [Required]
        public required DateTime UpdatedAt { get; set; } = DateTime.Now;
        [Required]
        [MaxLength(100)]
        public required string CreatedBy { get; set; }
    }
}
