using System.ComponentModel.DataAnnotations;

namespace SchoolEnrollmentApi.EnrollmentLibrary.DTOs
{
    public class AddExamRecordDTOs
    {
        public required string ExamTopic { get; set; }
        public required DateOnly ExamDate { get; set; }
        public required int Marks { get; set; }
        public required int MarkRequested { get; set; }
    }

    public class GetExamRecordDTOs
    {
        public required int ExamRecordId { get; set; }
        public required string ExamTopic { get; set; }
        public required DateOnly ExamDate { get; set; }
        public required int Marks { get; set; }
        public required int MarkRequested { get; set; }
        public required bool IsPassed { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required DateTime UpdatedAt { get; set; }
        public required string CreatedBy { get; set; }
    }
}
