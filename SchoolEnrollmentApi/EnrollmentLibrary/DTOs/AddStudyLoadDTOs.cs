using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SchoolEnrollmentApi.EnrollmentLibrary.DTOs
{
    public class AddStudyLoadDTOs
    {
        public required int PaymentId { get; set; }
        public required int StudyLoadSubjectId { get; set; }
        public required double TotalUnits { get; set; }
    }

    public class GetStudyLoadDTOs
    {
        public required int StudyLoadId { get; set; }
        public required int StudyLoadSubjectId { get; set; }
        public required int PaymentId { get; set; }
        public required double TotalUnits { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required DateTime UpdatedAt { get; set; } = DateTime.Now;
        public required string CreatedBy { get; set; }
    }
}
