using Microsoft.AspNetCore.Mvc;

namespace cvProjesi.Controllers.Admin
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
