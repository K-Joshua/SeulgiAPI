using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolEnrollmentApi.EnrollmentLibrary.Models
{
    public class Instructor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InstructorId { get; set; }

        [Required]
        [MaxLength(50)]
        public required string Name { get; set; }

        [Required]
        [MaxLength(12)]
        public required DateOnly BirthDate { get; set; }
        public void SetBirthDate(string birthDate)
        {
            BirthDate = DateOnly.Parse(birthDate);
        }

        [MaxLength(50)]
        public string? Email { get; set; }

        [MaxLength(50)]
        [Required]
        public required string Address { get; set; }

        [MaxLength(13)]
        [Required]
        public required string PhoneNumber { get; set; }


        [MaxLength(2)]
        [Required]
        public required int Age { get; set; }

        [MaxLength(6)]
        [Required]
        public required string Sex { get; set; }

        [MaxLength(50)]
        [Required]
        public required string ExternalPosition { get; set; }
        [Required]
        public required DateTime CreatedAt { get; set; }

        [Required]
        public required DateTime UpdatedAt { get; set; } = DateTime.Now;
        [Required]
        [MaxLength(100)]
        public required string CreatedBy { get; set; }
    }
}
