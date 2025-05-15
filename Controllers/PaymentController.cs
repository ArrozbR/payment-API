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

        [HttpPost("NewTransaction")]
        public IActionResult CeateAcquisition(Acquisition acquisition){
            if(acquisition.Status == null) acquisition.Status = "Awaiting Payment";
            acquisition.Date = DateTime.Now;
            _context.Acquisition.Add(acquisition);
            _context.SaveChanges();
            return Ok(acquisition);
        }

        [HttpPost("NewVendor")]
        public IActionResult CeateVendor(Vendor vendor){
            _context.Vendor.Add(vendor);
            _context.SaveChanges();
            return Ok(vendor);
        }

        [HttpGet("GetTransaction/{id}")]
        public IActionResult GetTransaction(int id){
            var transactionDatabase = _context.Acquisition.Find(id);
            if(transactionDatabase == null) return NotFound();
            return Ok(transactionDatabase);
        }

        [HttpPut("ModifyTransaction/{id}")]
        public IActionResult ModifyTransaction(int id, Acquisition acquisition){
            var transactionDatabase = _context.Acquisition.Find(id);
            if(transactionDatabase == null) return NotFound();
            if(transactionDatabase.Status != "Awaiting Payment") return BadRequest();
            transactionDatabase.Itens = acquisition.Itens;
            _context.Acquisition.Update(transactionDatabase);
            _context.SaveChanges();
            return Ok(transactionDatabase);
        }

        [HttpPut("CancelTransaction/{id}")]
        public IActionResult CancelTransaction(int id){
            var transactionDatabase = _context.Acquisition.Find(id);
            if(transactionDatabase == null) return NotFound();
            if(transactionDatabase.Status == "Sent to Carrier") return BadRequest();
            if(transactionDatabase.Status == "Delivered") return BadRequest();
            transactionDatabase.Status = "Canceled";
            _context.Acquisition.Update(transactionDatabase);
            _context.SaveChanges();
            return Ok(transactionDatabase);
        }

        [HttpPut("UpdateTransaction/{id}")]
        public IActionResult UpdateTransaction(int id){
            var transactionDatabase = _context.Acquisition.Find(id);
            if(transactionDatabase == null) return NotFound();
            if(transactionDatabase.Status == "Canceled") return BadRequest();
            if(transactionDatabase.Status == "Awaiting Payment"){
                transactionDatabase.Status = "Payment Approved";
                _context.Acquisition.Update(transactionDatabase);
                _context.SaveChanges();
            }
            else if(transactionDatabase.Status == "Payment Approved"){
                transactionDatabase.Status = "Sent to Carrier";
                _context.Acquisition.Update(transactionDatabase);
                _context.SaveChanges();
            }
            else if(transactionDatabase.Status == "Sent to Carrier"){
                transactionDatabase.Status = "Delivered";
                _context.Acquisition.Update(transactionDatabase);
                _context.SaveChanges();
            }
            return Ok(transactionDatabase);
        }
    }
}