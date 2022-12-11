
namespace EmployeeCrud.Common
{
    public interface IUserRepository
    {
        Task<bool> Login(string name, string password);
    }
}
