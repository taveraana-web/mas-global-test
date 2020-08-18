namespace Services.Controllers
{
    using ManageEmployees.BusinessLogic.Interfaces;
    using ManageEmployees.Entities;
    using System.Collections.Generic;
    using System.Web.Http;
    using System.Web.Http.Cors;

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeLogic employeeLogic;

        public EmployeeController(IEmployeeLogic employeeLogic)
        {

            this.employeeLogic = employeeLogic;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            List<Employee> listEmployees = null;
            try
            {
                listEmployees = this.employeeLogic.Get();
            }
            catch (System.Exception)
            {
                //TODO: implement exception handling
            }
            return Ok(listEmployees);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            Employee employee = null;
            try
            {
                employee = this.employeeLogic.Get(id);
            }
            catch (System.Exception)
            {
                //TODO: implement exception handling
            }
            return Ok(employee);
        }
    }
}
