using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SchoolEnrollmentApi.EnrollmentLibrary.DTOs
{
    public class AddCourseDTOs
    {
        public required string CourseName { get; set; }
        public required int AvailabilityStatus { get; set; }
        public required string CourseDetail { get; set; }
    }

    public class GetCourseDTOs
    {
        public required int CourseId { get; set; }
        public required string CourseName { get; set; }
        public required int AvailabilityStatus { get; set; }
        public required string CourseDetail { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required DateTime UpdatedAt { get; set; }
        public required string CreatedBy { get; set; }
    }
}
