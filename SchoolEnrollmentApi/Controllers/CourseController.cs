using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using SchoolEnrollmentApi.EnrollmentLibrary;
using SchoolEnrollmentApi.EnrollmentLibrary.DTOs;
using SchoolEnrollmentApi.EnrollmentLibrary.Models;

namespace SchoolEnrollmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController(DatabaseEnrollment dbContext) : Controller
    {
        private readonly DatabaseEnrollment dbContext = dbContext;

        [HttpGet]
        public IActionResult GetCourses()
        {
            var courses = dbContext.Course.ToList();
            if (courses == null || courses.Count == 0)
            {
                return NotFound("No courses found.");
            }
            return Ok(courses);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetCourseById(int id)
        {
            var course = dbContext.Course.Find(id);
            if (course == null)
            {
                return NotFound($"Course with id {id} not found.");
            }
            return Ok(course);
        }

        [HttpPost]
        public IActionResult PostCourse(AddCourseDTOs adddtos)
        {
            var course = new Course()
            {
                CourseName = adddtos.CourseName,
                AvailabilityStatus = adddtos.AvailabilityStatus,
                CourseDetail = adddtos.CourseDetail,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                CreatedBy = User?.Identity?.Name ?? "Unknown",
            };
            dbContext.Course.Add(course);
            dbContext.SaveChanges();
            var showreturn = new GetCourseDTOs()
            {
                CourseId = course.CourseId,
                CourseName = course.CourseName,
                AvailabilityStatus = course.AvailabilityStatus,
                CourseDetail = course.CourseDetail,
                CreatedAt = course.CreatedAt,
                UpdatedAt = course.UpdatedAt,
                CreatedBy = course.CreatedBy,
            };
            return Ok(showreturn);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateCourse(int id, AddCourseDTOs updatedtos)
        {
            var updatecourse = dbContext.Course.Find(id);
            if (updatecourse == null)
            {
                return NotFound($"Course with id {id} not found.");
            }

            updatecourse.CourseName = updatedtos.CourseName;
            updatecourse.AvailabilityStatus = updatedtos.AvailabilityStatus;
            updatecourse.CourseDetail = updatedtos.CourseDetail;
            updatecourse.UpdatedAt = DateTime.Now;
            updatecourse.CreatedBy = User?.Identity?.Name ?? "Unknown";
            dbContext.Entry(updatecourse).State = EntityState.Modified;
            dbContext.SaveChanges();
            var find = dbContext.Course.Find(id);
            return Ok(find);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult ClosedCourse(int id)
        {
            var course = dbContext.Course.Find(id);
            if (course == null)
            {
                return NotFound($"Course {id} not found.");
            }
            dbContext.Course.Remove(course);
            dbContext.SaveChanges();
            return Ok(course);
        }
    }
}
