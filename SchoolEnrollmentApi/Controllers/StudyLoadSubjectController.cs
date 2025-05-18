using Microsoft.AspNetCore.Mvc;
using SchoolEnrollmentApi.EnrollmentLibrary;
using SchoolEnrollmentApi.EnrollmentLibrary.DTOs;
using SchoolEnrollmentApi.EnrollmentLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace SchoolEnrollmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudyLoadSubjectController(DatabaseEnrollment dbContext) : Controller
    {
        private readonly DatabaseEnrollment dbContext = dbContext;

        [HttpGet]
        public IActionResult GetStudyLoadSubjects()
        {
            var studyLoadSubjects = dbContext.StudyLoadSubject.ToList();
            if (studyLoadSubjects == null || studyLoadSubjects.Count == 0)
            {
                return NotFound("No study load subjects found.");
            }
            return Ok(studyLoadSubjects);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetStudyLoadSubjectById(int id)
        {
            var studyLoadSubject = dbContext.StudyLoadSubject.Find(id);
            if (studyLoadSubject == null)
            {
                return NotFound($"Study load subject with id {id} not found.");
            }
            return Ok(studyLoadSubject);
        }

        [HttpPost]
        public IActionResult PostStudyLoadSubject(AddStudyLoadSubjectDTOs adddtos)
        {
            var studyLoadSubject = new StudyLoadSubject()
            {
                SubjectId = adddtos.SubjectId,
                InstructorId = adddtos.InstructorId,
                Day = adddtos.Day,
                StartTime = adddtos.StartTime,
                EndTime = adddtos.EndTime,
                Description = adddtos.Description,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                CreatedBy = User?.Identity?.Name ?? "Unknown",
            };
            dbContext.StudyLoadSubject.Add(studyLoadSubject);
            dbContext.SaveChanges();
            var showresult = new GetStudyLoadSubjectDTOs()
            {
                StudyLoadSubjectId = studyLoadSubject.StudyLoadSubjectId,
                SubjectId = studyLoadSubject.SubjectId,
                InstructorId = studyLoadSubject.InstructorId,
                Day = studyLoadSubject.Day,
                StartTime = studyLoadSubject.StartTime,
                EndTime = studyLoadSubject.EndTime,
                Description = studyLoadSubject.Description,
                CreatedAt = studyLoadSubject.CreatedAt,
                UpdatedAt = studyLoadSubject.UpdatedAt,
                CreatedBy = studyLoadSubject.CreatedBy,
            };
            return Ok(showresult);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult PutStudyLoadSubject(int id, AddStudyLoadSubjectDTOs editdtos)
        {
            var studyLoadSubject = dbContext.StudyLoadSubject.Find(id);
            if (studyLoadSubject == null)
            {
                return NotFound($"Study load subject with id {id} not found.");
            }
            studyLoadSubject.SubjectId = editdtos.SubjectId;
            studyLoadSubject.InstructorId = editdtos.InstructorId;
            studyLoadSubject.Day = editdtos.Day;
            studyLoadSubject.StartTime = editdtos.StartTime;
            studyLoadSubject.EndTime = editdtos.EndTime;
            studyLoadSubject.Description = editdtos.Description;
            studyLoadSubject.UpdatedAt = DateTime.Now;
            dbContext.Entry(studyLoadSubject).State = EntityState.Modified;
            dbContext.SaveChanges();
            var find = dbContext.StudyLoadSubject.Find(id);
            return Ok(find);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteStudyLoadSubject(int id)
        {
            var studyLoadSubject = dbContext.StudyLoadSubject.Find(id);
            if (studyLoadSubject == null)
            {
                return NotFound($"Study load subject with id {id} not found.");
            }
            dbContext.StudyLoadSubject.Remove(studyLoadSubject);
            dbContext.SaveChanges();
            return Ok($"Study load subject with id {id} deleted successfully.");
        }

        /*
    }
          public class StudyLoad
{
    public int StudyLoadId { get; set; }

    // Navigation property
    public ICollection<StudyLoadSubject> StudyLoadSubjects { get; set; }
}

public class Subject
{
    public int SubjectId { get; set; }

    // Navigation property
    public ICollection<StudyLoadSubject> StudyLoadSubjects { get; set; }
}

public class StudyLoadSubject
{
    public int StudyLoadId { get; set; }
    public StudyLoad StudyLoad { get; set; }

    public int SubjectId { get; set; }
    public Subject Subject { get; set; }

    // Optional: additional properties
    public string Day { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
}

          
         */
    }
}
