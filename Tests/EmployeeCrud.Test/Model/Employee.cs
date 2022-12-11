using EmployeeCrud.Common.Contracts;

namespace EmployeeCrud.Test.Model
{

    public class Employee : IEmployee
    {
        public Employee(IEmployee currentEmployee)
        {
            Id = currentEmployee.Id;
            FirstName = currentEmployee.FirstName;
            LastName = currentEmployee.LastName;
            Phone = currentEmployee.Phone;
            JobTitle = currentEmployee.JobTitle;
        }
        public Employee()
        {

        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string JobTitle { get; set; }

    }
}
