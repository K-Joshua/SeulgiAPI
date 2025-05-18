namespace SchoolEnrollmentApi.EnrollmentLibrary.DTOs
{
    public class AddStudentDTOs
    {
        public required string Name { get; set; }
        public required DateOnly BirthDate { get; set; }
        public required string Address { get; set; }
        public string? Email { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Sex { get; set; }
    }

    public class GetStudentDTOs
    {
        public required int StudentId { get; set; }
        public required string Name { get; set; }
        public required DateOnly BirthDate { get; set; }
        public required string Address { get; set; }
        public string? Email { get; set; }
        public required string PhoneNumber { get; set; }
        public required int Age { get; set; }
        public required string Sex { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required DateTime UpdatedAt { get; set; }
        public required string CreatedBy { get; set; }
    }
}
