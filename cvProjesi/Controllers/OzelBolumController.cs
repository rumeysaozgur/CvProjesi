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
    public class OzelBolumController : Controller
    {
        private readonly cvweb2Context _context;

        public OzelBolumController()
        {
            _context = new cvweb2Context();
        }

        // GET: OzelBolum
        public async Task<IActionResult> Index()
        {
            var cvweb2Context = _context.OzelBolums.Include(o => o.Kullanici);
            return View(await cvweb2Context.ToListAsync());
        }

        // GET: OzelBolum/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.OzelBolums == null)
            {
                return NotFound();
            }

            var ozelBolum = await _context.OzelBolums
                .Include(o => o.Kullanici)
                .FirstOrDefaultAsync(m => m.OzelId == id);
            if (ozelBolum == null)
            {
                return NotFound();
            }

            return View(ozelBolum);
        }

        // GET: OzelBolum/Create
        public IActionResult Create()
        {
            ViewData["KullaniciId"] = new SelectList(_context.KisiselBilgi, "KullaniciId", "KullaniciId");
            return View();
        }

        // POST: OzelBolum/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OzelId,KullaniciId,Baslik,Aciklama")] OzelBolum ozelBolum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ozelBolum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KullaniciId"] = new SelectList(_context.KisiselBilgi, "KullaniciId", "KullaniciId", ozelBolum.KullaniciId);
            return View(ozelBolum);
        }

        // GET: OzelBolum/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.OzelBolums == null)
            {
                return NotFound();
            }

            var ozelBolum = await _context.OzelBolums.FindAsync(id);
            if (ozelBolum == null)
            {
                return NotFound();
            }
            ViewData["KullaniciId"] = new SelectList(_context.KisiselBilgi, "KullaniciId", "KullaniciId", ozelBolum.KullaniciId);
            return View(ozelBolum);
        }

        // POST: OzelBolum/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("OzelId,KullaniciId,Baslik,Aciklama")] OzelBolum ozelBolum)
        {
            if (id != ozelBolum.OzelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ozelBolum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OzelBolumExists(ozelBolum.OzelId))
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
            ViewData["KullaniciId"] = new SelectList(_context.KisiselBilgi, "KullaniciId", "KullaniciId", ozelBolum.KullaniciId);
            return View(ozelBolum);
        }

        // GET: OzelBolum/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.OzelBolums == null)
            {
                return NotFound();
            }

            var ozelBolum = await _context.OzelBolums
                .Include(o => o.Kullanici)
                .FirstOrDefaultAsync(m => m.OzelId == id);
            if (ozelBolum == null)
            {
                return NotFound();
            }

            return View(ozelBolum);
        }

        // POST: OzelBolum/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.OzelBolums == null)
            {
                return Problem("Entity set 'cvweb2Context.OzelBolums'  is null.");
            }
            var ozelBolum = await _context.OzelBolums.FindAsync(id);
            if (ozelBolum != null)
            {
                _context.OzelBolums.Remove(ozelBolum);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OzelBolumExists(long id)
        {
          return (_context.OzelBolums?.Any(e => e.OzelId == id)).GetValueOrDefault();
        }
    }
}
