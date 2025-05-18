using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolEnrollmentApi.EnrollmentLibrary.Models
{
    public class StudyLoad
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudyLoadId { get; set; }

        [Required]
        [ForeignKey("StudyLoadSubject")]
        public required int StudyLoadSubjectId { get; set; }

        [Required]
        [ForeignKey("Payment")]
        public required int PaymentId { get; set; }

        [Required]
        public required double TotalUnits { get; set; }

        [Required]
        public required DateTime CreatedAt { get; set; }

        [Required]
        public required DateTime UpdatedAt { get; set; } = DateTime.Now;
        [Required]
        [MaxLength(100)]
        public required string CreatedBy { get; set; }
    }

    //Remove Model
    //Fix Controller
    //Add Foreign DTOs
    //Add select linq foreign
    //add table to table for every controller 
}
