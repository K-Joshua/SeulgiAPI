using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SchoolEnrollmentApi.EnrollmentLibrary.DTOs
{
    public class AddSubjectsAmountDTOs
    {
        public required int StudyLoadSubjectId { get; set; }
        public required double SubjectsTotalAmount { get; set; }
    }

    public class GetSubjectsAmountDTOs
    {
        public int SubjectAmountId { get; set; }
        public required int StudyLoadSubjectId { get; set; }
        public required double SubjectsTotalAmount { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required DateTime UpdatedAt { get; set; }
        public required string CreatedBy { get; set; }
    }
}
