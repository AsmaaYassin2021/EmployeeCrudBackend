using EmployeeCrud.Common;
using EmployeeCrud.Common.Contracts;
using EmployeeCrud.Data.Model;
using EmployeeCrud.DB;
using Microsoft.EntityFrameworkCore;


namespace EmployeeCrud.Data.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDBContext _context;
        public EmployeeRepository(EmployeeDBContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<IEmployee>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<bool> AddEmployee(IEmployee employee)
        {

            var isSuccessed = false;
            _context.Employees.Add(new Employee(employee));
            int returnNumber = await _context.SaveChangesAsync();
            if (returnNumber == 1)
                isSuccessed = true;
            return isSuccessed;
        }
        public async Task<bool> UpdateEmployee(IEmployee updatedEmployee)
        {
            var isSuccessed = false;
            var oldEmployee = _context.Employees.SingleOrDefaultAsync(i => i.Id == updatedEmployee.Id);
            if (oldEmployee == null)
                return isSuccessed;

            //   (await oldEmployee).Result.UpdateProperties(updatedEmployee);
            int returnNumber = await _context.SaveChangesAsync();

            if (returnNumber == 1)
                isSuccessed = true;

            return isSuccessed;
        }
        public async Task<bool> DeleteEmployee(int deletedEmployeeID)
        {
            var isSuccessed = false;

            var deletedShip = _context.Employees.SingleOrDefaultAsync(i => i.Id == deletedEmployeeID).Result;
            if (deletedShip == null)
                return isSuccessed;

            _context.Remove(deletedShip);
            int returnNumber = await _context.SaveChangesAsync();

            if (returnNumber == 1)
                isSuccessed = true;
            return isSuccessed;
        }
    }
}
