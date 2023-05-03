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
    public class ProfillerController : Controller
    {
        private readonly cvweb2Context _context;

        public ProfillerController()
        {
            _context = new cvweb2Context();
        }

        // GET: Profiller
        public async Task<IActionResult> Index()
        {
            var cvweb2Context = _context.Profillers.Include(p => p.Kullanici);
            return View(await cvweb2Context.ToListAsync());
        }

        // GET: Profiller/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Profillers == null)
            {
                return NotFound();
            }

            var profiller = await _context.Profillers
                .Include(p => p.Kullanici)
                .FirstOrDefaultAsync(m => m.ProfilId == id);
            if (profiller == null)
            {
                return NotFound();
            }

            return View(profiller);
        }

        // GET: Profiller/Create
        public IActionResult Create()
        {
            ViewData["KullaniciId"] = new SelectList(_context.KisiselBilgi, "KullaniciId", "KullaniciId");
            return View();
        }

        // POST: Profiller/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProfilId,KullaniciId,IsUnvani,UnvanAciklama,GenelBilgi,Resim")] Profiller profiller)
        {
            if (ModelState.IsValid)
            {
                _context.Add(profiller);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KullaniciId"] = new SelectList(_context.KisiselBilgi, "KullaniciId", "KullaniciId", profiller.KullaniciId);
            return View(profiller);
        }

        // GET: Profiller/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Profillers == null)
            {
                return NotFound();
            }

            var profiller = await _context.Profillers.FindAsync(id);
            if (profiller == null)
            {
                return NotFound();
            }
            ViewData["KullaniciId"] = new SelectList(_context.KisiselBilgi, "KullaniciId", "KullaniciId", profiller.KullaniciId);
            return View(profiller);
        }

        // POST: Profiller/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("ProfilId,KullaniciId,IsUnvani,UnvanAciklama,GenelBilgi,Resim")] Profiller profiller)
        {
            if (id != profiller.ProfilId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profiller);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfillerExists(profiller.ProfilId))
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
            ViewData["KullaniciId"] = new SelectList(_context.KisiselBilgi, "KullaniciId", "KullaniciId", profiller.KullaniciId);
            return View(profiller);
        }

        // GET: Profiller/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Profillers == null)
            {
                return NotFound();
            }

            var profiller = await _context.Profillers
                .Include(p => p.Kullanici)
                .FirstOrDefaultAsync(m => m.ProfilId == id);
            if (profiller == null)
            {
                return NotFound();
            }

            return View(profiller);
        }

        // POST: Profiller/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Profillers == null)
            {
                return Problem("Entity set 'cvweb2Context.Profillers'  is null.");
            }
            var profiller = await _context.Profillers.FindAsync(id);
            if (profiller != null)
            {
                _context.Profillers.Remove(profiller);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfillerExists(long id)
        {
          return (_context.Profillers?.Any(e => e.ProfilId == id)).GetValueOrDefault();
        }
    }
}
