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
    public class BasarilarController : Controller
    {
        private readonly cvweb2Context _context;

        public BasarilarController()
        {
            _context = new cvweb2Context();
        }

        // GET: Basarilars
        public async Task<IActionResult> Index()
        {
            var cvweb2Context = _context.Basarilars.Include(b => b.Kullanici);
            return View(await cvweb2Context.ToListAsync());
        }

        // GET: Basarilars/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Basarilars == null)
            {
                return NotFound();
            }

            var basarilar = await _context.Basarilars
                .Include(b => b.Kullanici)
                .FirstOrDefaultAsync(m => m.BasariId == id);
            if (basarilar == null)
            {
                return NotFound();
            }

            return View(basarilar);
        }

        // GET: Basarilars/Create
        public IActionResult Create()
        {
            ViewData["KullaniciId"] = new SelectList(_context.KisiselBilgi, "KullaniciId", "KullaniciId");
            return View();
        }

        // POST: Basarilars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BasariId,KullaniciId,BBasligi,Aciklama")] Basarilar basarilar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(basarilar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KullaniciId"] = new SelectList(_context.KisiselBilgi, "KullaniciId", "KullaniciId", basarilar.KullaniciId);
            return View(basarilar);
        }

        // GET: Basarilars/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Basarilars == null)
            {
                return NotFound();
            }

            var basarilar = await _context.Basarilars.FindAsync(id);
            if (basarilar == null)
            {
                return NotFound();
            }
            ViewData["KullaniciId"] = new SelectList(_context.KisiselBilgi, "KullaniciId", "KullaniciId", basarilar.KullaniciId);
            return View(basarilar);
        }

        // POST: Basarilars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("BasariId,KullaniciId,BBasligi,Aciklama")] Basarilar basarilar)
        {
            if (id != basarilar.BasariId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(basarilar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BasarilarExists(basarilar.BasariId))
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
            ViewData["KullaniciId"] = new SelectList(_context.KisiselBilgi, "KullaniciId", "KullaniciId", basarilar.KullaniciId);
            return View(basarilar);
        }

        // GET: Basarilars/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Basarilars == null)
            {
                return NotFound();
            }

            var basarilar = await _context.Basarilars
                .Include(b => b.Kullanici)
                .FirstOrDefaultAsync(m => m.BasariId == id);
            if (basarilar == null)
            {
                return NotFound();
            }

            return View(basarilar);
        }

        // POST: Basarilars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Basarilars == null)
            {
                return Problem("Entity set 'cvweb2Context.Basarilars'  is null.");
            }
            var basarilar = await _context.Basarilars.FindAsync(id);
            if (basarilar != null)
            {
                _context.Basarilars.Remove(basarilar);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BasarilarExists(long id)
        {
          return (_context.Basarilars?.Any(e => e.BasariId == id)).GetValueOrDefault();
        }
    }
}
