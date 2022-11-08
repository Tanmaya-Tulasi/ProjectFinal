using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementApi.CustomExceptions
{
    public class DesignationFoundException:Exception
    {
        public DesignationFoundException(string message) : base(message)
        {

        }
    }
}
