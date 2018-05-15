using Contracts.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Managers
{
    public class EmployeeManager : IEmployeeManager
    {
        public Task<string> GetEmployeeData()
        {
            return  Task.Run(() => "Hello Giri");
        }
    }
}
