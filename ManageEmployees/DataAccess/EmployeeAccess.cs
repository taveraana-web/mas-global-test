
namespace ManageEmployees.DataAccess
{
    using ManageEmployees.DataAccess.Entities;
    using ManageEmployees.DataAccess.Interfaces;
    using ManageEmployees.Entities;
    using Newtonsoft.Json;
    using RestSharp;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Net.Http;
    using Utilities.Constants;

    public class EmployeeAccess : IEmployeeAccess
    {

        static HttpClient client = new HttpClient();

        public List<Employee> Get()
        {
            List<Employee> employeesList = new List<Employee>();
            RestClient client = new RestClient(new Uri(ConfigurationManager.AppSettings[ConfigKey.EMPLOYEES_SERVICE_URL]));
            RestRequest request = new RestRequest(ConfigurationManager.AppSettings[ConfigKey.EMPLOYEES_SERVICE_ITEMS], Method.GET);
            var response = client.Execute(request);
            var employees = JsonConvert.DeserializeObject<IEnumerable<EmployeeResponse>>(response.Content);

            foreach (var employee in employees)
            {
                employeesList.Add(new Employee
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    ContractTypeName = employee.ContractTypeName,
                    RoleId = employee.RoleId,
                    RoleName = employee.RoleName,
                    RoleDescription = employee.RoleDescription == null ? string.Empty : employee.RoleDescription,
                    HourlySalary = employee.HourlySalary,
                    MonthlySalary = employee.MonthlySalary,
                });
            }
            return employeesList;
        }
    }
}
