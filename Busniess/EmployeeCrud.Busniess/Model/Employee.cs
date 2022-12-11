using EmployeeCrud.Common.Contracts;


namespace EmployeeCrud.Busniess.Model
{
    public abstract class Employee : IEmployee
    {

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string JobTitle { get; set; } = null!;
    }
}
