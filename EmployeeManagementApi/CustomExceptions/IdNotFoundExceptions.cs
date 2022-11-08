using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementApi.CustomExceptions
{ 
        public class IdNotFoundException : Exception
        {
          public IdNotFoundException(string message) : base(message)
          {

          }
        }
    
}
