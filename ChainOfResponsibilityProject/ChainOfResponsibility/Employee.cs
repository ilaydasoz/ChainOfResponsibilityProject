using System;
using ChainOfResponsibilityProject.DAL.Entities;


namespace ChainOfResponsibilityProject.ChainOfResponsibility
{
    public abstract class Employee
    {
        protected Employee NextApprover;

        public void SetNextApprover(Employee supervisor)
        {
            this.NextApprover = supervisor;
        }

        public abstract void ProcessRequest(WithdrawViewModel req);

    }
}
