using EmployeeCrud.API.Authentication;
using EmployeeCrud.API.Model;
using EmployeeCrud.API.Wrappers;
using EmployeeCrud.Common;
using EmployeeCrud.Common.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeCrud.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<AdminController> _logger;
        private readonly IEmployeeService _employeeService;

        private readonly ITokenAuth _jwtAuth;
        public EmployeeController(ILogger<AdminController> logger, IEmployeeService employeeService, ITokenAuth jwtAuth)
        {
            _logger = logger;
            _employeeService = employeeService;
            _jwtAuth = jwtAuth;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()

        {
            try
            {
                _logger.LogInformation($"Returned all employess from the memory database.");
                IEnumerable<IEmployee> employeesList = await _employeeService.GetEmployees();
                return Ok(Response<IEnumerable<IEmployee>>.Success(employeesList.Select(s => new Employee(s))));

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside the ReadAll action: {ex}");
                return StatusCode(500, Response<string>.Fail("Error retrieving data from the memory database"));

            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)

        {
            try
            {
                _logger.LogInformation($"Returned all employess from the memory database.");
                IEmployee currentEmployee = await _employeeService.GetEmployeeById(id);
                return Ok(Response<IEmployee>.Success(currentEmployee));

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside the GetByID action: {ex}");
                return StatusCode(500, Response<string>.Fail("Error retrieving data from the memory database"));

            }
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employee)
        {
            try
            {

                _logger.LogInformation($"Created ship:{employee.FirstName + "," + employee.LastName}");

                if (employee == null)
                {
                    return BadRequest(Response<string>.Fail("The employee is empty "));
                }


                bool isInserted = await _employeeService.AddEmployee(employee);
                if (isInserted)
                {
                    return Ok(Response<string>.Success("The employee is created."));
                }
                else
                {
                    return BadRequest(Response<string>.Fail("Create operation failed "));

                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside the AddEmployee action: {ex}");

                return StatusCode(500, Response<string>.Fail("Error on Add operation"));

            }

        }
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromBody] Employee employee)
        {
            try
            {
                _logger.LogInformation($"Updated Employee:{employee.FirstName + "," + employee.LastName}");

                if (employee == null)
                {
                    return BadRequest(Response<string>.Fail("The ship is empty "));
                }
                bool isUpdated = await _employeeService.UpdateEmployee(employee);
                if (isUpdated)
                {
                    return Ok(Response<string>.Success("The Employee is updated"));
                }
                else
                {
                    return BadRequest(Response<string>.Fail("Update operation failed "));

                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside the UpdateEmployee action: {ex}");

                return StatusCode(500, Response<string>.Fail("Error on Update operation"));

            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] int id)
        {
            try
            {
                _logger.LogInformation($"Delete employee by code is :{id}");


                bool isDeleted = await _employeeService.DeleteEmployee(id);
                if (isDeleted)
                {
                    return Ok(Response<string>.Success("The employee is deleted"));
                }
                else
                {
                    return BadRequest(Response<string>.Fail("Delete operation failed "));

                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside the DeleteEmployee action: {ex}");

                return StatusCode(500, Response<string>.Fail("Error on  deleteing employee data from the memory database"));


            }
        }
    }
}
