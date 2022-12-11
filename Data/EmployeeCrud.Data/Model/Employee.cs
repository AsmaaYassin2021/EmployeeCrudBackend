using EmployeeCrud.Common.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeCrud.Data.Model
{
    public class Employee : IEmployee
    {
        public Employee(IEmployee employee)
        {
            FirstName = employee.FirstName;
            LastName = employee.LastName;
            Phone = employee.Phone;
            JobTitle = employee.JobTitle;
        }
        public Employee()
        {

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string JobTitle { get; set; }

        internal void UpdateProperties(IEmployee currentEmployee)
        {
            FirstName = currentEmployee.FirstName;
            LastName = currentEmployee.LastName;
            Phone = currentEmployee.Phone;
            JobTitle = currentEmployee.JobTitle;
        }
    }
}
