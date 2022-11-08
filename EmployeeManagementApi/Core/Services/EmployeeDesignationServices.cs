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

    public class EmployeeDesignationServices:IEmployeeDesignationServices
    {
        EmployeeDBContext dbContext;
        public EmployeeDesignationServices(EmployeeDBContext  _db)
        {
            dbContext = _db;
        }
        public IEnumerable<EmployeeDesignation> GetDetails()
        {
            try
            {
                var employee = dbContext.EmployeeDesignation.ToList();
                if (employee != null)
                {
                    return employee;
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
        public EmployeeDesignation GetDetailsByDesignation(string designation)
        {
            try
            {
                var employee = dbContext.EmployeeDesignation.FirstOrDefault(x => x.Designation == designation);

                if (employee != null)
                {
                    return employee;
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
        public string AddDesignation(EmployeeDesignation employeeDesignation)
        {
            if (employeeDesignation != null)
            {
                try
                {
                    dbContext.EmployeeDesignation.Add(employeeDesignation);
                    dbContext.SaveChanges();
                    return "1";
                }
                catch
                {
                    try
                    {

                        throw new DesignationFoundException("Designation is already present");
                    }
                    catch (DesignationFoundException e)
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
        public string UpdateDesignation(EmployeeDesignation employeeDesignation)
        {
                if (employeeDesignation != null)
                {
                    try
                    {

                        dbContext.Entry(employeeDesignation).State = EntityState.Modified;
                        dbContext.SaveChanges();

                        return "1";
                    }
                    catch
                    {
                        try
                        {

                            throw new IdNotFoundException("Designation is not present to Update their Details");
                        }
                        catch (IdNotFoundException ex)
                        {
                            return ex.Message;
                        }
                    }


                }
            return null;

        }

        public string DeleteDesignation(string designation)
        {
            try
            {
                var employee = dbContext.EmployeeDesignation.FirstOrDefault(x => x.Designation == designation);

                if (employee != null)
                {
                    dbContext.Remove(employee);
                    dbContext.SaveChanges();
                    return "1";
                }
                else
                {
                    throw new IdNotFoundException("Designation is not present to Delete");
                }


            }
            catch (IdNotFoundException ex)
            {
                return ex.Message;
            }
          
        }

    }
}
