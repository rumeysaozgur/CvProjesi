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
    public class EgitimlerController : Controller
    {
        private readonly cvweb2Context _context;

        public EgitimlerController()
        {
            _context = new cvweb2Context();
        }

        // GET: Egitimler
        public async Task<IActionResult> Index()
        {
            var cvweb2Context = _context.Egitimlers.Include(e => e.Kullanici);
            return View(await cvweb2Context.ToListAsync());
        }

        // GET: Egitimler/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Egitimlers == null)
            {
                return NotFound();
            }

            var egitimler = await _context.Egitimlers
                .Include(e => e.Kullanici)
                .FirstOrDefaultAsync(m => m.EgitimId == id);
            if (egitimler == null)
            {
                return NotFound();
            }

            return View(egitimler);
        }

        // GET: Egitimler/Create
        public IActionResult Create()
        {
            ViewData["KullaniciId"] = new SelectList(_context.KisiselBilgi, "KullaniciId", "KullaniciId");
            return View();
        }

        // POST: Egitimler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EgitimId,KullaniciId,EgitimAd,EgitimTuru,DereceSertifika,Sehir,Ilce,Okul,BaslangicTarihi,BitisTarihi,Aciklama")] Egitimler egitimler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(egitimler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KullaniciId"] = new SelectList(_context.KisiselBilgi, "KullaniciId", "KullaniciId", egitimler.KullaniciId);
            return View(egitimler);
        }

        // GET: Egitimler/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Egitimlers == null)
            {
                return NotFound();
            }

            var egitimler = await _context.Egitimlers.FindAsync(id);
            if (egitimler == null)
            {
                return NotFound();
            }
            ViewData["KullaniciId"] = new SelectList(_context.KisiselBilgi, "KullaniciId", "KullaniciId", egitimler.KullaniciId);
            return View(egitimler);
        }

        // POST: Egitimler/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("EgitimId,KullaniciId,EgitimAd,EgitimTuru,DereceSertifika,Sehir,Ilce,Okul,BaslangicTarihi,BitisTarihi,Aciklama")] Egitimler egitimler)
        {
            if (id != egitimler.EgitimId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(egitimler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EgitimlerExists(egitimler.EgitimId))
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
            ViewData["KullaniciId"] = new SelectList(_context.KisiselBilgi, "KullaniciId", "KullaniciId", egitimler.KullaniciId);
            return View(egitimler);
        }

        // GET: Egitimler/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Egitimlers == null)
            {
                return NotFound();
            }

            var egitimler = await _context.Egitimlers
                .Include(e => e.Kullanici)
                .FirstOrDefaultAsync(m => m.EgitimId == id);
            if (egitimler == null)
            {
                return NotFound();
            }

            return View(egitimler);
        }

        // POST: Egitimler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Egitimlers == null)
            {
                return Problem("Entity set 'cvweb2Context.Egitimlers'  is null.");
            }
            var egitimler = await _context.Egitimlers.FindAsync(id);
            if (egitimler != null)
            {
                _context.Egitimlers.Remove(egitimler);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EgitimlerExists(long id)
        {
          return (_context.Egitimlers?.Any(e => e.EgitimId == id)).GetValueOrDefault();
        }
    }
}
