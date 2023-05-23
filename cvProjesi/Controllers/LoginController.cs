
using cvProjesi.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

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
	



		[HttpPost]
		public async Task<IActionResult> LoginAsync([FromForm] YeniKayit p)
		{		
			var bilgiler =  db.YeniKayits.FirstOrDefault(x => x.Eposta == p.Eposta && x.Sifre == p.Sifre);        
			var bilgiler2 =  db.KisiselBilgi.FirstOrDefault(x => x.EPosta == bilgiler.Eposta);        
            if (bilgiler != null)
			{
                List<Claim> claims = new List<Claim>() {
                new Claim(ClaimTypes.NameIdentifier,p.Eposta),
                new Claim(ClaimTypes.GivenName,bilgiler.Id.ToString()),
                new Claim("OtherProperties","Admin"), 
                 new Claim(ClaimTypes.Sid,bilgiler2.KullaniciId.ToString())///id sini de claim e ekledik
                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true //,
                    //IsPersistent = p.Durum
                };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), properties);
                return RedirectToAction("Index", "Admin");
              
			}
			else
			{
				TempData["hata"] = "bilgileriniz yanlıştır tekrar giriniz";
				return RedirectToAction("Login","Login");
			}
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View("deneme");


        }
        public IActionResult deneme()
        {
            return View();


        }

        [HttpPost]
        public IActionResult Index(KisiselBilgi user)
        {
            if (ModelState.IsValid)
            {
                db.KisiselBilgi.Add(user);
                
                db.SaveChanges();
                return RedirectToAction("deneme", "Login");
            }

            return View(user);
        }

      

    }
}
