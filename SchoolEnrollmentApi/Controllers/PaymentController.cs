using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using SchoolEnrollmentApi.EnrollmentLibrary;
using SchoolEnrollmentApi.EnrollmentLibrary.DTOs;
using SchoolEnrollmentApi.EnrollmentLibrary.Models;

namespace SchoolEnrollmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController(DatabaseEnrollment dbContext) : Controller
    {
        private readonly DatabaseEnrollment dbContext = dbContext;

        [HttpGet]
        public IActionResult GetPayment()
        {
            var payment = dbContext.Payment.ToList();
            if (payment == null || payment.Count == 0)
            {
                return NotFound("No payment found.");
            }
            return Ok(payment);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetPaymentById(int id)
        {
            var payment = dbContext.Payment.Find(id);
            if (payment == null)
            {
                return NotFound($"Payment with id {id} not found.");
            }
            return Ok(payment);
        }

        [HttpPost]
        public IActionResult PostPayment(AddPaymentDTOs adddtos)
        {
            var payment = new Payment()
            {
                PaymentTuition = adddtos.PaymentTuition,
                SubjectsAmountId = adddtos.SubjectAmountId,
                EntranceFee = adddtos.EntranceFee,
                IsPaidEntranceFee = adddtos.IsPaidEntranceFee,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                TaskStatusId = adddtos.TaskStatusId,
                PaymentTypeId = adddtos.PaymentTypeId,
                CreatedBy = User?.Identity?.Name ?? "Unknown",
            };
            if (payment.PaymentTuition < 0 || payment.EntranceFee < 0)
            {
                return BadRequest("No Negative");
            }
            dbContext.Payment.Add(payment);
            dbContext.SaveChanges();
            var showresult = new GetPaymentDTOs()
            {
                PaymentId = payment.PaymentId,
                PaymentTuition = payment.PaymentTuition,
                SubjectsAmountId = payment.SubjectsAmountId,
                EntranceFee = payment.EntranceFee,
                IsPaidEntranceFee = payment.IsPaidEntranceFee,
                CreatedAt = payment.CreatedAt,
                UpdatedAt = payment.UpdatedAt,
                TaskStatusId = payment.TaskStatusId,
                PaymentTypeId = payment.PaymentTypeId,
                CreatedBy = payment.CreatedBy,
            };
            return Ok(showresult);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult PutPayment(int id, AddPaymentDTOs updatedtos)
        {
            var payment = dbContext.Payment.Find(id);
            if (payment == null)
            {
                return NotFound($"Payment with id {id} not found.");
            }
            payment.PaymentTuition = updatedtos.PaymentTuition;
            payment.EntranceFee = updatedtos.EntranceFee;
            payment.IsPaidEntranceFee = updatedtos.IsPaidEntranceFee;
            payment.TaskStatusId = updatedtos.TaskStatusId;
            payment.PaymentTypeId = updatedtos.PaymentTypeId;
            payment.UpdatedAt = DateTime.Now;
            payment.CreatedBy = User?.Identity?.Name ?? "Unknown";
            if (payment.PaymentTuition < 0 || payment.EntranceFee < 0)
            {
                return BadRequest("No Negative");
            }
            dbContext.Entry(payment).State = EntityState.Modified;
            dbContext.SaveChanges();
            var find = dbContext.Payment.Find(id);
            return Ok(find);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult CancelPayment(int id)
        {
            var payment = dbContext.Payment.Find(id);
            if (payment == null)
            {
                return NotFound($"Payment with id {id} not found.");
            }
            dbContext.Payment.Remove(payment);
            dbContext.SaveChanges();
            return Ok($"Payment with id {id} has been deleted.");
        }
    }
}
