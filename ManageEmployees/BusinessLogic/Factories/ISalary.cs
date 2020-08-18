using ManageEmployees.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageEmployees.BusinessLogic.Factories
{
    public interface ISalary
    {
        double CalculteAnnualSalary(Employee employee);
    }
}
