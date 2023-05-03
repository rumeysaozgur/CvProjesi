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
    public class IsDeneyimiController : Controller
    {
        private readonly cvweb2Context _context;

        public IsDeneyimiController()
        {
            _context = new cvweb2Context();
        }

        // GET: IsDeneyimi
        public async Task<IActionResult> Index()
        {
            var cvweb2Context = _context.IsDeneyimis.Include(i => i.Kullanici);
            return View(await cvweb2Context.ToListAsync());
        }

        // GET: IsDeneyimi/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.IsDeneyimis == null)
            {
                return NotFound();
            }

            var isDeneyimi = await _context.IsDeneyimis
                .Include(i => i.Kullanici)
                .FirstOrDefaultAsync(m => m.IsId == id);
            if (isDeneyimi == null)
            {
                return NotFound();
            }

            return View(isDeneyimi);
        }

        // GET: IsDeneyimi/Create
        public IActionResult Create()
        {
            ViewData["KullaniciId"] = new SelectList(_context.KisiselBilgi, "KullaniciId", "KullaniciId");
            return View();
        }

        // POST: IsDeneyimi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IsId,KullaniciId,IsUnvani,Sehir,Ilce,BaslangicTarihi,BitisTarihi,Aciklama")] IsDeneyimi isDeneyimi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(isDeneyimi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KullaniciId"] = new SelectList(_context.KisiselBilgi, "KullaniciId", "KullaniciId", isDeneyimi.KullaniciId);
            return View(isDeneyimi);
        }

        // GET: IsDeneyimi/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.IsDeneyimis == null)
            {
                return NotFound();
            }

            var isDeneyimi = await _context.IsDeneyimis.FindAsync(id);
            if (isDeneyimi == null)
            {
                return NotFound();
            }
            ViewData["KullaniciId"] = new SelectList(_context.KisiselBilgi, "KullaniciId", "KullaniciId", isDeneyimi.KullaniciId);
            return View(isDeneyimi);
        }

        // POST: IsDeneyimi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("IsId,KullaniciId,IsUnvani,Sehir,Ilce,BaslangicTarihi,BitisTarihi,Aciklama")] IsDeneyimi isDeneyimi)
        {
            if (id != isDeneyimi.IsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(isDeneyimi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IsDeneyimiExists(isDeneyimi.IsId))
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
            ViewData["KullaniciId"] = new SelectList(_context.KisiselBilgi, "KullaniciId", "KullaniciId", isDeneyimi.KullaniciId);
            return View(isDeneyimi);
        }

        // GET: IsDeneyimi/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.IsDeneyimis == null)
            {
                return NotFound();
            }

            var isDeneyimi = await _context.IsDeneyimis
                .Include(i => i.Kullanici)
                .FirstOrDefaultAsync(m => m.IsId == id);
            if (isDeneyimi == null)
            {
                return NotFound();
            }

            return View(isDeneyimi);
        }

        // POST: IsDeneyimi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.IsDeneyimis == null)
            {
                return Problem("Entity set 'cvweb2Context.IsDeneyimis'  is null.");
            }
            var isDeneyimi = await _context.IsDeneyimis.FindAsync(id);
            if (isDeneyimi != null)
            {
                _context.IsDeneyimis.Remove(isDeneyimi);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IsDeneyimiExists(long id)
        {
          return (_context.IsDeneyimis?.Any(e => e.IsId == id)).GetValueOrDefault();
        }
    }
}
