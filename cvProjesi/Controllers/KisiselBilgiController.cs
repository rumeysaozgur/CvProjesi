using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using cvProjesi.Models;

namespace cvProjesi.Controllers.Admin
{
    public class KisiselBilgiController : Controller
    {
        private readonly cvweb2Context _context;

        public KisiselBilgiController()
        {
            _context = new cvweb2Context();
        }

        // GET: KisiselBilgi
        public async Task<IActionResult> Index()
        {
              return _context.KisiselBilgi != null ? 
                          View(await _context.KisiselBilgi.ToListAsync()) :
                          Problem("Entity set 'cvweb2Context.KisiselBilgi'  is null.");
        }

        // GET: KisiselBilgi/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.KisiselBilgi == null)
            {
                return NotFound();
            }

            var kisiselBilgi = await _context.KisiselBilgi
                .FirstOrDefaultAsync(m => m.KullaniciId == id);
            if (kisiselBilgi == null)
            {
                return NotFound();
            }

            return View(kisiselBilgi);
        }

        // GET: KisiselBilgi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KisiselBilgi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KullaniciId,Ad,Soyad,EPosta,Telefon,Adres,PostaKodu,Sehir,Ilce,Resim,DogumTarihi,DogumYeri,SurucuEhliyeti,Cinsiyet,AskerlikDurumu,MedeniDurumu,Linkedn,Websitesi,UyeSifresi")] KisiselBilgi kisiselBilgi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kisiselBilgi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kisiselBilgi);
        }

        // GET: KisiselBilgi/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.KisiselBilgi == null)
            {
                return NotFound();
            }

            var kisiselBilgi = await _context.KisiselBilgi.FindAsync(id);
            if (kisiselBilgi == null)
            {
                return NotFound();
            }
            return View(kisiselBilgi);
        }

        // POST: KisiselBilgi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("KullaniciId,Ad,Soyad,EPosta,Telefon,Adres,PostaKodu,Sehir,Ilce,Resim,DogumTarihi,DogumYeri,SurucuEhliyeti,Cinsiyet,AskerlikDurumu,MedeniDurumu,Linkedn,Websitesi,UyeSifresi")] KisiselBilgi kisiselBilgi)
        {
            if (id != kisiselBilgi.KullaniciId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kisiselBilgi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KisiselBilgiExists(kisiselBilgi.KullaniciId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(kisiselBilgi);
        }

        // GET: KisiselBilgi/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.KisiselBilgi == null)
            {
                return NotFound();
            }

            var kisiselBilgi = await _context.KisiselBilgi
                .FirstOrDefaultAsync(m => m.KullaniciId == id);
            if (kisiselBilgi == null)
            {
                return NotFound();
            }

            return View(kisiselBilgi);
        }

        // POST: KisiselBilgi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.KisiselBilgi == null)
            {
                return Problem("Entity set 'cvweb2Context.KisiselBilgi'  is null.");
            }
            var kisiselBilgi = await _context.KisiselBilgi.FindAsync(id);
            if (kisiselBilgi != null)
            {
                _context.KisiselBilgi.Remove(kisiselBilgi);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KisiselBilgiExists(long id)
        {
          return (_context.KisiselBilgi?.Any(e => e.KullaniciId == id)).GetValueOrDefault();
        }
    }
}
