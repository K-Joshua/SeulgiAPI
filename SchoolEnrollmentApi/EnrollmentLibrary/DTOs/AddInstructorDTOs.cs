using System.ComponentModel.DataAnnotations;

namespace SchoolEnrollmentApi.EnrollmentLibrary.DTOs
{
    public class AddInstructorDTOs
    {
        public required string Name { get; set; }
        public required DateOnly BirthDate { get; set; }
        public string? Email { get; set; }
        public required string Address { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Sex { get; set; }
        public required string ExternalPosition { get; set; }
    }

    public class GetInstructorDTOs
    {
        public required int InstructorId { get; set; }
        public required string Name { get; set; }
        public required DateOnly BirthDate { get; set; }
        public string? Email { get; set; }
        public required string Address { get; set; }
        public required string PhoneNumber { get; set; }
        public required int Age { get; set; }
        public required string Sex { get; set; }
        public required string ExternalPosition { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required DateTime UpdatedAt { get; set; }
        public required string CreatedBy { get; set; }
    }
}
