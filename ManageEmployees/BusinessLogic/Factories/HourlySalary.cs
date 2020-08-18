using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManageEmployees.Entities;

namespace ManageEmployees.BusinessLogic.Factories
{
    public class HourlySalary : ISalary
    {
        public double CalculteAnnualSalary(Employee employee)
        {
            double annualSalary = 0;

            try
            {
                annualSalary = 120 * employee.HourlySalary * 12;
            }
            catch (Exception)
            {

                throw;
            }

            return annualSalary;
        }
    }
}
