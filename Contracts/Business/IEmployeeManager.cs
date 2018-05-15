using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Business
{
    public interface IEmployeeManager
    {
        Task<string> GetEmployeeData();
    }
}
