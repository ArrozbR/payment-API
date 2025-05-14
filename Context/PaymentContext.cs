using Microsoft.EntityFrameworkCore;
using PaymentAPI.Models;

namespace PaymentAPI.Context
{
    public class OrganizadorContext : DbContext
    {
        public OrganizadorContext(DbContextOptions<OrganizadorContext> options) : base(options)
        {
            
        }

        public DbSet<Vendor> Vendor { get; set; }
        public DbSet<Acquisition> Acquisition { get; set; }
    }
}