    using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Net;

namespace SchoolEnrollmentApi.EnrollmentLibrary.Models
{
    public class Student // Student Model Table
    {
        [Key]   // Primary Key Attribute tells that the property is Primary Key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto Increment
        public int StudentId { get; set; } // Primary Key Id


        [MaxLength(200)]   // Max String Length 200
        [Required(ErrorMessage = "Cannot Be Unknown")] // Required Attribute tells that the property is required where else Error
        public required string Name { get; set; } // Name of the Student

        [MaxLength(12)] // Max String Length 12
        public required DateOnly BirthDate { get; set; } // Date of Birth

        [MaxLength(100)] // Max String Length 100
        [Required] // Required Attribute tells the computer that inputting the data is required
        public required string Address { get; set; } // Address of the Student required in object

        [MaxLength(100)] // Max String Length 100
        public string? Email { get; set; } // Email of the Student that allows null

        [MaxLength(20)] // Max String Length 20
        [Required] // Required Attribute tells the computer that inputting the data is required 
        public required string PhoneNumber { get; set; } // Phone Number of the Student required in object

        [MaxLength(2)] // Max String Length 2
        public required int Age { get; set; } // Age of the Student required in object

        [MaxLength(6)] // Max String Length 6
        [Required]// Required Attribute tells the computer that inputting the data is required
        public required string Sex { get; set; } // Sex of the student required in object 
        [Required] // Required Attribute tells the computer that inputting the data is required
        public required DateTime CreatedAt { get; set; } // Created At Date of the Student required in object

        [Required] // Required Attribute tells the computer that inputting the data is required
        public required DateTime UpdatedAt { get; set; } = DateTime.Now; // Shows when it is updated required in object
        [Required] // Required Attribute tells the computer that inputting the data is required
        [MaxLength(100)] // Max String Length 100
        public required string CreatedBy { get; set; } // Created By of the Student required in object
    }

}
