using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementApi.CustomExceptions
{
    public class IdFoundException:Exception
    {
        public IdFoundException(string message) : base(message)
        {

        }
    }
}
