using EmployeeCrud.Common.Contracts;

namespace EventReg.Common
{
    public interface IEmployeeService
    {
        Task<IEnumerable<IEmployee>> GetEmployees();
        Task<bool> AddEmployee(IEmployee employee);
        Task<bool> UpdateEmployee(IEmployee updatedEmployee);
        Task<bool> DeleteEmployee(int deletedEmployeeID);
        Task<bool> Login(string name, string password);
    }
}