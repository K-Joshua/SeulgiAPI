namespace SchoolEnrollmentApi.EnrollmentLibrary.DTOs
{
    public class AddPaymentTypeDTOs
    {
        public required string Type { get; set; } //    w/ Cash, Check, Gcash, etc.
    }

    public class GetPaymentTypeDTOs
    {
        public required int PaymentTypeId { get; set; }
        public required string Type { get; set; } //    w/ Cash, Check, Gcash, etc.
        public required DateTime CreatedAt { get; set; }
        public required DateTime UpdatedAt { get; set; }
        public required string CreatedBy { get; set; }
    }
}
