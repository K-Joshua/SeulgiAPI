using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolEnrollmentApi.EnrollmentLibrary.DTOs;
using SchoolEnrollmentApi.EnrollmentLibrary.Models;
using SchoolEnrollmentApi.EnrollmentLibrary;

namespace SchoolEnrollmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectAmountController(DatabaseEnrollment dbContext) : Controller
    {
        private readonly DatabaseEnrollment dbContext = dbContext;

        [HttpGet]
        public IActionResult GetSubjecstAmounts()
        {
            var subjectAmount = dbContext.SubjectsAmount.ToList();
            if (subjectAmount == null)
            {
                return NotFound("No subject amount found.");
            }
            return Ok(subjectAmount);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetSubjectAmountById(int id)
        {
            var subjectAmount = dbContext.SubjectsAmount.Find(id);
            if (subjectAmount == null)
            {
                return NotFound($"Subject amount with id {id} not found.");
            }
            return Ok(subjectAmount);
        }

        [HttpPost]
        public IActionResult PostSubjectAmount(AddSubjectsAmountDTOs adddtos)
        {
            var subjectAmount = new SubjectsAmount()
            {
                StudyLoadSubjectId = adddtos.StudyLoadSubjectId,
                SubjectsTotalAmount = adddtos.SubjectsTotalAmount,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                CreatedBy = User?.Identity?.Name ?? "Unknown",
            };
            dbContext.SubjectsAmount.Add(subjectAmount);
            dbContext.SaveChanges();
            var showresult = new GetSubjectsAmountDTOs()
            {
                SubjectAmountId = subjectAmount.SubjectAmountId,
                StudyLoadSubjectId = subjectAmount.StudyLoadSubjectId,
                SubjectsTotalAmount = subjectAmount.SubjectsTotalAmount,
                CreatedAt = subjectAmount.CreatedAt,
                UpdatedAt = subjectAmount.UpdatedAt,
                CreatedBy = subjectAmount.CreatedBy,
            };
            return Ok(showresult);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult PutSubjectAmount(int id, AddSubjectsAmountDTOs editdtos)
        {
            var subjectAmount = dbContext.SubjectsAmount.Find(id);
            if (subjectAmount == null)
            {
                return NotFound($"Subject amount with id {id} not found.");
            }
            subjectAmount.StudyLoadSubjectId = editdtos.StudyLoadSubjectId;
            subjectAmount.SubjectsTotalAmount = editdtos.SubjectsTotalAmount;
            subjectAmount.UpdatedAt = DateTime.Now;
            subjectAmount.CreatedBy = User?.Identity?.Name ?? "Unknown";
            dbContext.Entry(subjectAmount).State = EntityState.Modified;
            dbContext.SaveChanges();
            var find = dbContext.SubjectsAmount.Find(id);
            return Ok(find);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteSubjectAmount(int id)
        {
            var subjectAmount = dbContext.SubjectsAmount.Find(id);
            if (subjectAmount == null)
            {
                return NotFound($"Subject amount with id {id} not found.");
            }
            dbContext.SubjectsAmount.Remove(subjectAmount);
            dbContext.SaveChanges();
            return Ok("Deleted Successfully");

        }
    }
}
