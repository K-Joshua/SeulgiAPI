using Microsoft.AspNetCore.Mvc;
using SchoolEnrollmentApi.EnrollmentLibrary.Models;
using SchoolEnrollmentApi.EnrollmentLibrary.DTOs;
using SchoolEnrollmentApi.EnrollmentLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace SchoolEnrollmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TstatusController (DatabaseEnrollment dbContext) : Controller
    {
        private readonly DatabaseEnrollment dbContext = dbContext;

        [HttpGet]
        public IActionResult GetTaskStatus()
        {
            var taskstatus = dbContext.TaskStatus.ToList();
            if (taskstatus == null)
            {
                return NotFound("No Status has been found");
            }
            return Ok(taskstatus);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetTaskStatus(int id)
        {
            var taskstatus = dbContext.TaskStatus.Find(id);
            if (taskstatus == null)
            {
                return NotFound($"Id {id} Not Found");
            }
            return Ok(taskstatus);
        }

        [HttpPost]
        public IActionResult PostTaskStatus(AddTaskStatusDTOs adddtos)
        {
            var taskStatus = new TStatus()
            {
                Status = adddtos.Status,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                CreatedBy = User?.Identity?.Name ?? "Unknown",
            };
            dbContext.TaskStatus.Add(taskStatus);
            dbContext.SaveChanges();
            var showresult = new GetTaskStatusDTOs()
            {
                TaskStatusId = taskStatus.TaskStatusId,
                Status = taskStatus.Status,
                CreatedAt = taskStatus.CreatedAt,
                UpdatedAt = taskStatus.UpdatedAt,
                CreatedBy = taskStatus.CreatedBy,
            };
            return Ok(showresult);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult PutTaskStatus(int id, AddTaskStatusDTOs editstatus)
        {
            var puttask = dbContext.TaskStatus.Find(id);
            if (puttask == null)
            {
                return NotFound($"Id {id} Not Found");
            }
            puttask.Status = editstatus.Status;
            puttask.UpdatedAt = DateTime.Now;
            puttask.CreatedBy = User?.Identity?.Name ?? "Unknown";
            dbContext.Entry(puttask).State = EntityState.Modified;
            dbContext.SaveChanges();
            var find = dbContext.TaskStatus.Find(id);
            return Ok(find);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteTaskStatus(int id)
        {
            var deletestatus = dbContext.TaskStatus.Find(id);
            if (deletestatus == null)
            {
                return NotFound($"Id {id} Not Found");
            }
            dbContext.TaskStatus.Remove(deletestatus);
            dbContext.SaveChanges();
            return Ok(deletestatus);
        }

    }
}
