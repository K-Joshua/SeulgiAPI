using Microsoft.AspNetCore.Mvc;
using SchoolEnrollmentApi.EnrollmentLibrary;
using Microsoft.EntityFrameworkCore;
using SchoolEnrollmentApi.EnrollmentLibrary.DTOs;
using SchoolEnrollmentApi.EnrollmentLibrary.Models;

namespace SchoolEnrollmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController(DatabaseEnrollment dbContext) : Controller
    {
        private readonly DatabaseEnrollment dbContext = dbContext;

        [HttpGet]
        public IActionResult GetSubjects()
        {
            var subjects = dbContext.Subject.ToList();
            if (subjects == null || subjects.Count == 0)
            {
                return NotFound("No subjects found.");
            }
            return Ok(subjects);
        }
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetSubjectById(int id)
        {
            var subject = dbContext.Subject.Find(id);
            if (subject == null)
            {
                return NotFound($"Subject with id {id} not found.");
            }
            return Ok(subject);
        }
        [HttpPost]
        public IActionResult PostSubject(AddSubjectDTOs adddtos)
        {
            var subject = new Subject()
            {
                Name = adddtos.Name,
                Description = adddtos.Description,
                Units = adddtos.Units,
                AvailabilityStatusId = adddtos.AvailabilityStatusId,
                Code = adddtos.Code,
                SubjectPayment = adddtos.SubjectPayment,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                CreatedBy = User?.Identity?.Name ?? "Unknown",
            };
            if (subject.Units < 0)
            {
                return BadRequest("No Negative");
            }
            dbContext.Subject.Add(subject);
            dbContext.SaveChanges();
            var showresult = new GetSubjectDTOs()
            {
                SubjectId = subject.SubjectId,
                Name = subject.Name,
                Description = subject.Description,
                Units = subject.Units,
                AvailabilityStatusId = subject.AvailabilityStatusId,
                Code = subject.Code,
                SubjectPayment = subject.SubjectPayment,
                CreatedAt = subject.CreatedAt,
                UpdatedAt = subject.UpdatedAt,
                CreatedBy = subject.CreatedBy,
            };
            return Ok(showresult);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult PutSubject(int id, AddSubjectDTOs adddtos)
        {
            var subject = dbContext.Subject.Find(id);
            if (subject == null)
            {
                return NotFound($"Subject with id {id} not found.");
            }
            subject.Name = adddtos.Name;
            subject.Description = adddtos.Description;
            subject.Units = adddtos.Units;
            subject.AvailabilityStatusId = adddtos.AvailabilityStatusId;
            subject.Code = adddtos.Code;
            subject.SubjectPayment = adddtos.SubjectPayment;
            subject.UpdatedAt = DateTime.Now;
            subject.CreatedBy = User?.Identity?.Name ?? "Unknown";
            dbContext.Entry(subject).State = EntityState.Modified;
            dbContext.SaveChanges();
            var find = dbContext.Subject.Find(id);
            return Ok(find);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public ActionResult DeleteSubject(int id)
        {
            var subject = dbContext.Subject.Find(id);
            if (subject == null)
            {
                return NotFound($"Subject with id {id} not found.");
            }
            dbContext.Subject.Remove(subject);
            dbContext.SaveChanges();
            return Ok($"Subject with id {id} deleted successfully.");
        }
    }
}