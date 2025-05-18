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
    public class PaymentTypeController (DatabaseEnrollment dbContext) : Controller
    {
        private readonly DatabaseEnrollment dbContext = dbContext;
        [HttpGet]
        public IActionResult GetPaymentTypes()
        {
            var paymenttype = dbContext.PaymentType.ToList();
            if (paymenttype == null)
            {
                return NotFound("No Payment Types Found");
            }
            return Ok(paymenttype);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetPaymentTypeById(int id)
        {
            var paymenttype = dbContext.PaymentType.Find(id);
            if (paymenttype == null)
            {
                return NotFound($"Id {id} Not Found");
            }
            return Ok(paymenttype);
        }

        [HttpPost]
        public IActionResult PostPaymentType(AddPaymentTypeDTOs adddtos)
        {
            var addpayment = new PaymentType()
            {
                Type = adddtos.Type,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                CreatedBy = User?.Identity?.Name ?? "Unknown"
            };
            dbContext.PaymentType.Add(addpayment);
            dbContext.SaveChanges();
            var showreturn = new GetPaymentTypeDTOs()
            {
                PaymentTypeId = addpayment.PaymentTypeId,
                Type = addpayment.Type,
                CreatedAt = addpayment.CreatedAt,
                UpdatedAt = addpayment.UpdatedAt,
                CreatedBy = addpayment.CreatedBy
            };
            return Ok(showreturn);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult PutPaymentType(int id, AddPaymentTypeDTOs  adddtos)
        {
            var addproducttype = dbContext.PaymentType.Find(id);
            if (addproducttype == null)
            {
                return NotFound($"Id {id} Not Found");
            }
            addproducttype.Type = adddtos.Type;
            addproducttype.UpdatedAt = DateTime.Now;
            addproducttype.CreatedBy = User?.Identity?.Name ?? "Unknown";
            dbContext.Entry(addproducttype).State = EntityState.Modified;
            dbContext.SaveChanges();
            var find = dbContext.PaymentType.Find(id);
            return Ok(find);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeletePaymentType (int id)
        {
            var delete = dbContext.PaymentType.Find(id);
            if (delete == null)
            {
                return NotFound($"Id {id} Not Found");
            }
            dbContext.PaymentType.Remove(delete);
            dbContext.SaveChanges();
            return Ok(delete);
        }
    }
}
