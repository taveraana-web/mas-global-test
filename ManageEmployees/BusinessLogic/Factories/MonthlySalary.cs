
namespace ManageEmployees.BusinessLogic.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ManageEmployees.Entities;

    public class MonthlySalary : ISalary
    {
        public double CalculteAnnualSalary(Employee employee)
        {
            double annualSalary = 0;

            try
            {
                annualSalary = employee.MonthlySalary * 12;
            }
            catch (Exception)
            {

                throw;
            }

            return annualSalary;
        }
    }
}
