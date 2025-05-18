using System.ComponentModel.DataAnnotations;

namespace SchoolEnrollmentApi.EnrollmentLibrary.DTOs
{
    public class AddScholarshipDTOs
    {
        public required string Name { get; set; }

        public required double Amount { get; set; }

        public required DateOnly Period { get; set; }

        public required string Type { get; set; }
    }

    public class GetScholarshipDTOs
    {
        public required int ScholarshipId { get; set; }
        public required string Name { get; set; }

        public required double Amount { get; set; }

        public required DateOnly Period { get; set; }

        public required string Type { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required DateTime UpdatedAt { get; set; }
        public required string CreatedBy { get; set; }
    }
}
