using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolEnrollmentApi.EnrollmentLibrary.Models
{
    public class Subject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubjectId { get; set; }  


        [Required]
        [MaxLength(50)]
        public required string Name { get; set; }

        [Required]
        public required double SubjectPayment { get; set; } //    Subject Amount

        [Required]
        [MaxLength(20)]
        public required string Code { get; set; }

        [Required]
        [MaxLength(1)]
        public required int Units { get; set; }


        [Required]
        [ForeignKey("AvailabilityStatus")]
        public required int AvailabilityStatusId { get; set; }

        [Required]
        [MaxLength(100)]
        public required string Description { get; set; }
        [Required]
        public required DateTime CreatedAt { get; set; }

        [Required]
        public required DateTime UpdatedAt { get; set; } = DateTime.Now;
        [Required]
        public required string CreatedBy { get; set; }
    }
}
