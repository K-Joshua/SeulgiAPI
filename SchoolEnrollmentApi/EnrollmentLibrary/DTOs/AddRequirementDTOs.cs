using System.ComponentModel.DataAnnotations;

namespace SchoolEnrollmentApi.EnrollmentLibrary.DTOs
{
    public class AddRequirementDTOs
    {
        public required string PSA { get; set; }
        public required bool IsGood { get; set; } //    w/ Good Moral
        public required string LastSchoolGrade { get; set; }
        public required string Form137 { get; set; }
    }
    public class GetRequirementDTOs
    {
        public required int RequirementId { get; set; }
        public required string PSA { get; set; }
        public required bool IsGood { get; set; } //    w/ Good Moral
        public required string LastSchoolGrade { get; set; }
        public required string Form137 { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required DateTime UpdatedAt { get; set; }
        public required string CreatedBy { get; set; }
    }
}
