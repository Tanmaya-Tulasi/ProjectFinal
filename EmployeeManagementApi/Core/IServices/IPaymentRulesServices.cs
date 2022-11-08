using EmployeeManagementApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementApi.Core.IServices
{
    public interface IPaymentRulesServices
    {
        IEnumerable<PaymentRules> GetDetails();
        PaymentRules GetDetailsById(int id);
        string AddPaymentRule(PaymentRules paymentRules);
        string UpdatePaymentRule(PaymentRules paymentRules);
        string DeletePaymentRule(int id);

    }
}
