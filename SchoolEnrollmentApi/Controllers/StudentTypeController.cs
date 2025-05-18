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
    public class StudentTypeController(DatabaseEnrollment dbContext) : Controller
    {
        private readonly DatabaseEnrollment dbContext = dbContext;

        [HttpGet]
        public IActionResult GetStudentType()
        {
            var studentType = dbContext.StudentType.ToList();
            if (studentType == null || studentType.Count == 0)
            {
                return NotFound("No student type found.");
            }
            return Ok(studentType);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetStudentTypeById(int id)
        {
            var studentType = dbContext.StudentType.Find(id);
            if (studentType == null)
            {
                return NotFound($"Student type with id {id} not found.");
            }
            return Ok(studentType);
        }

        [HttpPost]
        public IActionResult PostStudentType(AddStudentTypeDTOs adddtos)
        {
            var studentType = new StudentType()
            {
                Type = adddtos.Type,
                IsRegestered = adddtos.IsRegestered,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                CreatedBy = User?.Identity?.Name ?? "Unknown",
            };
            dbContext.StudentType.Add(studentType);
            dbContext.SaveChanges();
            var showresult = new GetStudentTypeDTOs()
            {
                StudentTypeId = studentType.StudentTypeId,
                Type = studentType.Type,
                IsRegestered = studentType.IsRegestered,
                CreatedAt = studentType.CreatedAt,
                UpdatedAt = studentType.UpdatedAt,
                CreatedBy = studentType.CreatedBy,
            };
            return Ok(showresult);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult PutStudentType(int id, AddStudentTypeDTOs editdtos)
        {
            var studentType = dbContext.StudentType.Find(id);
            if (studentType == null)
            {
                return NotFound($"Student type with id {id} not found.");
            }
            studentType.Type = editdtos.Type;
            studentType.IsRegestered = editdtos.IsRegestered;
            studentType.UpdatedAt = DateTime.Now;
            studentType.CreatedBy = User?.Identity?.Name ?? "Unknown";
            dbContext.Entry(studentType).State = EntityState.Modified;
            dbContext.SaveChanges();
            var showresult = new GetStudentTypeDTOs()
            {
                StudentTypeId = studentType.StudentTypeId,
                Type = studentType.Type,
                IsRegestered = studentType.IsRegestered,
                CreatedAt = studentType.CreatedAt,
                UpdatedAt = studentType.UpdatedAt,
                CreatedBy = studentType.CreatedBy,
            };
            return Ok(showresult);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteStudentType(int id)
        {
            var studentType = dbContext.StudentType.Find(id);
            if (studentType == null)
            {
                return NotFound($"Student type with id {id} not found.");
            }
            dbContext.StudentType.Remove(studentType);
            dbContext.SaveChanges();
            return Ok($"Student type with id {id} deleted successfully.");
        }
    }
}
