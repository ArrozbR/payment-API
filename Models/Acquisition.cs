using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentAPI.Models
{
    public class Acquisition
    {
        public int Id { get; set; }
        public string Itens { get; set; }
        public DateTime Date { get; set; }
        public int VendorInfoId { get; set; }
        public string Status { get; set; }
    }
}