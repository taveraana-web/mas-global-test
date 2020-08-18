
namespace ManageEmployees.DataAccess.Interfaces
{
    using ManageEmployees.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IEmployeeAccess
    {
        List<Employee> Get();
    }
}
