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
    [Route("api/[controller]")]  //controller url 
    [ApiController] // Tells the computer that this is a controller
    public class StudentController (DatabaseEnrollment dbContext): ControllerBase // The DbContext (bridges database and Code) 
    {
        private readonly DatabaseEnrollment dbContext = dbContext; // Pass the Dbcontext to the controller


        //end pont param student id -- get all subject student -- named getstudentsubject
        [HttpGet]
        [Route("GetAllSubject/{id:int}")]
        public IActionResult GetAllStudentSub(GetAllSubjectDTOs getsubject)
        {
            var getsub = from e in dbContext.Enrollment
                         join s in dbContext.Student on e.StudentId equals s.StudentId
                         join sl in dbContext.StudyLoad on e.StudyLoadId equals sl.StudyLoadId
                         join stlsub in dbContext.StudyLoadSubject on sl.StudyLoadSubjectId equals stlsub.StudyLoadSubjectId
                         join sub in dbContext.Subject on stlsub.SubjectId equals sub.SubjectId
                         where s.StudentId == e.StudentId && e.StudyLoadId == sl.StudyLoadId && sl.StudyLoadSubjectId == stlsub.StudyLoadSubjectId && stlsub.SubjectId == sub.SubjectId
                         select new GetAllSubjectDTOs()
                         {
                             SubjectId = sub.SubjectId,
                             Name = sub.Name,
                         };
            return Ok(getsub);
        }

        [HttpGet] //tells the computer that this is a controller
        public IActionResult GetAllStudent() // method make a get controller
        {
            //return Ok(dbContext.Student.ToList());
            var AllStudents = dbContext.Student.ToList(); // gets all data from student
            if (AllStudents == null || AllStudents.Count == 0) // if null show 404
            {
                return NotFound("No students found.");
            }
            return Ok(AllStudents); // if no problem show 200
        }


        [HttpGet] // tells the computer that this is a controller
        [Route ("{id:int}")] // route to get by id
        public IActionResult GetStudentById(int id) // method to make get controller
        { 
            var studentId = dbContext.Student.Find(id); // gets the data by id
            if (studentId == null) // if null return 404
            {
                return NotFound($"Student with id {id}");
            }
            return Ok(studentId); // if no problem show 200
        }

        [HttpPost] // tells the computer that this is a controller post
        public IActionResult PostStudent(AddStudentDTOs addstudentdtos) // it asks the DTO using parameters
        {
            DateOnly CurrentDate = DateOnly.FromDateTime(DateTime.UtcNow); // makes the current date
            var studentEntity = new Student() //this is an object of student, gives value to the property
            {
                Name = addstudentdtos.Name, 
                BirthDate = addstudentdtos.BirthDate,
                Address = addstudentdtos.Address,
                Email = addstudentdtos.Email,
                PhoneNumber = addstudentdtos.PhoneNumber,
                Age = AgeMethod.CalculateAge(addstudentdtos.BirthDate, CurrentDate), //Calculates the age
                Sex = addstudentdtos.Sex,
                CreatedAt = DateTime.UtcNow, // tells when it is created   
                UpdatedAt = DateTime.UtcNow, // tells when it is updated
                CreatedBy = User?.Identity?.Name ?? "Unknown",  // it tells who created, if not recognized show unknown
            };
            if (addstudentdtos.BirthDate > CurrentDate) // if the birthdate is greater than the current date
            {
                return BadRequest("BirthDate Cannot Be In The Future."); // return BadRequest
            }
            if (addstudentdtos.Sex != "Male" && addstudentdtos.Sex != "Female") 
            {
                return BadRequest("There Are Only Two Sex, Male and Female"); // return BadRequest
            }

            dbContext.Student.Add(studentEntity); // adds the students data to the database
            dbContext.SaveChanges(); // saves changes

            var response = new GetStudentDTOs() // this is an object of GetStudentDTOs
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
            return Ok(response); // Return 200
        }

        [HttpPut] // tells the computer that this is the controller put
        [Route("{id:int}")] // route to get by id
        public IActionResult EditStudentById(int id, AddStudentDTOs alterstudentdtos) // method to make controller
        {
            DateOnly CurrentDate = DateOnly.FromDateTime(DateTime.UtcNow); // creates current date
            var PutStudent = dbContext.Student.Find(id); // finds the student by id
            if (PutStudent == null) //if null show 404
            {
                var student = new Student()

                {
                    Name = alterstudentdtos.Name,
                    BirthDate = alterstudentdtos.BirthDate,
                    Address = alterstudentdtos.Address,
                    Email =  alterstudentdtos.Email,
                    PhoneNumber =  alterstudentdtos.PhoneNumber,
                    Age = AgeMethod.CalculateAge(alterstudentdtos.BirthDate, CurrentDate), //Calculates the age
                    Sex =  alterstudentdtos.Sex,
                    CreatedAt = DateTime.UtcNow, // tells when it is created   
                    UpdatedAt = DateTime.UtcNow, // tells when it is updated
                    CreatedBy = User?.Identity?.Name ?? "Unknown",  // it tells who created, if not recognized show unknown

                };
                 dbContext.Student.Add(student); // adds the students data to the database
                dbContext.SaveChanges(); // saves changes
                return Ok(student);
            }
            PutStudent.Name = alterstudentdtos.Name;
            PutStudent.BirthDate = alterstudentdtos.BirthDate;
            PutStudent.Address = alterstudentdtos.Address;
            PutStudent.Email = alterstudentdtos.Email;
            PutStudent.PhoneNumber = alterstudentdtos.PhoneNumber;
            PutStudent.Age = AgeMethod.CalculateAge(alterstudentdtos.BirthDate, CurrentDate); // calculates age
            PutStudent.Sex = alterstudentdtos.Sex;
            PutStudent.UpdatedAt = DateTime.UtcNow; //Updates the last date to the current date modified
            PutStudent.CreatedBy = User?.Identity?.Name ?? "Unknown"; // it tells who created, if not recognized show unknown
            if (PutStudent.Sex != "Male" && PutStudent.Sex != "Female")// if error return BadRequest
            {
                return BadRequest("There Are Only Two Sex, Male and Female");
            }
            dbContext.Entry(PutStudent).State = EntityState.Modified; // tells the computer that the data is modified
            dbContext.SaveChanges();// saves changes
            var GetStudent = dbContext.Student.Find(id); //find the student by id
            return Ok(GetStudent);// returns 200
        }

        [HttpDelete("{id}")] // tells the computer that this is the controller delete
        public IActionResult DeleteStudentById(int id) // method to make controller
        {
            var Delstudent = dbContext.Student.Find(id); //find the data to delete by id
            if (Delstudent == null) // if null show 404
            {
                return NotFound($"Student with ID {id} not found.");
            }
            dbContext.Student.Remove(Delstudent); // removes/deletes the data
            dbContext.SaveChanges();// saves changes
            return Ok($"Student with ID {id} deleted successfully."); // return 200
        }
    }
}
