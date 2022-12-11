using EmployeeCrud.Common.Contracts;
using EmployeeCrud.Test.Model;

namespace EmployeeCrud.Test
{
    internal class DummyDataDBInitializer
    {
        public static List<IEmployee> returnDummyData()
        {

            List<IEmployee> shipList = new List<IEmployee>();

            for (int i = 1; i <= 9; i++)
            {
                Employee c = new Employee();
                c.FirstName = "AAAA " + i.ToString(); ;
                c.LastName = "BBBB " + i.ToString(); ;
                c.Phone = "12345 " + i.ToString(); ;
                c.JobTitle = "Job " + i.ToString(); ;
                c.Id = i;
                shipList.Add(c);

            }
            return shipList;

        }
    }
}
