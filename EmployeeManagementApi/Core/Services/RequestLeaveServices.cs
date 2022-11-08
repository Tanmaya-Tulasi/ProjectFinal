using EmployeeManagementApi.Core.IServices;
using EmployeeManagementApi.CustomExceptions;
using EmployeeManagementApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementApi.Core.Services
{
    public class RequestLeaveServices:IRequestLeaveServices
    {
        EmployeeDBContext dbContext;
        public RequestLeaveServices(EmployeeDBContext _db)
        {
            dbContext = _db;
        }
        public IEnumerable<RequestLeave> GetLeaveDetails()
        {
            try
            {
                var leave = dbContext.RequestLeave.ToList();
                if (leave != null)
                {
                    return leave;
                }
                else
                {
                    throw new RecordNotFoundException("No records Found");
                }
            }
            catch (RecordNotFoundException)
            {
                return null;
            }
            
        }
        public RequestLeave GetLeaveDetailsById(string id)
        {
            try
            {
                var leave = dbContext.RequestLeave.FirstOrDefault(x => x.Empid == id);
                if (leave != null)
                {
                    return leave;
                }
                else
                {
                    throw new RecordNotFoundException("Record not found");
                }

            }
            catch (RecordNotFoundException)
            {
                return null;
            }
            

        }
        public string AddLeave(RequestLeave leave)
        {
            if (leave != null)
            {
                try
                {
                    dbContext.RequestLeave.Add(leave);
                    dbContext.SaveChanges();
                    return "1";
                }
                catch
                {
                    try
                    {

                        throw new IdNotFoundException("Entered EmployeeID is not present in the company ..Please Enter valid EmployeeID");
                    }
                    catch (IdNotFoundException e)
                    {
                        return e.Message;
                    }

                }


            }
            else
            {
                return null;
            }
           
        }
        public string UpdateLeave(RequestLeave leave)
        {
                if (leave != null)
                {
                    try
                    {
                        dbContext.Entry(leave).State = EntityState.Modified;
                        dbContext.SaveChanges();
                        return "1";
                    }
                    catch
                    {
                        try
                        {

                            throw new IdNotFoundException("Employee is not present to Update their Details");
                        }
                        catch (IdNotFoundException ex)
                        {
                            return ex.Message;
                        }
                    }


                }
                return null;

            }
            

        public string DeleteLeave(string id)
        {
        try
        {
            var leave = dbContext.RequestLeave.FirstOrDefault(x => x.Empid == id);
            if (leave != null)
            {
                dbContext.Remove(leave);
                dbContext.SaveChanges();

                return "1";
            }
            else
            {
                throw new IdNotFoundException("Record is not present to Delete");
            }


        }
        catch (IdNotFoundException ex)
        {
            return ex.Message;
        }
       
        }
    }
}
