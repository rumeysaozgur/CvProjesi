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
        public IActionResult Register(KisiselBilgi user)
        {
            if (ModelState.IsValid)
            {
                _context.KisiselBilgi.Add(user);

                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View(user);
        }

    }

    }


    
