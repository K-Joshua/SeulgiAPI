using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SchoolEnrollmentApi.EnrollmentLibrary.DTOs
{
    public class AddEnrollmentDTOscs
    {
        public required int StudentId { get; set; }
        public required int RequirementId { get; set; }
        public required int StudentTypeId { get; set; }
        public required DateOnly YearToEnroll { get; set; }
        public int CourseQuantity { get; set; } = 1;
        public required int StudyLoadId { get; set; }
        public required int ExamRecordId { get; set; }
        public required int ScholarshipId { get; set; }
        public required int ScholarshipQuantity { get; set; } = 0;
        public required int PaymentId { get; set; }
        public required double TotalAmount { get; set; } = 0.0;
        public required int TaskStatusId { get; set; } //    w/ Paid, Unpaid, etc
    }

    public class GetEnrollmentDTOs
    {
        public required int EnrollmentId { get; set; }
        public required int StudentId { get; set; }
        public required int RequirementId { get; set; }
        public required int StudentTypeId { get; set; }
        public required DateOnly YearToEnroll { get; set; }
        public int CourseQuantity { get; set; } = 1;
        public required int StudyLoadId { get; set; }
        public required int ExamRecordId { get; set; }
        public required int ScholarshipId { get; set; }
        public required int ScholarshipQuantity { get; set; } = 0;
        public required int PaymentId { get; set; }
        public required double TotalAmount { get; set; } = 0.0;
        public required DateTime CreatedAt { get; set; }
        public required DateTime UpdatedAt { get; set; } = DateTime.Now;
        public required int TaskStatusId { get; set; } //    w/ Paid, Unpaid, etc
        public required string CreatedBy { get; set; }
    }
}
