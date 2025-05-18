using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolEnrollmentApi.EnrollmentLibrary.Models
{
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentId { get; set; }

        [MaxLength(10)]
        [Required]
        public required double PaymentTuition { get; set; }

        [ForeignKey("SubjectsAmount")]
        public required int SubjectsAmountId { get; set; } //    w/ Total Subject Amount

        [ForeignKey("PaymentType")]
        public required int PaymentTypeId { get; set; } //    w/ Cash, Check, Gcash, etc.

        [MaxLength(10)]
        [Required]
        public required double EntranceFee { get; set; } //    w/ Entrance Fee

        [Required]
        public required bool IsPaidEntranceFee { get; set; }

        [Required]
        public required DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        [Required]
        [ForeignKey("TaskStatus")]
        public required int TaskStatusId { get; set; } //    w/ Paid, Unpaid, etc.
        [Required]
        [MaxLength(100)]
        public required string CreatedBy { get; set; }
    }


    public class PaymentType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentTypeId { get; set; }
        [MaxLength(50)]
        [Required]
        public required string Type { get; set; } //    w/ Cash, Check, Gcash, etc.
        [Required]
        public required DateTime CreatedAt { get; set; }

        [Required]
        public required DateTime UpdatedAt { get; set; } 
        [Required]
        [MaxLength(100)]
        public required string CreatedBy { get; set; }
    }
}
