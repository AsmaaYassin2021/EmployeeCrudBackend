using EmployeeCrud.Common;
using EmployeeCrud.DB;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCrud.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly EmployeeDBContext _context;
        public UserRepository(EmployeeDBContext context)
        {
            this._context = context;
        }

        public async Task<bool> Login(string name, string password)
        {
            return await _context.Users.AnyAsync(s => s.Name == name && s.Password == password);
        }
    }
}
