using EmployeeCrud.API;

var builder = WebApplication.CreateBuilder(args);


var startup = new Startup(builder.Configuration);
startup.RegisterServices(builder.Services);

var app = builder.Build();
startup.SetupMiddlewares(app, builder.Environment);
