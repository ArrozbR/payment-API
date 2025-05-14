using Microsoft.EntityFrameworkCore;
using PaymentAPI.Models;

namespace PaymentAPI.Context
{
    public class PaymentContext : DbContext
    {
        public PaymentContext(DbContextOptions<PaymentContext> options) : base(options)
        {
            
        }

        public DbSet<Vendor> Vendor { get; set; }
        public DbSet<Acquisition> Acquisition { get; set; }
    }
}