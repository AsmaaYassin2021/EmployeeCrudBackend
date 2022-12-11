
using EmployeeCrud.API.Authentication;
using EmployeeCrud.API.Model;
using EmployeeCrud.API.Wrappers;
using EmployeeCrud.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeCrud.API.Controllers
{
    [Route("api/Admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ILogger<AdminController> _logger;
        private readonly IEmployeeService _employeeService;

        private readonly ITokenAuth _jwtAuth;
        public AdminController(ILogger<AdminController> logger, IEmployeeService employeeService, ITokenAuth jwtAuth)
        {
            _logger = logger;
            _employeeService = employeeService;

            _jwtAuth = jwtAuth;
        }

        [AllowAnonymous]
        [HttpPost("authentication")]
        public async Task<IActionResult> Authentication([FromBody] User userCredential)
        {
            _logger.LogInformation($" Authentication for the user." + " " + userCredential.UserName);
            bool isUserCredentialCorrect = await _employeeService.Login(userCredential.UserName, userCredential.Password);
            if (isUserCredentialCorrect)
            {
                var token = _jwtAuth.Authentication(userCredential.UserName, userCredential.Password);
                if (token == null)
                    return Unauthorized(Response<string>.Fail("User name or password is incorrect "));
                return Ok(Response<string>.Success(token));
            }
            else
                return Unauthorized(Response<string>.Fail("User name or password is incorrect "));
        }
    }
}
