using EmployeeCrud.API.Authentication;
using EmployeeCrud.API.Controllers;
using EmployeeCrud.API.Model;
using EmployeeCrud.API.Wrappers;
using EmployeeCrud.Common;
using EmployeeCrud.Common.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace EmployeeCrud.Test
{

    public class UnitTest1
    {
        #region Property  
        public Mock<IEmployeeService>? _mockEmployeeService;
        public Mock<IEmployeeRepository> mockIEmployeeRepository;

        private EmployeeController _employeeController;
        private Mock<ILogger<EmployeeController>> _logger;
        private readonly ITokenAuth _jwtAuth;
        #endregion
        public UnitTest1()
        {
            _logger = new Mock<ILogger<EmployeeController>>();

            _mockEmployeeService = new Mock<IEmployeeService>();
            _employeeController = new EmployeeController(_logger.Object, _mockEmployeeService.Object, _jwtAuth);

        }
        #region Get By Code  

        [Fact]
        public async void Task_GetEmployeeByID_Return_ResponseIEmployee()
        {
            //Arrange  
            _mockEmployeeService.Setup(p => p.GetEmployeeById(1)).ReturnsAsync(DummyDataDBInitializer.returnDummyData()[0]);
            //Act
            IActionResult actionResult = await _employeeController.GetByID(1);
            // Assert  
            OkObjectResult okObjectResult = Assert.IsType<OkObjectResult>(actionResult);
            Response<IEmployee> response = Assert.IsType<Response<IEmployee>>(okObjectResult.Value);
        }


        [Fact]
        public async void Task_GetEmployees_Returns_ResponseIEnumerableIEmployee()
        {
            //Arrange  
            _mockEmployeeService.Setup(p => p.GetEmployees()).ReturnsAsync(DummyDataDBInitializer.returnDummyData());
            //Act
            IActionResult actionResult = await _employeeController.GetAll();
            // Assert  
            OkObjectResult okObjectResult = Assert.IsType<OkObjectResult>(actionResult);

            Response<IEnumerable<IEmployee>> response = Assert.IsType<Response<IEnumerable<IEmployee>>>(okObjectResult.Value);


        }
        [Fact]
        public async void Task_Add_ValidData_Return_OkResult()
        {
            //Arrange
            var newEmployee = new Employee() { FirstName = "First Name test", LastName = "Last Name test", Phone = "122", JobTitle = "job test" };

            _mockEmployeeService.Setup(repo => repo.AddEmployee(newEmployee)).ReturnsAsync(true);

            //Act
            IActionResult actionResult = await _employeeController.AddEmployee(newEmployee);

            // Assert  
            OkObjectResult okObjectResult = Assert.IsType<OkObjectResult>(actionResult);
            Response<string> response = Assert.IsType<Response<string>>(okObjectResult.Value);
        }
        [Fact]
        public async void Task_Delete_Return_OkResult()
        {
            //Arrange
            var id = 1;


            _mockEmployeeService.Setup(repo => repo.DeleteEmployee(id)).ReturnsAsync(true);


            //Act
            IActionResult actionResult = await _employeeController.DeleteEmployee(id);

            // Assert  
            OkObjectResult okObjectResult = Assert.IsType<OkObjectResult>(actionResult);
            Response<string> response = Assert.IsType<Response<string>>(okObjectResult.Value);
        }
        #endregion
    }
}