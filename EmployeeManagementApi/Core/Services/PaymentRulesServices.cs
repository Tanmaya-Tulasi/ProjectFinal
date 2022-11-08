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
    public class PaymentRulesServices:IPaymentRulesServices
    {
        EmployeeDBContext dbContext;
        public PaymentRulesServices(EmployeeDBContext _db)
        {
            dbContext = _db;
        }
        public IEnumerable<PaymentRules> GetDetails()
        {
            try
            {
                var rule = dbContext.PaymentRules.ToList();
                if (rule != null)
                {
                    return rule;
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
        public PaymentRules GetDetailsById(int id)
        {
            try
            {
                var rule = dbContext.PaymentRules.FirstOrDefault(x => x.Id == id);
                if (rule != null)
                {
                    return rule;
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
        public string AddPaymentRule(PaymentRules paymentRules)
        {
            if (paymentRules != null)
            {
                try
                {
                    dbContext.PaymentRules.Add(paymentRules);
                    dbContext.SaveChanges();
                    return "1";
                }
                catch
                {
                    try
                    {

                        throw new IdFoundException("ID is already Present");
                    }
                    catch (IdFoundException e)
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
        public string UpdatePaymentRule(PaymentRules paymentRules)
        {
                if (paymentRules != null)
                {
                    try
                    {
                        dbContext.Entry(paymentRules).State = EntityState.Modified;
                        dbContext.SaveChanges();

                        return "1";
                    }
                    catch
                    {
                        try
                        {

                            throw new IdNotFoundException("PaymentRule is not present to Update their Details");
                        }
                        catch (IdNotFoundException ex)
                        {
                            return ex.Message;
                        }
                    }


                }
                return null;

        }
           


        public string DeletePaymentRule(int id)
        {
            try
            {
                var rule = dbContext.PaymentRules.FirstOrDefault(x =>x.Id == id);
                if (rule != null)
                {
                    dbContext.Remove(rule);
                    dbContext.SaveChanges();

                    return "1";
                }
                else
                {
                    throw new IdNotFoundException("PaymentRule is not present to Delete");
                }


            }
            catch (IdNotFoundException ex)
            {
                return ex.Message;
            }
           
        }
    }
}
