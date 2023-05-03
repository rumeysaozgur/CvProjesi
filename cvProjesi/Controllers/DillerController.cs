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
    public class DillerController : Controller
    {
        private readonly cvweb2Context _context;

        public DillerController()
        {
            _context = new cvweb2Context();
        }

        // GET: Diller
        public async Task<IActionResult> Index()
        {
            var cvweb2Context = _context.Dillers.Include(d => d.Kullanici);
            return View(await cvweb2Context.ToListAsync());
        }

        // GET: Diller/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Dillers == null)
            {
                return NotFound();
            }

            var diller = await _context.Dillers
                .Include(d => d.Kullanici)
                .FirstOrDefaultAsync(m => m.DilId == id);
            if (diller == null)
            {
                return NotFound();
            }

            return View(diller);
        }

        // GET: Diller/Create
        public IActionResult Create()
        {
            ViewData["KullaniciId"] = new SelectList(_context.KisiselBilgi, "KullaniciId", "KullaniciId");
            return View();
        }

        // POST: Diller/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DilId,KullaniciId,Dil,Seviye")] Diller diller)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diller);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KullaniciId"] = new SelectList(_context.KisiselBilgi, "KullaniciId", "KullaniciId", diller.KullaniciId);
            return View(diller);
        }

        // GET: Diller/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Dillers == null)
            {
                return NotFound();
            }

            var diller = await _context.Dillers.FindAsync(id);
            if (diller == null)
            {
                return NotFound();
            }
            ViewData["KullaniciId"] = new SelectList(_context.KisiselBilgi, "KullaniciId", "KullaniciId", diller.KullaniciId);
            return View(diller);
        }

        // POST: Diller/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("DilId,KullaniciId,Dil,Seviye")] Diller diller)
        {
            if (id != diller.DilId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diller);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DillerExists(diller.DilId))
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
            ViewData["KullaniciId"] = new SelectList(_context.KisiselBilgi, "KullaniciId", "KullaniciId", diller.KullaniciId);
            return View(diller);
        }

        // GET: Diller/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Dillers == null)
            {
                return NotFound();
            }

            var diller = await _context.Dillers
                .Include(d => d.Kullanici)
                .FirstOrDefaultAsync(m => m.DilId == id);
            if (diller == null)
            {
                return NotFound();
            }

            return View(diller);
        }

        // POST: Diller/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Dillers == null)
            {
                return Problem("Entity set 'cvweb2Context.Dillers'  is null.");
            }
            var diller = await _context.Dillers.FindAsync(id);
            if (diller != null)
            {
                _context.Dillers.Remove(diller);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DillerExists(long id)
        {
          return (_context.Dillers?.Any(e => e.DilId == id)).GetValueOrDefault();
        }
    }
}
