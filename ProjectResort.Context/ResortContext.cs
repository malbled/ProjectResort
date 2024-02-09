using ProjectResort.Context.Models;
using System.Data.Entity;

namespace ProjectResort.Context
{
    public class ResortContext : DbContext
    {
        public ResortContext() : base("ResortDB")
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Staff> Staffs { get; set; }
    }
}
