using cvProjesi.Models;
using Microsoft.AspNetCore.Mvc;

namespace cvProjesi.Controllers
{
    public class KullaniciController : Controller
    {
        private readonly cvweb2Context _context;

        public KullaniciController()
        {
            _context = new cvweb2Context();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Hakkinda()
        {
            return View();
        }
    }
}
