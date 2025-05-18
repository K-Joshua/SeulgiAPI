using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolEnrollmentApi.EnrollmentLibrary;
using SchoolEnrollmentApi.EnrollmentLibrary.Models;
using SchoolEnrollmentApi.EnrollmentLibrary.DTOs;
using System;
using SchoolEnrollmentApi.EnrollmentLibrary.Methods;

namespace SchoolEnrollmentApi.Controllers
{
    //localhost:xxxx/api/Student
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController (DatabaseEnrollment dbContext): ControllerBase
    {
        private readonly DatabaseEnrollment dbContext = dbContext;


        [HttpGet] //attribute
        public IActionResult GetAllStudent()
        {
            //return Ok(dbContext.Student.ToList());
            var AllStudents = dbContext.Student.ToList();
            if (AllStudents == null || AllStudents.Count == 0)
            {
                return NotFound("No students found.");
            }
            return Ok(AllStudents);
        }


        [HttpGet]
        [Route ("{id:int}")]
        public IActionResult GetStudentById(int id) 
        { 
            var studentId = dbContext.Student.Find(id);
            if (studentId == null)
            {
                return NotFound($"Student with id {id}");
            }
            return Ok(studentId);
        }

        [HttpPost]
        public IActionResult PostStudent(AddStudentDTOs addstudentdtos)
        {
            DateOnly CurrentDate = DateOnly.FromDateTime(DateTime.UtcNow);
            var studentEntity = new Student()
            {
                Name = addstudentdtos.Name,
                BirthDate = addstudentdtos.BirthDate,
                Address = addstudentdtos.Address,
                Email = addstudentdtos.Email,
                PhoneNumber = addstudentdtos.PhoneNumber,
                Age = AgeMethod.CalculateAge(addstudentdtos.BirthDate, CurrentDate),
                Sex = addstudentdtos.Sex,
                CreatedAt = DateTime.UtcNow,    
                UpdatedAt = DateTime.UtcNow,
                CreatedBy = User?.Identity?.Name ?? "Unknown",
            };
            if (addstudentdtos.BirthDate > CurrentDate)
            {
                return BadRequest("BirthDate Cannot Be In The Future.");
            }
            if (addstudentdtos.Sex != "Male" && addstudentdtos.Sex != "Female")
            {
                return BadRequest("There Are Only Two Sex, Male and Female");
            }

            dbContext.Student.Add(studentEntity);
            dbContext.SaveChanges();

            var response = new GetStudentDTOs()
            {
                StudentId = studentEntity.StudentId,
                Name = studentEntity.Name,
                BirthDate = studentEntity.BirthDate,
                Age = studentEntity.Age,
                Address = studentEntity.Address,
                Email = studentEntity.Email,
                PhoneNumber = studentEntity.PhoneNumber,
                Sex = studentEntity.Sex,
                CreatedAt = studentEntity.CreatedAt,
                UpdatedAt = studentEntity.UpdatedAt,
                CreatedBy = studentEntity.CreatedBy,
            };
            return Ok(response);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult EditStudentById(int id, AddStudentDTOs alterstudentdtos)
        {
            DateOnly CurrentDate = DateOnly.FromDateTime(DateTime.UtcNow);
            var PutStudent = dbContext.Student.Find(id);
            if (PutStudent == null) 
            {
                return NotFound($"Student with ID {id} not found.");
            }
            PutStudent.Name = alterstudentdtos.Name;
            PutStudent.BirthDate = alterstudentdtos.BirthDate;
            PutStudent.Address = alterstudentdtos.Address;
            PutStudent.Email = alterstudentdtos.Email;
            PutStudent.PhoneNumber = alterstudentdtos.PhoneNumber;
            PutStudent.Age = AgeMethod.CalculateAge(alterstudentdtos.BirthDate, CurrentDate);
            PutStudent.Sex = alterstudentdtos.Sex;
            PutStudent.UpdatedAt = DateTime.UtcNow;
            PutStudent.CreatedBy = User?.Identity?.Name ?? "Unknown";
            if (PutStudent.Sex != "Male" && PutStudent.Sex != "Female")
            {
                return BadRequest("There Are Only Two Sex, Male and Female");
            }
            dbContext.Entry(PutStudent).State = EntityState.Modified;
            dbContext.SaveChanges();
            var GetStudent = dbContext.Student.Find(id);
            return Ok(GetStudent);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudentById(int id)
        {
            var Delstudent = dbContext.Student.Find(id);
            if (Delstudent == null)
            {
                return NotFound($"Student with ID {id} not found.");
            }
            dbContext.Student.Remove(Delstudent);
            dbContext.SaveChanges();
            return Ok($"Student with ID {id} deleted successfully.");
        }
    }
}
