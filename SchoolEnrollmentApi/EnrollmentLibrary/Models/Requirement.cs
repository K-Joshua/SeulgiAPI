using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolEnrollmentApi.EnrollmentLibrary.Models
{
    public class Requirement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RequirementId { get; set; }


        [MaxLength(50)]
        [Required]
        public required string PSA { get; set; }


        [MaxLength(50)]
        [Required]
        public required bool IsGood { get; set; } //    w/ Good Moral


        [MaxLength(3)]
        [Required]
        public required string LastSchoolGrade { get; set; }

        [Required]
        public required string Form137 { get; set; }
        [Required]
        public required DateTime CreatedAt { get; set; }

        [Required]
        public required DateTime UpdatedAt { get; set; } = DateTime.Now;
        [Required]
        [MaxLength(100)]
        public required string CreatedBy { get; set; }

    }
}
