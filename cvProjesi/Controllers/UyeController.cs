using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using cvProjesi.Models;

namespace cvProjesi.Controllers
{
    public class UyeController : Controller
    {

        private readonly cvweb2Context _context;

        public object FormsAuthentication { get; private set; }

        public UyeController()
        {
            _context = new cvweb2Context();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(YeniKayit user)
        {
            if (ModelState.IsValid)
            {
                _context.YeniKayits.Add(user);
                KisiselBilgi kisisel = new KisiselBilgi();
                string[] adsoyad = user.AdSoyad.Split(' ');
                //if (adsoyad.Length > ) { 
                //kisisel.Ad = adsoyad[0] + adsoyad[1];
                //kisisel.Soyad = adsoyad[2];
                //}else
                //{
                    kisisel.Ad = adsoyad[0];
                    kisisel.Soyad = adsoyad[1];
                //}
                 
                kisisel.EPosta=user.Eposta;
                _context.KisiselBilgi.Add(kisisel);

                _context.SaveChanges();
                return RedirectToAction("Login", "Login");
            }

            return View(user);
        }

    }

    }


    
