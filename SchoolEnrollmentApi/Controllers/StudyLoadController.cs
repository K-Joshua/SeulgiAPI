using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolEnrollmentApi.EnrollmentLibrary.DTOs;
using SchoolEnrollmentApi.EnrollmentLibrary.Models;
using SchoolEnrollmentApi.EnrollmentLibrary;

namespace SchoolEnrollmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudyLoadController(DatabaseEnrollment dbContext) : Controller
    {
        private readonly DatabaseEnrollment dbContext = dbContext;

        [HttpGet]
        public IActionResult GetStudyLoads()
        {
            var studyLoad = dbContext.StudyLoad.ToList();
            if (studyLoad == null || studyLoad.Count == 0)
            {
                return NotFound("No study load found.");
            }
            return Ok(studyLoad);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetStudyLoadById(int id)
        {
            var studyLoad = dbContext.StudyLoad.Find(id);
            if (studyLoad == null)
            {
                return NotFound($"Study load with id {id} not found.");
            }
            return Ok(studyLoad);
        }

        [HttpPost]
        public IActionResult PostStudyLoad(AddStudyLoadDTOs adddtos)
        {
            var studyLoad = new StudyLoad()
            {
                StudyLoadSubjectId = adddtos.StudyLoadSubjectId,
                PaymentId = adddtos.PaymentId,
                TotalUnits = adddtos.TotalUnits,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                CreatedBy = User?.Identity?.Name ?? "Unknown",
            };
            dbContext.StudyLoad.Add(studyLoad);
            dbContext.SaveChanges();
            var showresult = new GetStudyLoadDTOs()
            {
                StudyLoadId = studyLoad.StudyLoadId,
                StudyLoadSubjectId = studyLoad.StudyLoadSubjectId,
                PaymentId = studyLoad.PaymentId,
                TotalUnits = studyLoad.TotalUnits,
                CreatedAt = studyLoad.CreatedAt,
                UpdatedAt = studyLoad.UpdatedAt,
                CreatedBy = studyLoad.CreatedBy,
            };
            return Ok(showresult);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult PutStudyLoad(int id, AddStudyLoadDTOs adddtos)
        {
            var studyLoad = dbContext.StudyLoad.Find(id);
            if (studyLoad == null)
            {
                return NotFound($"Study load with id {id} not found.");
            }
            studyLoad.StudyLoadSubjectId = adddtos.StudyLoadSubjectId;
            studyLoad.PaymentId = adddtos.PaymentId;
            studyLoad.TotalUnits = adddtos.TotalUnits;
            studyLoad.UpdatedAt = DateTime.Now;
            studyLoad.CreatedBy = User?.Identity?.Name ?? "Unknown";    
            dbContext.Entry(studyLoad).State = EntityState.Modified;
            dbContext.SaveChanges();
            var find = dbContext.StudyLoad.Find(id);
            return Ok(find);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteStudyLoad(int id)
        {
            var studyLoad = dbContext.StudyLoad.Find(id);
            if (studyLoad == null)
            {
                return NotFound($"Study load with id {id} not found.");
            }
            dbContext.StudyLoad.Remove(studyLoad);
            dbContext.SaveChanges();
            return Ok($"Study load with id {id} deleted successfully.");
        }
    }
}
