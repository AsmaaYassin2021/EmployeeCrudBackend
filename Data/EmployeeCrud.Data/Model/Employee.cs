using EmployeeCrud.Common.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeCrud.Data.Model
{
    public class Employee : IEmployee
    {
        public Employee(IEmployee employee)
        {

        }
        public Employee()
        {

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; } = 0!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string JobTitle { get; set; } = null!;

        internal void UpdateProperties(IEmployee currentEmployee)
        {
            FirstName = currentEmployee.FirstName;
            LastName = currentEmployee.LastName;
            Phone = currentEmployee.Phone;
            JobTitle = currentEmployee.JobTitle;
        }
    }
}
