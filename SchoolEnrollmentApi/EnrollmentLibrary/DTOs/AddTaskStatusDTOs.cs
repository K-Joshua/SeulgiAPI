using System.ComponentModel.DataAnnotations;

namespace SchoolEnrollmentApi.EnrollmentLibrary.DTOs
{
    public class AddTaskStatusDTOs
    {
        public required string Status { get; set; }
    }   

    public class GetTaskStatusDTOs
    {
        public required int TaskStatusId { get; set; }
        public required string Status { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required DateTime UpdatedAt { get; set; }
        public required string CreatedBy { get; set; }
    }
}
