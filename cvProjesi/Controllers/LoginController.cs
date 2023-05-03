
using cvProjesi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cvProjesi.Controllers
{
    public class LoginController : Controller
    {

		private readonly cvweb2Context db;
	

		public LoginController()
		{
			db = new cvweb2Context();
		
		}
		[HttpGet]
		public IActionResult Login()
        {
            return View();
        }
		public IActionResult Index()
		{
			return View();
		}



		[HttpPost]
		public IActionResult Login([FromForm] KisiselBilgi p)
		{		
			var bilgiler =  db.KisiselBilgi.FirstOrDefault(x => x.EPosta == p.EPosta && x.UyeSifresi == p.UyeSifresi);        
            if (bilgiler != null)
			{
				return RedirectToAction("Index","Login");
			}
			else
			{
				TempData["hata"] = "bilgileriniz yanlıştır tekrar giriniz";
				return RedirectToAction("Login","Login");
			}
        }

	}
}
