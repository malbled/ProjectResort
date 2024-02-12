using ProjectResort.Context1.Models;
using System.Data.Entity;

namespace ProjectResort.Context1
{
    public class ResortContext : DbContext
    {
        public ResortContext() : base("ResortDB1")
        {

        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<EntryLog> EntryLogs { get; set; }
    }
}
