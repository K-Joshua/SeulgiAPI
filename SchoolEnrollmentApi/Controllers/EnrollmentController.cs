using Microsoft.AspNetCore.Mvc;
using SchoolEnrollmentApi.EnrollmentLibrary;
using SchoolEnrollmentApi.EnrollmentLibrary.DTOs;
using SchoolEnrollmentApi.EnrollmentLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace SchoolEnrollmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController(DatabaseEnrollment dbContext) : Controller
    {
        private readonly DatabaseEnrollment dbContext = dbContext;


        [HttpGet]
        public IActionResult GetEnrollments()
        {
            var enrollments = dbContext.Enrollment.ToList();
            if (enrollments == null || enrollments.Count == 0)
            {
                return NotFound("No enrollments found.");
            }
            return Ok(enrollments);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetEnrollmentById(int id)
        {
            var enrollment = dbContext.Enrollment.Find(id);
            if (enrollment == null)
            {
                return NotFound($"Enrollment with id {id} not found.");
            }
            return Ok(enrollment);
        }

        [HttpPost]
        public IActionResult PostEnrollment(AddEnrollmentDTOscs adddtos)
        {
            var addenrollment = new Enrollment()
            {
                StudentId = adddtos.StudentId,
                RequirementId = adddtos.RequirementId,
                StudentTypeId = adddtos.StudentTypeId,
                YearToEnroll = adddtos.YearToEnroll,
                CourseQuantity = adddtos.CourseQuantity,
                StudyLoadId = adddtos.StudyLoadId,
                ExamRecordId = adddtos.ExamRecordId,
                ScholarshipId = adddtos.ScholarshipId,
                ScholarshipQuantity = adddtos.ScholarshipQuantity,
                PaymentId = adddtos.PaymentId,
                TotalAmount = adddtos.TotalAmount,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                CreatedBy = User?.Identity?.Name ?? "Unknown",
                TaskStatusId = adddtos.TaskStatusId,
            };
            if (addenrollment.TotalAmount < 0 || addenrollment.ScholarshipQuantity < 0)
            {
                return BadRequest("No Negative");
            }
            var showresult = new GetEnrollmentDTOs
            {
                EnrollmentId = addenrollment.EnrollmentId,
                StudentId = addenrollment.StudentId,
                RequirementId = addenrollment.RequirementId,
                StudentTypeId = addenrollment.StudentTypeId,
                YearToEnroll = addenrollment.YearToEnroll,
                CourseQuantity = addenrollment.CourseQuantity,
                StudyLoadId = addenrollment.StudyLoadId,
                ExamRecordId = addenrollment.ExamRecordId,
                ScholarshipId = addenrollment.ScholarshipId,
                ScholarshipQuantity = addenrollment.ScholarshipQuantity,
                PaymentId = addenrollment.PaymentId,
                TotalAmount = addenrollment.TotalAmount,
                CreatedAt = addenrollment.CreatedAt,
                UpdatedAt = addenrollment.UpdatedAt,
                CreatedBy = addenrollment.CreatedBy,
                TaskStatusId = addenrollment.TaskStatusId
            };
            dbContext.Enrollment.Add(addenrollment);
            dbContext.SaveChanges();
            return Ok(showresult);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult PutEnrollment(int id, AddEnrollmentDTOscs edittenrollment)
        {
            var enrolledit = dbContext.Enrollment.Find(id);
            if (enrolledit == null)
            {
                return NotFound($"Id {id} Not Found");
            }
            enrolledit.StudentId = edittenrollment.StudentId;
            enrolledit.RequirementId = edittenrollment.RequirementId;
            enrolledit.StudentTypeId  = edittenrollment.StudentTypeId;
            enrolledit.YearToEnroll = edittenrollment.YearToEnroll;
            enrolledit.CourseQuantity = edittenrollment.CourseQuantity;
            enrolledit.StudyLoadId = edittenrollment.StudyLoadId;
            enrolledit.ExamRecordId = edittenrollment.ExamRecordId;
            enrolledit.ScholarshipId = edittenrollment.ScholarshipId;
            enrolledit.ScholarshipQuantity = edittenrollment.ScholarshipQuantity;
            enrolledit.PaymentId = edittenrollment.PaymentId;
            enrolledit.TotalAmount = edittenrollment.TotalAmount;
            enrolledit.TaskStatusId = edittenrollment.TaskStatusId;
            enrolledit.UpdatedAt = DateTime.Now;
            enrolledit.CreatedBy = User?.Identity?.Name ?? "Unknown";
            if (enrolledit.TotalAmount < 0 || enrolledit.ScholarshipQuantity < 0)
            {
                return BadRequest("No Negative");
            }
            dbContext.Entry(enrolledit).State = EntityState.Modified;
            dbContext.SaveChanges();
            var find = dbContext.Enrollment.Find(id);
            return Ok(find);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteEnrollment(int id)
        {
            var delete = dbContext.Enrollment.Find(id);
            if (delete == null)
            {
                return NotFound($"Id {id} Not Found");
            }
            dbContext.Enrollment.Remove(delete);
            dbContext.SaveChanges();
            return Ok();
        }
    }
}
