    using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Net;

namespace SchoolEnrollmentApi.EnrollmentLibrary.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }


        [MaxLength(200)]
        [Required(ErrorMessage = "Cannot Be Unknown")]
        public required string Name { get; set; }

        [MaxLength(12)]
        public required DateOnly BirthDate { get; set; }    

        [MaxLength(100)]
        [Required]
        public required string Address { get; set; }

        [MaxLength(100)]
        public string? Email { get; set; }

        [MaxLength(20)]
        [Required]
        public required string PhoneNumber { get; set; }

        [MaxLength(2)]
        public required int Age { get; set; }

        [MaxLength(6)]
        [Required]
        public required string Sex { get; set; }
        [Required]
        public required DateTime CreatedAt { get; set; }

        [Required]
        public required DateTime UpdatedAt { get; set; } = DateTime.Now;
        [Required]
        [MaxLength(100)]
        public required string CreatedBy { get; set; }
    }

}
