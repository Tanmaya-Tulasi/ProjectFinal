using EmployeeManagementApi.Core.IServices;
using EmployeeManagementApi.CustomExceptions;
using EmployeeManagementApi.Models;
using Microsoft.EntityFrameworkCore;
using MobileAppApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementApi.Core.Services
{
    public class EmployeeServices:IEmployeeServices
    {
        EmployeeDBContext dbContext;
        public EmployeeServices(EmployeeDBContext _db)
        {
            dbContext = _db;
        }
        public IEnumerable<Employee> GetDetails()
        {
            try
            {
                var employee = dbContext.Employee.ToList();
                if (employee != null)
                {
                    return employee;
                }
                else
                {
                    throw new RecordNotFoundException("No records Found");
                }
            }
            catch(RecordNotFoundException)
            {
                return null;
            }

        }
        public Employee GetDetailsById(string id)
        {
            try
            {
                var employee = dbContext.Employee.FirstOrDefault(x => x.Empid == id);
                if (employee != null)
                {
                    return employee;
                }
                else
                {
                    throw new RecordNotFoundException("Record not found");
                }

            }
            catch(RecordNotFoundException)
            {
                return null;
            }
        }
        public string AddEmployee(Employee employee)
        {
           
           if (employee != null)
           {
                try
                {
                    dbContext.Employee.Add(employee);
                    dbContext.SaveChanges();
                    return "1";
                }
                catch
                {
                    try
                    {

                        throw new NoDesignationFoundException("Entered Designation is not present in the company ..Please Enter valid Designation");
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
        public string UpdateEmployee(Employee employee)
        {
            try
            {
                if (employee != null)
                {
                    try
                    {
                        dbContext.Entry(employee).State = EntityState.Modified;
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
            catch
            {
                throw;
            }
           

        }

        public string DeleteEmployee(string id)
        {
            try
            {
                var employee = dbContext.Employee.FirstOrDefault(x => x.Empid == id);
                if (employee != null)
                {
                    dbContext.Remove(employee);
                    dbContext.SaveChanges();
                    return "1";
                }
                else
                {
                   throw new IdNotFoundException("Employee is not present to Delete");
                }
                

            }
            catch(IdNotFoundException ex)
            {
                return ex.Message;
            }
        }


        public string signin(LoginDTO loginDTO)
        {
            try
            {

                var login = dbContext.Employee.FirstOrDefault(x => x.Empid == loginDTO.Empid && x.Password == loginDTO.Password);
                if (login != null)
                {
                   
                    return "success";
                }
                else
                {
                    return null;
                }

            }
            catch
            {
                throw;
            }

        }
    }
   
   
  
}
