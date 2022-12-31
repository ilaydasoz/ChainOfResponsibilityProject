using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChainOfResponsibilityProject.ChainOfResponsibility;
using ChainOfResponsibilityProject.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ChainOfResponsibilityProject.Controllers
{
    public class DefaultController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(BankProcess p)
        {
            Employee treasurer = new Treasurer();
            Employee asistantManager = new AssistantManager();
            Employee manager = new Manager();
            Employee regionalManager = new RegionalManager();

            treasurer.SetNextApprover(asistantManager);
            asistantManager.SetNextApprover(manager);
            manager.SetNextApprover(regionalManager);

            treasurer.ProcessRequest(p);

            return View();
        }
    }
}
