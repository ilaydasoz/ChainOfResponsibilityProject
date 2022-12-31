using System;
using ChainOfResponsibilityProject.DAL.Context;
using ChainOfResponsibilityProject.DAL.Entities;

namespace ChainOfResponsibilityProject.ChainOfResponsibility
{
    public class Treasurer : Employee
    {
        public override void ProcessRequest(WithdrawViewModel req)
        {
            if (req.Amount <= 40000)
            {
                using (var context = new Context())
                {
                    BankProcess bankProcess = new BankProcess();
                    bankProcess.EmployeeName = "Treasurer - Sara Smith";
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
                    bankProcess.EmployeeName = "Treasurer - Sara Smith";
                    bankProcess.Description = "Since the amount requested by the customer was not within the authority, the transaction was sent to the Assistant Manager.";
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

/*The chain of responsibility design pattern is a behavioral design pattern that allows a request to be passed
 * through a chain of objects or components in a system, with 
 * each object or component having the option to either 
 * handle the request or pass it on to the next object in the chain. The goal of this pattern is to
 * decouple the sender of a request from its receiver, and to give multiple objects the opportunity to
 * handle the request in a modular way.*/
