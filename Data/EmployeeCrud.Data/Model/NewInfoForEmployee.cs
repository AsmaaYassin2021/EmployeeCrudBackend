using EmployeeCrud.Common.Contracts;

namespace EmployeeCrud.Data.Model
{
    public class NewInfoForEmployee : Employee, INewInfoForIEmployee
    {
        public string Address { get; set; }
    }
}
