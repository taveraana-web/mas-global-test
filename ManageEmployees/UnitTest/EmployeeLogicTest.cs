using System;
using ManageEmployees.DataAccess.Interfaces;
using ManageEmployees.BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using ManageEmployees.Entities;

namespace ManageEmployees.UnitTest
{
    [TestClass]
    public class EmployeeLogicTest
    {
        [TestMethod]
        public void ReturnAllEmployees()
        {
            Employee employee = new Employee
            {
                Id = 1,
                Name = "Ana",
                ContractTypeName = "HourlySalaryEmployee",
                RoleId = 1,
                RoleName = "Administrator",
                RoleDescription = "fgdgvd",
                HourlySalary = 10000,
                MonthlySalary = 2000000
            };
            List<Employee> employeesList = new List<Employee>();
            employeesList.Add(employee);

            var mockEmployeeAccess = new Mock<IEmployeeAccess>();
            mockEmployeeAccess.Setup(ea => ea.Get()).Returns(employeesList);
            var logic = new EmployeeLogic(mockEmployeeAccess.Object);
            var respuesta = logic.Get();
            Assert.IsNotNull(respuesta);
            Assert.IsTrue(respuesta.Count() > 0);
        }

        [TestMethod]
        public void ReturnsAnEmployeeById()
        {
            Employee employee = new Employee
            {
                Id = 2,
                Name = "Ana",
                ContractTypeName = "HourlySalaryEmployee",
                RoleId = 1,
                RoleName = "Administrator",
                RoleDescription = "fgdgvd",
                HourlySalary = 10000,
                MonthlySalary = 2000000
            };
            List<Employee> employeesList = new List<Employee>();
            employeesList.Add(employee);

            var mockEmployeeAccess = new Mock<IEmployeeAccess>();
            mockEmployeeAccess.Setup(ea => ea.Get()).Returns(employeesList);
            var logic = new EmployeeLogic(mockEmployeeAccess.Object);
            var respuesta = logic.Get(2);
            Assert.IsNotNull(respuesta);
        }

        [TestMethod]
        public void NoFoundEmployess()
        {
            var mockEmployeeAccess = new Mock<IEmployeeAccess>();

            List<Employee> employeesList = new List<Employee>();
            mockEmployeeAccess.Setup(ea => ea.Get()).Returns(employeesList);
            var logic = new EmployeeLogic(mockEmployeeAccess.Object);
            var respuesta = logic.Get();
            Assert.IsNotNull(respuesta);
            Assert.IsTrue(respuesta.Count() == 0);
        }

        [TestMethod]
        public void NoFoundEmployeeById()
        {
            Employee employee = new Employee
            {
                Id = 2,
                Name = "Ana",
                ContractTypeName = "HourlySalaryEmployee",
                RoleId = 1,
                RoleName = "Administrator",
                RoleDescription = "fgdgvd",
                HourlySalary = 10000,
                MonthlySalary = 2000000
            };
            List<Employee> employeesList = new List<Employee>();
            employeesList.Add(employee);

            var mockEmployeeAccess = new Mock<IEmployeeAccess>();
            mockEmployeeAccess.Setup(ea => ea.Get()).Returns(employeesList);
            var logic = new EmployeeLogic(mockEmployeeAccess.Object);
            var respuesta = logic.Get(1);
            Assert.IsNull(respuesta);
        }
    }
}
