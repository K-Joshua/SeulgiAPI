using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SchoolEnrollmentApi.EnrollmentLibrary.DTOs
{
    public class AddPaymentDTOs
    {
        public required double PaymentTuition { get; set; }
        public required int SubjectAmountId { get; set; }
        public required int PaymentTypeId { get; set; } //    w/ Cash, Check, Gcash, etc.
        public required double EntranceFee { get; set; } //    w/ Entrance Fee
        public required bool IsPaidEntranceFee { get; set; }
        public required int TaskStatusId { get; set; } //    w/ Paid, Unpaid, etc.
    }

    public class GetPaymentDTOs
    {
        public required int PaymentId { get; set; }
        public required double PaymentTuition { get; set; }
        public required int SubjectsAmountId { get; set; }
        public required int PaymentTypeId { get; set; } //    w/ Cash, Check, Gcash, etc.
        public required double EntranceFee { get; set; } //    w/ Entrance Fee
        public required bool IsPaidEntranceFee { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required DateTime UpdatedAt { get; set; }
        public required int TaskStatusId { get; set; } //    w/ Paid, Unpaid, etc.
        public required string CreatedBy { get; set; }
    }

}
