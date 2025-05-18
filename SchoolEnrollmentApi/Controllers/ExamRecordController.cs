using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using SchoolEnrollmentApi.EnrollmentLibrary.DTOs;
using SchoolEnrollmentApi.EnrollmentLibrary.Models;
using SchoolEnrollmentApi.EnrollmentLibrary;

namespace SchoolEnrollmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamRecordController (DatabaseEnrollment dbContext): Controller
    {
        private readonly DatabaseEnrollment dbContext = dbContext;

        [HttpGet]
        public IActionResult GetExamRecords()
        {
            var examRecords = dbContext.ExamRecord.ToList();
            if (examRecords == null || examRecords.Count == 0)
            {
                return NotFound("No exam records found.");
            }
            return Ok(examRecords);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetExamRecordById(int id)
        {
            var examRecord = dbContext.ExamRecord.Find(id);
            if (examRecord == null)
            {
                return NotFound($"Exam record with id {id} not found.");
            }
            return Ok(examRecord);
        }


        [HttpPost]
        public IActionResult PostExamRecord(AddExamRecordDTOs adddtos)
        {
            var examRecord = new ExamRecord()
            {
                ExamDate = adddtos.ExamDate,
                ExamTopic = adddtos.ExamTopic,
                Marks = adddtos.Marks,
                MarkRequested = adddtos.MarkRequested,
                IsPassed = adddtos.MarkRequested <= adddtos.Marks,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                CreatedBy = User?.Identity?.Name ?? "Unknown",
            };
            if (examRecord.Marks < 0 || examRecord.MarkRequested < 0)
            {
                return BadRequest("No Negative");
            }
            dbContext.ExamRecord.Add(examRecord);
            dbContext.SaveChanges();
            var showresult = new GetExamRecordDTOs()
            {
                ExamRecordId = examRecord.ExamRecordId,
                ExamDate = examRecord.ExamDate,
                ExamTopic = examRecord.ExamTopic,
                Marks = examRecord.MarkRequested,
                MarkRequested = examRecord.MarkRequested,
                IsPassed = examRecord.IsPassed,
                CreatedAt = examRecord.CreatedAt,
                UpdatedAt = examRecord.UpdatedAt,
                CreatedBy = examRecord.CreatedBy,
            };
            return Ok(showresult);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult PutExamRecord(int id, AddExamRecordDTOs adddtos)
        {
            var examRecord = dbContext.ExamRecord.Find(id);
            if (examRecord == null)
            {
                return NotFound($"Exam record with id {id} not found.");
            }
            examRecord.ExamDate = adddtos.ExamDate;
            examRecord.ExamTopic = adddtos.ExamTopic;
            examRecord.Marks = adddtos.Marks;
            examRecord.MarkRequested = adddtos.MarkRequested;
            examRecord.IsPassed = adddtos.Marks >= adddtos.MarkRequested;
            examRecord.UpdatedAt = DateTime.Now;
            examRecord.CreatedBy = User?.Identity?.Name ?? "Unknown";
            dbContext.Entry(examRecord).State = EntityState.Modified;
            dbContext.SaveChanges();
            var find = dbContext.ExamRecord.Find(id);
            return Ok(find);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteExamRecord(int id)
        {
            var examRecord = dbContext.ExamRecord.Find(id);
            if (examRecord == null)
            {
                return NotFound($"Exam record with id {id} not found.");
            }
            dbContext.ExamRecord.Remove(examRecord);
            dbContext.SaveChanges();
            return Ok($"Exam record with id {id} deleted successfully.");
        }
    }
}
