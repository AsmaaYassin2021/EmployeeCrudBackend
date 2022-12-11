
using EmployeeCrud.Common;
using EmployeeCrud.Common.Contracts;

namespace EmployeeCrud.Busniess.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUserRepository _userRepository;

        public EmployeeService(IEmployeeRepository employeeRepository, IUserRepository userRepository)
        {
            _employeeRepository = employeeRepository;
            _userRepository = userRepository;

        }


        public async Task<bool> Login(string name, string password)
        {
            return await _userRepository.Login(name, password);
        }
        public async Task<IEnumerable<IEmployee>> GetEmployees()
        {
            return await _employeeRepository.GetEmployees();
        }
        public async Task<bool> AddEmployee(IEmployee employee)
        {
            return await _employeeRepository.AddEmployee(employee);
        }
        public async Task<bool> UpdateEmployee(IEmployee updatedEmployee)
        {
            return await _employeeRepository.UpdateEmployee(updatedEmployee);
        }
        public async Task<bool> DeleteEmployee(int deletedEmployeeID)
        {
            return await _employeeRepository.DeleteEmployee(deletedEmployeeID);
        }


    }
}
