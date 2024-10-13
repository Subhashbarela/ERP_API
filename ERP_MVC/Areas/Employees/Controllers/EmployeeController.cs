using Microsoft.AspNetCore.Mvc;

namespace ERP_MVC.Areas.Employees.Controllers
{
    [Area("Employees")]
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ViewEmployeeDetails(int id)
        {
            return View();
        }

    }
}
