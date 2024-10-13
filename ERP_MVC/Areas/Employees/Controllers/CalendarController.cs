using Microsoft.AspNetCore.Mvc;

namespace ERP_MVC.Areas.Employees.Controllers
{
    [Area("Employees")]
    public class CalendarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
