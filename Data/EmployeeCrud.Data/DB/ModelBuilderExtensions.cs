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
                new Employee { Id = 1, FirstName = "A", LastName = "Software", Phone = "", JobTitle = "" },
                 new Employee { Id = 2, FirstName = "Network", LastName = "Hardware", Phone = "", JobTitle = "" },
                new Employee { Id = 3, FirstName = "Devpos", LastName = "Software", Phone = "", JobTitle = "" },
                 new Employee { Id = 4, FirstName = "C#", LastName = "Software", Phone = "", JobTitle = "" },
                  new Employee { Id = 5, FirstName = "Java", LastName = "Software", Phone = "", JobTitle = "" },
               new Employee { Id = 6, FirstName = "Python", LastName = "Software", Phone = "", JobTitle = "" }
            );
        }
    }
}