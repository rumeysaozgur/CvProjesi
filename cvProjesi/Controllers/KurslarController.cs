using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using cvProjesi.Models;
using System.Security.Claims;

namespace cvProjesi.Controllers.Admin
{
    public class KurslarController : Controller
    {
        private readonly cvweb2Context _context;

        public KurslarController()
        {
            _context = new cvweb2Context();
        }

        // GET: Kurslar
        public async Task<IActionResult> Index()
        {
            var cvweb2Context = _context.Kurslars.Where(x => x.KullaniciId.ToString() == User.FindFirst(ClaimTypes.GivenName).Value);
            return View(await cvweb2Context.ToListAsync());
        }

        // GET: Kurslar/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Kurslars == null)
            {
                return NotFound();
            }

            var kurslar = await _context.Kurslars
                .Include(k => k.KullaniciId)
                .FirstOrDefaultAsync(m => m.KursId == id);
            if (kurslar == null)
            {
                return NotFound();
            }

            return View(kurslar);
        }

        // GET: Kurslar/Create
        public IActionResult Create()
        {
            ViewData["KullaniciId"] = new SelectList(_context.KisiselBilgi, "KullaniciId", "KullaniciId");
            return View();
        }

        // POST: Kurslar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KursId,KullaniciId,KursAdi,Kurum,Aciklama")] Kurslar kurslar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kurslar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KullaniciId"] = new SelectList(_context.KisiselBilgi, "KullaniciId", "KullaniciId", kurslar.KullaniciId);
            return View(nameof(Create));
        }

        // GET: Kurslar/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Kurslars == null)
            {
                return NotFound();
            }

            var kurslar = await _context.Kurslars.FindAsync(id);
            if (kurslar == null)
            {
                return NotFound();
            }
            ViewData["KullaniciId"] = new SelectList(_context.KisiselBilgi, "KullaniciId", "KullaniciId", kurslar.KullaniciId);
            return View(kurslar);
        }

        // POST: Kurslar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("KursId,KullaniciId,KursAdi,Kurum,Aciklama")] Kurslar kurslar)
        {
            if (id != kurslar.KursId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kurslar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KurslarExists(kurslar.KursId))
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
            ViewData["KullaniciId"] = new SelectList(_context.KisiselBilgi, "KullaniciId", "KullaniciId", kurslar.KullaniciId);
            return View(kurslar);
        }

        // GET: Kurslar/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Kurslars == null)
            {
                return NotFound();
            }

            var kurslar = await _context.Kurslars
                .Include(k => k.KullaniciId)
                .FirstOrDefaultAsync(m => m.KursId == id);
            if (kurslar == null)
            {
                return NotFound();
            }

            return View(kurslar);
        }

        // POST: Kurslar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Kurslars == null)
            {
                return Problem("Entity set 'cvweb2Context.Kurslars'  is null.");
            }
            var kurslar = await _context.Kurslars.FindAsync(id);
            if (kurslar != null)
            {
                _context.Kurslars.Remove(kurslar);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KurslarExists(long id)
        {
          return (_context.Kurslars?.Any(e => e.KursId == id)).GetValueOrDefault();
        }
    }
}
