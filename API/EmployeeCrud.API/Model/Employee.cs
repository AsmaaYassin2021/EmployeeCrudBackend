using EmployeeCrud.Common.Contracts;
using System.Runtime.Serialization;

namespace EmployeeCrud.API.Model
{
    [DataContract(Name = "employee")]
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
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "firstName")]
        public string FirstName { get; set; }

        [DataMember(Name = "lastName")]
        public string LastName { get; set; }
        [DataMember(Name = "phone")]
        public string Phone { get; set; }

        [DataMember(Name = "jobTitle")]
        public string JobTitle { get; set; }

    }
}
