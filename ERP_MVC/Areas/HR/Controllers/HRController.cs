using Microsoft.AspNetCore.Mvc;

namespace ERP_MVC.Areas.HR.Controllers
{
    public class HRController : Controller
    {
        public IActionResult HRDashboard()
        {
            //int employeeCount = _dbContext.Employees.Count();
            ////int clientCount = _dbContext.Clients.Count();

            //// Pass the counts to the view
            //ViewBag.EmployeeCount = employeeCount;
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
