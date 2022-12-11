using EmployeeCrud.Data.Model;
using Microsoft.EntityFrameworkCore;



namespace EmployeeCrud.DB
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Admin",
                    Password = "Admin12345",
                    Role = "Admin"
                }
            );
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, FirstName = "Joe", LastName = "Moe", Phone = "123456", JobTitle = "teacher" },
                 new Employee { Id = 2, FirstName = "Ahmed", LastName = "Ibrahim", Phone = "12345", JobTitle = "Engineer" },
                new Employee { Id = 3, FirstName = "Moe", LastName = "Joe", Phone = "123", JobTitle = "Engineer" },
                 new Employee { Id = 4, FirstName = "D", LastName = "F", Phone = "1246", JobTitle = "teacher" },
                  new Employee { Id = 5, FirstName = "E", LastName = "G", Phone = "9875", JobTitle = "Doctor" },
               new Employee { Id = 6, FirstName = "R", LastName = "W", Phone = "65423", JobTitle = "Doctor" }
            );
        }
    }
}