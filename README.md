1-Using Visual Studio 2022 and .NET Core 6 SDK
2- Entity framework code first, the project is EmployeeCrud.Data so using Package console manager
 we need to run a- add-migration -s EmployeeCrud.API -p EmployeeCrud.Data
                b- Update-Database -s EmployeeCrud.API -p EmployeeCrud.Data
 because there are more than Startup.cs file

 3-For running API  , there is a swagger UI for all APIs ==>https://localhost:7282/swagger 
 3.1- For running Admin API a- run /api/Admin/authentication using this body to generate token to use for running Admin APIs { "userName": "Admin", "password": "Admin12345" } b- Click on authorize button then write Bearer +generated token c- then running any API 
 4- Using Serilog for logs 
