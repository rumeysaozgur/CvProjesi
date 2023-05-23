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
    public class YeteneklerController : Controller
    {
        private readonly cvweb2Context _context;

        public YeteneklerController()
        {
            _context = new cvweb2Context();
        }
        

        // GET: Yetenekler
        public async Task<IActionResult> Index()
        {
            var cvweb2Context = _context.Yeteneklers.Include(y => y.Kullanici);
           
            return View(await cvweb2Context.ToListAsync());
        }

        // GET: Yetenekler/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Yeteneklers == null)
            {
                return NotFound();
            }

            var yetenekler = await _context.Yeteneklers
                .Include(y => y.Kullanici)
                .FirstOrDefaultAsync(m => m.YetenekId == id);
            if (yetenekler == null)
            {
                return NotFound();
            }

            return View(yetenekler);
        }

        // GET: Yetenekler/Create
        public IActionResult Create()
        {
            ViewData["KullaniciId"] = new SelectList(_context.KisiselBilgi, "KullaniciId", "KullaniciId");
            return View();
        }

        // POST: Yetenekler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("YetenekId,KullaniciId,Adi,Aciklama,Seviye")] Yetenekler yetenekler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yetenekler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KullaniciId"] = new SelectList(_context.KisiselBilgi, "KullaniciId", "KullaniciId", yetenekler.KullaniciId);
            return View(yetenekler);
        }

        // GET: Yetenekler/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Yeteneklers == null)
            {
                return NotFound();
            }

            var yetenekler = await _context.Yeteneklers.FindAsync(id);
            if (yetenekler == null)
            {
                return NotFound();
            }
            ViewData["KullaniciId"] = new SelectList(_context.KisiselBilgi, "KullaniciId", "KullaniciId", yetenekler.KullaniciId);
            return View(yetenekler);
        }

        // POST: Yetenekler/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("YetenekId,KullaniciId,Adi,Aciklama,Seviye")] Yetenekler yetenekler)
        {
            if (id != yetenekler.YetenekId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yetenekler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YeteneklerExists(yetenekler.YetenekId))
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
            ViewData["KullaniciId"] = new SelectList(_context.KisiselBilgi, "KullaniciId", "KullaniciId", yetenekler.KullaniciId);
            return View(yetenekler);
        }

        // GET: Yetenekler/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Yeteneklers == null)
            {
                return NotFound();
            }

            var yetenekler = await _context.Yeteneklers
                .Include(y => y.Kullanici)
                .FirstOrDefaultAsync(m => m.YetenekId == id);
            if (yetenekler == null)
            {
                return NotFound();
            }

            return View(yetenekler);
        }

        // POST: Yetenekler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Yeteneklers == null)
            {
                return Problem("Entity set 'cvweb2Context.Yeteneklers'  is null.");
            }
            var yetenekler = await _context.Yeteneklers.FindAsync(id);
            if (yetenekler != null)
            {
                _context.Yeteneklers.Remove(yetenekler);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YeteneklerExists(long id)
        {
          return (_context.Yeteneklers?.Any(e => e.YetenekId == id)).GetValueOrDefault();
        }
    }
}
