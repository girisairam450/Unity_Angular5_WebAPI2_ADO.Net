using Contracts.Business;
using Services_WebApi2.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace API_Services.Controllers
{
    public class EmployeeController : BaseApiController
    {
        private readonly IEmployeeManager employeeManager;
        public EmployeeController(IEmployeeManager employeeManager)
        {
            this.employeeManager = employeeManager;
        }
        [HttpGet]
        [Route("api/Employee")]
        public async Task<IHttpActionResult> GetMasterData()
        {
            return await GetSingleAsync(() => employeeManager.GetEmployeeData());
        }

    }
}