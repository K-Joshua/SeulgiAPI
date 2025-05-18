using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SchoolEnrollmentApi.EnrollmentLibrary.DTOs
{
    public class AddSubjectDTOs
    {
        public required string Name { get; set; }
        public required string Code { get; set; }
        public required int Units { get; set; }
        public required int AvailabilityStatusId { get; set; }
        public required string Description { get; set; }
        public required double SubjectPayment { get; set; } //    Subject Amount
    }

    public class GetSubjectDTOs
    {
        public required int SubjectId { get; set; }
        public required string Name { get; set; }
        public required string Code { get; set; }
        public required int Units { get; set; }
        public required int AvailabilityStatusId { get; set; }
        public required string Description { get; set; }
        public required double SubjectPayment { get; set; } //    Subject Amount
        public required DateTime CreatedAt { get; set; }
        public required DateTime UpdatedAt { get; set; }
        public required string CreatedBy { get; set; }
    }
}
