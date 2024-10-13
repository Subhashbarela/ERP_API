using Microsoft.AspNetCore.Mvc;

namespace ERP_MVC.Areas.Employees.Controllers
{
    [Area("Employees")]
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyProfile()
        {
            return View();
        }
    }
}
