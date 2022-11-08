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
    public class WorkingHourServices:IWorkingHourServices
    {
        EmployeeDBContext dbContext;
        public WorkingHourServices(EmployeeDBContext _db)
        {
            dbContext = _db;
        }
        public IEnumerable<WorkingHour> GetWorkingHourDetails()
        {
            try
            {
                var hour = dbContext.WorkingHour.ToList();
                if(hour != null)
                {
                    return hour;
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
        public WorkingHour GetWorkingHourDetailsById(string id)
        {
            try
            {
                var hour = dbContext.WorkingHour.FirstOrDefault(x => x.Empid == id);
                if (hour != null)
                {
                    return hour;
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
        public string AddWorkingHour(WorkingHour hour)
        {
            if (hour != null)
            {
                try
                {
                    dbContext.WorkingHour.Add(hour);
                    dbContext.SaveChanges();
                    return "1";
                }
                catch
                {
                    try
                    {

                        throw new NoDesignationFoundException("EmployeeId is not present");
                    }
                    catch (NoDesignationFoundException e)
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
        public string UpdateWorkingHour(WorkingHour hour)
        {
                if (hour != null)
                {
                    try
                    {
                        dbContext.Entry(hour).State = EntityState.Modified;
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

        public string DeleteWorkingHour(string id)
        {
            try
            {
                var hour = dbContext.WorkingHour.FirstOrDefault(x => x.Empid == id);
                if (hour != null)
                {
                    dbContext.Remove(hour);
                    dbContext.SaveChanges();
                    return "1";
                }
                else
                {
                    throw new IdNotFoundException("Employee is not present to Delete");
                }


            }
            catch (IdNotFoundException ex)
            {
                return ex.Message;
            }
           
        }
    }
}
