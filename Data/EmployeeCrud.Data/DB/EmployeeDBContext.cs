using EmployeeCrud.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCrud.DB
{
    public class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext(DbContextOptions<EmployeeDBContext> options) : base(options)
        {


        }
        public EmployeeDBContext() : base() { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("Employee").HasKey(m => m.Id);
            //how do we extend the data model?
            modelBuilder.Entity<Employee>()
        .HasDiscriminator<string>("Address")
        .HasValue<Employee>("Employee")
        .HasValue<NewInfoForEmployee>("NewInfoForEmployee");


            modelBuilder.Entity<User>();

            modelBuilder.Seed();

        }
    }
}

