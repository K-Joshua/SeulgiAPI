namespace SchoolEnrollmentApi.EnrollmentLibrary.DTOs
{
    public class AddStudyLoadSubjectDTOs
    {
        public required int SubjectId { get; set; }
        public required int InstructorId { get; set; }
        public required string Day { get; set; } // Day of the week
        public required TimeOnly StartTime { get; set; }
        public required TimeOnly EndTime { get; set; }
        public required string Description { get; set; }
    }

    public class GetStudyLoadSubjectDTOs
    {
        public required int StudyLoadSubjectId { get; set; }
        public required int SubjectId { get; set; }
        public required int InstructorId { get; set; }
        public required string Day { get; set; } // Day of the week
        public required TimeOnly StartTime { get; set; }
        public required TimeOnly EndTime { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required DateTime UpdatedAt { get; set; }
        public required string Description { get; set; }
        public required string CreatedBy { get; set; }
    }
}
