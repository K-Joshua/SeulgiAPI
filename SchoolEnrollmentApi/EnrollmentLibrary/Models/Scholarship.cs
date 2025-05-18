using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolEnrollmentApi.EnrollmentLibrary.Models
{
    public class Scholarship
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ScholarshipId { get; set; }

        [MaxLength(50)]
        [Required]
        public required string Name { get; set; }

        [MaxLength(10)]
        [Required]
        public required double Amount { get; set; }

        [MaxLength(12)]
        [Required]
        public required DateOnly Period { get; set; }

        public void SetPeriod(string period)
        {
            Period = DateOnly.Parse(period);
        }

        [MaxLength(100)]
        public required string Type { get; set; }


        [Required]
        public required DateTime CreatedAt { get; set; }

        [Required]
        public required DateTime UpdatedAt { get; set; } = DateTime.Now;

        [Required]
        [MaxLength(100)]
        public required string CreatedBy { get; set; }

    }
}
