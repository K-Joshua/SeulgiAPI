namespace SchoolEnrollmentApi.EnrollmentLibrary.DTOs
{
    public class AddAvailabilityStatusDTOs
    {
        public required string Status { get; set; }
    }

    public class GetAvailabilityStatusDTOs
    {
        public required int AvailabilityStatusId { get; set; }
        public required string Status { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required DateTime UpdatedAt { get; set; }
        public required string CreatedBy { get; set; }
    }
}