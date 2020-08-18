
namespace ManageEmployees.BusinessLogic
{
    using ManageEmployees.BusinessLogic.Factories;
    using ManageEmployees.BusinessLogic.Interfaces;
    using ManageEmployees.DataAccess;
    using ManageEmployees.DataAccess.Interfaces;
    using ManageEmployees.Entities;
    using System.Collections.Generic;
    using System.Linq;
    using ManageEmployees.Utilities.Constants;

    public class EmployeeLogic : IEmployeeLogic
    {
        private readonly IEmployeeAccess employeeAccess;

        public EmployeeLogic(IEmployeeAccess employeeAccess)
        {
            this.employeeAccess = employeeAccess;
        }

        public List<Employee> Get()
        {
            List<Employee> employeesList = this.employeeAccess.Get();
            foreach (var employee in employeesList)
            {
                employee.AnnualSalary = CalculateSalary(employee);
            }
            return employeesList;
        }

        public Employee Get(int id)
        {
            Employee employee = null;
            List<Employee> employeesList = this.employeeAccess.Get();

            if (employeesList != null && employeesList.Count() > 0)
            {
                employee = employeesList.Find(emp => emp.Id == id);
                if (employee != null)
                {
                    employee.AnnualSalary = CalculateSalary(employee);
                }
            }
            return employee;
        }

        private double CalculateSalary(Employee employee)
        {
            ISalary salary = CreateSalary(employee.ContractTypeName);
            if (salary != null)
            {
                 return salary.CalculteAnnualSalary(employee);
            }
            return 0;
        }

        private static ISalary CreateSalary(string contractType)
        {
            ISalary salary = null;
            switch (contractType)
            {
                case ContractType.HOURLY_SALARY:
                    salary = new HourlySalary();
                    break;
                case ContractType.MONTHLY_SALARY:
                    salary = new MonthlySalary();
                    break;
            }
            return salary;
        }
    }
}
