using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using PaymentAPI.Context;
using PaymentAPI.Models;

namespace PaymentAPI.Controllers{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase{
        private readonly PaymentContext _context;

        public PaymentController(PaymentContext context){
            _context = context;
        }

        [HttpPost]
        public IActionResult CeateAcquisition(Acquisition acquisition){
            _context.Acquisition.Add(acquisition);
            _context.SaveChanges();
            return Ok(acquisition);
        }
    }
}