using Microsoft.AspNetCore.Mvc;

namespace ERP_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmployeesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ShowEmployeeList()
        {
            return View();
        }
       
    }
}
