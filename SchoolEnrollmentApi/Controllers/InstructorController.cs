using Microsoft.AspNetCore.Mvc;
using SchoolEnrollmentApi.EnrollmentLibrary;
using SchoolEnrollmentApi.EnrollmentLibrary.Models;
using SchoolEnrollmentApi.EnrollmentLibrary.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SchoolEnrollmentApi.EnrollmentLibrary.Methods;

namespace SchoolEnrollmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController(DatabaseEnrollment dbContext) : Controller
    {
        private readonly DatabaseEnrollment dbContext = dbContext;

        [HttpGet]
        public IActionResult GetInstructors()
        {
            var instructor = dbContext.Instructor.ToList();
            if (instructor == null)
            {
                return NotFound("No instructors found.");
            }
            return Ok(instructor);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetInstructorById(int id)
        {
            var instructor = dbContext.Instructor.Find(id);
            if (instructor == null)
            {
                return NotFound($"Instructor with id {id} not found.");
            }
            return Ok(instructor);
        }

        [HttpPost]
        public IActionResult PostInstructor(AddInstructorDTOs addinstructordtos)
        {
            DateOnly CurrentDate = DateOnly.FromDateTime(DateTime.Now);
            var instructorEntity = new Instructor()
            {
                Name = addinstructordtos.Name,
                BirthDate = addinstructordtos.BirthDate,
                Address = addinstructordtos.Address,
                Email = addinstructordtos.Email,
                PhoneNumber = addinstructordtos.PhoneNumber,
                Age = AgeMethod.CalculateAge(addinstructordtos.BirthDate, CurrentDate),
                Sex = addinstructordtos.Sex,
                ExternalPosition = addinstructordtos.ExternalPosition,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                CreatedBy = User?.Identity?.Name ?? "Unknown",
            };
            if (addinstructordtos.BirthDate > CurrentDate)
            {
                return BadRequest("BirthDate Cannot Be In The Future.");
            }
            if (addinstructordtos.Sex != "Male" && addinstructordtos.Sex != "Female")
            {
                return BadRequest("There Are Only Two Sex, Male and Female");
            }

            dbContext.Instructor.Add(instructorEntity);
            dbContext.SaveChanges();

            var response = new GetInstructorDTOs()
            {
                InstructorId = instructorEntity.InstructorId,
                Name = instructorEntity.Name,
                BirthDate = instructorEntity.BirthDate,
                Age = instructorEntity.Age,
                Address = instructorEntity.Address,
                Email = instructorEntity.Email,
                PhoneNumber = instructorEntity.PhoneNumber,
                Sex = instructorEntity.Sex,
                CreatedAt = instructorEntity.CreatedAt,
                UpdatedAt = instructorEntity.UpdatedAt,
                CreatedBy = instructorEntity.CreatedBy,
                ExternalPosition = instructorEntity.ExternalPosition,
            };
            return Ok(response);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult PutInstructor(int id, AddInstructorDTOs updatetos)
        {
            DateOnly CurrentDate = DateOnly.FromDateTime(DateTime.Now);
            var instructor = dbContext.Instructor.Find(id);
            if (instructor == null)
            {
                return NotFound($"Instructor with id {id} not found.");
            }
            instructor.Name = updatetos.Name;
            instructor.BirthDate = updatetos.BirthDate;
            instructor.Address = updatetos.Address;
            instructor.Email = updatetos.Email;
            instructor.PhoneNumber = updatetos.PhoneNumber;
            instructor.Age = AgeMethod.CalculateAge(instructor.BirthDate, CurrentDate);
            instructor.Sex = updatetos.Sex;
            instructor.ExternalPosition = updatetos.ExternalPosition;
            instructor.UpdatedAt = DateTime.Now;
            instructor.CreatedBy = User?.Identity?.Name ?? "Unknown";
            if (instructor.BirthDate > CurrentDate)
            {
                return BadRequest("BirthDate Cannot Be In The Future.");
            }
            if (instructor.Sex != "Male" && instructor.Sex != "Female")
            {
                return BadRequest("There Are Only Two Sex, Male and Female");
            }
            dbContext.Entry(instructor).State = EntityState.Modified;
            dbContext.SaveChanges();
            var find = dbContext.Instructor.Find(id);
            return Ok(find);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteInstructor(int id)
        {
            var instructor = dbContext.Instructor.Find(id);
            if (instructor == null)
            {
                return NotFound($"Instructor with id {id} not found.");
            }
            dbContext.Instructor.Remove(instructor);
            dbContext.SaveChanges();
            return Ok($"Instructor with id {id} deleted successfully.");
        }
    }
}
