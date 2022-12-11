using EmployeeCrud.Common.Contracts;

namespace EmployeeCrud.Busniess.Model
{
    public class User : IUser
    {

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Role { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
