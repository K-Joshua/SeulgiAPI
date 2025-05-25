using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolEnrollmentApi.EnrollmentLibrary;
using SchoolEnrollmentApi.EnrollmentLibrary.DTOs;
using SchoolEnrollmentApi.EnrollmentLibrary.Models;
using System;
using System.Collections.Generic;

namespace SchoolEnrollmentApi.Controllers
{
    //localhost:7196/api/AvailabilityStatus Controller - controller name    
    [Route("api/[controller]")]
    [ApiController] // It Tells the computer that this is a controller
    public class AvailabilityStatusController (DatabaseEnrollment dbContext) : Controller // The DbContext (bridges database and Code)
    {
        private readonly DatabaseEnrollment dbContext = dbContext; // Pass the DbContext to the controllers
        [HttpGet] // tells the computer that this is the controller 
        public IActionResult GetAllAvailabilityStatus() //Method to make get controller
        {
            var getall = dbContext.AvailabilityStatus.ToList(); // Gets all data from availability status
            if (getall == null || getall.Count == 0) // if null return 404
            {
                return NotFound("No Available Status Found");
            }
            return Ok(getall); // If no problem returns 200
        }
        [HttpGet] // tells the computer that this is the controller
        [Route("{id:int}")] // Route to get by id
        public IActionResult GetAvailabilityStatusById(int id) // method to make get controller
        {
            var getbyid = dbContext.AvailabilityStatus.Find(id); // gets the data by id
            if (getbyid == null) // if null return 404
            {
                return NotFound($"Id {id} Not Found");
            }
            return Ok(getbyid); // if no problem returns 200
        }
        [HttpPost] // tells the computer that this is the controller
        public IActionResult PostAvailabilityStatus(AddAvailabilityStatusDTOs adddtos) // method to make post controller
        {
            var addstatus = new AvailabilityStatus() // object
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
        [HttpPut("{id:int}")]
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
        [HttpDelete("{id:int}")]
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
