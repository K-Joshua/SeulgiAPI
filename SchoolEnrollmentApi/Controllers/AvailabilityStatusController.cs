using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using SchoolEnrollmentApi.EnrollmentLibrary;
using SchoolEnrollmentApi.EnrollmentLibrary.DTOs;
using SchoolEnrollmentApi.EnrollmentLibrary.Models;
using System.Reflection.Metadata.Ecma335;

namespace SchoolEnrollmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvailabilityStatusController (DatabaseEnrollment dbContext) : Controller
    {
        private readonly DatabaseEnrollment dbContext = dbContext;

        [HttpGet]
        public IActionResult GetAllAvailabilityStatus()
        {
            var getall = dbContext.AvailabilityStatus.ToList();
            if (getall == null)
            {
                return NotFound("No Available Found");
            }
            return Ok(getall);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetAvailabilityStatusById(int id)
        {
            var getbyid = dbContext.AvailabilityStatus.Find(id);
            if (getbyid == null)
            {
                return NotFound($"Id {id} Not Found");
            }
            return Ok(getbyid);
        }

        [HttpPost]
        public IActionResult PostAvailabilityStatus(AddAvailabilityStatusDTOs adddtos)
        {
            var addstatus = new AvailabilityStatus()
            {
                Status = adddtos.Status,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,   
                CreatedBy = User?.Identity?.Name ?? "Unknown",
            };
            dbContext.AvailabilityStatus.Add(addstatus);
            dbContext.SaveChanges();
            var showreturn = new GetAvailabilityStatusDTOs()
            {
                AvailabilityStatusId = addstatus.AvailabilityStatusId,
                Status = addstatus.Status,
                CreatedAt = addstatus.CreatedAt,
                UpdatedAt = addstatus.UpdatedAt,
                CreatedBy = addstatus.CreatedBy,
            };
            return Ok(showreturn);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult PutAvailabilityStatus(int id, AddAvailabilityStatusDTOs editdtos)
        {
            var editstatus = dbContext.AvailabilityStatus.Find(id);
            if (editstatus == null)
            {
                return NotFound($"Id {id} Not Found");
            }
            editstatus.Status = editdtos.Status;
            editstatus.UpdatedAt = DateTime.Now;
            editstatus.CreatedBy = User?.Identity?.Name ?? "Unknown";
            dbContext.Entry(editstatus).State = EntityState.Modified;
            dbContext.SaveChanges();
            var find = dbContext.AvailabilityStatus.Find(id);
            return Ok(find);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteAvailStatus(int id)
        {
            var deletestatus = dbContext.AvailabilityStatus.Find(id);
            if (deletestatus == null)
            { 
                return NotFound($"Id {id} Not Found"); 
            }
            dbContext.AvailabilityStatus.Remove(deletestatus);
            dbContext.SaveChanges();
            return Ok(deletestatus);
        }
    }
}
