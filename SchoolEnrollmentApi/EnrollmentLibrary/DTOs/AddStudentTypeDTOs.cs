using System.ComponentModel.DataAnnotations;

namespace SchoolEnrollmentApi.EnrollmentLibrary.DTOs
{
    public class AddStudentTypeDTOs
    {
        public required string Type { get; set; }
        public required bool IsRegestered { get; set; }
    }
    public class GetStudentTypeDTOs
    {
        public int StudentTypeId { get; set; }
        public required string Type { get; set; }
        public required bool IsRegestered { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required DateTime UpdatedAt { get; set; } = DateTime.Now;
        public required string CreatedBy { get; set; }
    }
}
