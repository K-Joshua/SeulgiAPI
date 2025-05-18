using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.FileProviders;
using SchoolEnrollmentApi.EnrollmentLibrary;
using SchoolEnrollmentApi.EnrollmentLibrary.DTOs;
using SchoolEnrollmentApi.EnrollmentLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace SchoolEnrollmentApi.Controllers
{
    //localhost:xxxx/api/Requirement
    [Route("api/[controller]")]
    [ApiController]
    public class RequirementController(DatabaseEnrollment dbContext) : Controller
    {
        private readonly DatabaseEnrollment dbContext = dbContext;


        [HttpGet]
        public IActionResult GetRequirements()
        {
            var requirements = dbContext.Requirement.ToList();
            if (requirements == null || requirements.Count == 0)
            {
                return NotFound("No requirements found.");
            }
            return Ok(requirements);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetRequirementById(int id)
        {
            var requirement = dbContext.Requirement.Find(id);
            if (requirement == null)
            {
                return NotFound($"Requirement with id {id} not found.");
            }
            return Ok(requirement);
        }

        [HttpPost]
        public IActionResult PostRequirement(AddRequirementDTOs adddtos)
        {
            var requirement = new Requirement()
            {
                Form137 = adddtos.Form137,
                IsGood = adddtos.IsGood,
                LastSchoolGrade = adddtos.LastSchoolGrade,
                PSA = adddtos.PSA,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                CreatedBy = User?.Identity?.Name ?? "Unknown",
            };
            dbContext.Requirement.Add(requirement);
            dbContext.SaveChanges();
            var showreturn = new GetRequirementDTOs()
            {
                RequirementId = requirement.RequirementId,
                Form137 = requirement.Form137,
                IsGood = requirement.IsGood,
                LastSchoolGrade = requirement.LastSchoolGrade,
                PSA = requirement.PSA,
                CreatedAt = requirement.CreatedAt,
                UpdatedAt = requirement.UpdatedAt,
                CreatedBy = requirement.CreatedBy
            };
            return Ok(showreturn);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult PutRequirement(int id, AddRequirementDTOs adddtos)
        {
            var requirement = dbContext.Requirement.Find(id);
            if (requirement == null)
            {
                return NotFound($"Requirement With {id} Is Not Found");
            }
            requirement.Form137 = adddtos.Form137;
            requirement.IsGood = adddtos.IsGood;
            requirement.LastSchoolGrade = adddtos.LastSchoolGrade;
            requirement.PSA = adddtos.PSA;
            requirement.UpdatedAt = DateTime.Now;
            requirement.CreatedBy = User?.Identity?.Name ?? "Unknown";
            dbContext.Entry(requirement).State = EntityState.Modified;
            dbContext.SaveChanges();
            var find = dbContext.Requirement.Find(id);
            return Ok(find);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteRequirement(int id)
        {
            var requirement = dbContext.Requirement.Find(id);
            if (requirement == null)
            {
                return NotFound($"Requirement with id {id} not found.");
            }
            dbContext.Requirement.Remove(requirement);
            dbContext.SaveChanges();
            return Ok(requirement);
        }

        /* 

        // <access modifier> <return type> <method name>()
        [HttpGet("courses-with-subjects")]
        public IActionResult GetCoursesWithSubjects()
        {
            // <variable> - Get all courses with their subjects in one go
            var courses = dbContext.Courses
                .Include(c => c.Subjects) // EF Core navigation property
                .ToList();

            return Ok(courses);
        }


        [HttpGet]
        [Route("Check/{id:int}")]
        public IActionResult CheckRequirementIsCompleted(int id)
        {
            var requirement = dbContext.Requirement.Find(id);
            if (requirement == null)
            {
                return NotFound($"Requirement with id {id} not found.");
            }
            // Check if the requirement is completed
            bool isCompleted = requirement.IsGood && !string.IsNullOrEmpty(requirement.Form137);
            return Ok(new { RequirementId = id, IsCompleted = isCompleted });
        }
        */

    }

}
