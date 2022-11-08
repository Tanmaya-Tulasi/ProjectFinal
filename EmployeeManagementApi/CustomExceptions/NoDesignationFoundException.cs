using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementApi.CustomExceptions
{
    public class NoDesignationFoundException:Exception
    {
        public NoDesignationFoundException(string message) : base(message)
        {

        }
    }
}
