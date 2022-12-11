using EmployeeCrud.Common.Contracts;

namespace EmployeeCrud.Common
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<IEmployee>> GetEmployees();
        Task<bool> AddEmployee(IEmployee employee);
        Task<bool> UpdateEmployee(IEmployee updatedEmployee);
        Task<bool> DeleteEmployee(int deletedEmployeeID);
        Task<IEmployee> GetEmployeeById(int id);
    }
}
