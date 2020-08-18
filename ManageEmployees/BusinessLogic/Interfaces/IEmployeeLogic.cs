namespace ManageEmployees.BusinessLogic.Interfaces
{
    using ManageEmployees.Entities;
    using System.Collections.Generic;

    public interface IEmployeeLogic
    {
        List<Employee> Get();
        Employee Get(int id);
    }
}
