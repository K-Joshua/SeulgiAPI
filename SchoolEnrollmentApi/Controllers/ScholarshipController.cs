using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using SchoolEnrollmentApi.EnrollmentLibrary;
using SchoolEnrollmentApi.EnrollmentLibrary.DTOs;
using SchoolEnrollmentApi.EnrollmentLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace SchoolEnrollmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ScholarshipController(DatabaseEnrollment dbContext) : Controller  //primary constructor    
    {
        private readonly DatabaseEnrollment dbContext = dbContext;

        [HttpGet]
        public IActionResult GetScholarships()
        {
            var scholarships = dbContext.Scholarship.ToList();
            if (scholarships == null)
            {
                return NotFound("No Scholarships Has Been Posted");
            }
            return Ok(scholarships);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetScholarshipById(int id)
        {
            var scholarship = dbContext.Scholarship.Find(id);
            if (scholarship == null)
            {
                return NotFound($"Scholarship with id {id} not found.");
            }
            return Ok(scholarship);
        }

        [HttpPost]
        public IActionResult PutScholarship(AddScholarshipDTOs adddtos)
        {
            var scholarship = new Scholarship()
            {
                Name = adddtos.Name,
                Amount = adddtos.Amount,
                Period = adddtos.Period,
                Type = adddtos.Type,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                CreatedBy = User?.Identity?.Name ?? "Unknown",
            };  
            if (scholarship.Amount < 0)
            {
                return BadRequest("No Negative");
            }
            dbContext.Scholarship.Add(scholarship);
            dbContext.SaveChanges();
            var showresult = new GetScholarshipDTOs()
            {
                ScholarshipId = scholarship.ScholarshipId,
                Name = scholarship.Name,
                Amount = scholarship.Amount,
                Period = scholarship.Period,
                Type = scholarship.Type,
                CreatedAt = scholarship.CreatedAt,
                UpdatedAt = scholarship.UpdatedAt,
                CreatedBy = scholarship.CreatedBy
            };
            return Ok(showresult);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult PutScholarship(int id, AddScholarshipDTOs alterdtos)
        {
            var scholarship = dbContext.Scholarship.Find(id);
            if (scholarship == null)
            {
                return NotFound($"Scholarship with id {id} not found.");
            }
            scholarship.Name = alterdtos.Name;
            scholarship.Amount = alterdtos.Amount;
            scholarship.Period = alterdtos.Period;
            scholarship.Type = alterdtos.Type;
            scholarship.UpdatedAt = DateTime.Now;
            scholarship.CreatedBy = User?.Identity?.Name ?? "Unknown";
            if (scholarship.Amount < 0)
            {
                return BadRequest("No Negative");
            }
            dbContext.Entry(scholarship).State = EntityState.Modified;
            dbContext.SaveChanges();
            var find = dbContext.Scholarship.Find(id);
            return Ok(find);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteScholarship(int id)
        {
            var scholarship = dbContext.Scholarship.Find(id);
            if (scholarship == null)
            {
                return NotFound($"Scholarship with id {id} not found.");
            }
            dbContext.Scholarship.Remove(scholarship);
            dbContext.SaveChanges();
            return Ok($"Scholarship with id {id} has been deleted.");
        }
    }
}
