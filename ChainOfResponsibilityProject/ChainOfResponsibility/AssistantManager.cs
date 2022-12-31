using System;
using ChainOfResponsibilityProject.DAL.Context;
using ChainOfResponsibilityProject.DAL.Entities;

namespace ChainOfResponsibilityProject.ChainOfResponsibility
{
    public class AssistantManager : Employee
    {
        public override void ProcessRequest(WithdrawViewModel req)
        {
            if (req.Amount <= 70000)
            {
                using (var context = new Context())
                {
                    BankProcess bankProcess = new BankProcess();
                    bankProcess.EmployeeName = "Assistant Manager - Deniz Gök";
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
                    bankProcess.EmployeeName = "Assistant Manager - Deniz Gök";
                    bankProcess.Description = "Since the amount requested by the customer was not within the authority, the transaction was sent to the Manager.";
                    bankProcess.Amount = req.Amount;
                    bankProcess.CustomerName = req.CustomerName;
                    context.BankProcesses.Add(bankProcess);
                    context.SaveChanges();
                    NextApprover.ProcessRequest(req);
                }
            }
        }
    }
}
