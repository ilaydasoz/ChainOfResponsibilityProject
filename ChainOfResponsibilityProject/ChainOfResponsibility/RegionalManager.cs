using System;
using ChainOfResponsibilityProject.DAL.Context;
using ChainOfResponsibilityProject.DAL.Entities;

namespace ChainOfResponsibilityProject.ChainOfResponsibility
{
    public class RegionalManager : Employee
    {
        public override void ProcessRequest(WithdrawViewModel req)
        {
            if (req.Amount <= 250000)
            {
                using (var context = new Context())
                {
                    BankProcess bankProcess = new BankProcess();
                    bankProcess.EmployeeName = "Regional Manager - İlayda Söz Yılmaz";
                    bankProcess.Description = "The amount requested by the customer was paid.";
                    bankProcess.Amount = req.Amount;
                    bankProcess.CustomerName = req.CustomerName;
                    context.BankProcesses.Add(bankProcess);
                    context.SaveChanges();
                }
            }
            else if (NextApprover != null)
            {
                using (var context = new Context())
                {
                    BankProcess bankProcess = new BankProcess();
                    bankProcess.EmployeeName = "Regional Manager - İlayda Söz Yılmaz";
                    bankProcess.Description = "Since the amount requested by the customer is above the bank's daily withdrawal limit, it was rejected.";
                    bankProcess.Amount = req.Amount;
                    bankProcess.CustomerName = req.CustomerName;
                    context.BankProcesses.Add(bankProcess);
                    context.SaveChanges();                 
                }
            }
        }
    }
}
