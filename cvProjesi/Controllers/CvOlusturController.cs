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
    public class CvOlusturController : Controller
    {
        private readonly cvweb2Context _context;

        public CvOlusturController()
        {
            _context = new cvweb2Context();
        }

        // GET: CvOlustur
        public async Task<IActionResult> Index()
        {
            var cvweb2Context = _context.CvOlusturs.Include(c => c.Kullanici).Include(c => c.SablonNavigation);
            return View(await cvweb2Context.ToListAsync());
        }

        // GET: CvOlustur/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.CvOlusturs == null)
            {
                return NotFound();
            }

            var cvOlustur = await _context.CvOlusturs
                .Include(c => c.Kullanici)
                .Include(c => c.SablonNavigation)
                .FirstOrDefaultAsync(m => m.KayıtId == id);
            if (cvOlustur == null)
            {
                return NotFound();
            }

            return View(cvOlustur);
        }

        // GET: CvOlustur/Create
        public IActionResult Create()
        {
            ViewData["KullaniciId"] = new SelectList(_context.KisiselBilgi, "KullaniciId", "KullaniciId");
            ViewData["Sablon"] = new SelectList(_context.Sablons, "SablonId", "SablonId");
            return View();
        }

        // POST: CvOlustur/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KayıtId,KullaniciId,Ad,Soyad,Sablon,Yetenekler,Egitimler,Kurslar,Isler,Basarilar,Portfolio,Diller,OzelBolum")] CvOlustur cvOlustur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cvOlustur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KullaniciId"] = new SelectList(_context.KisiselBilgi, "KullaniciId", "KullaniciId", cvOlustur.KullaniciId);
            ViewData["Sablon"] = new SelectList(_context.Sablons, "SablonId", "SablonId", cvOlustur.Sablon);
            return View(cvOlustur);
        }

        // GET: CvOlustur/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.CvOlusturs == null)
            {
                return NotFound();
            }

            var cvOlustur = await _context.CvOlusturs.FindAsync(id);
            if (cvOlustur == null)
            {
                return NotFound();
            }
            ViewData["KullaniciId"] = new SelectList(_context.KisiselBilgi, "KullaniciId", "KullaniciId", cvOlustur.KullaniciId);
            ViewData["Sablon"] = new SelectList(_context.Sablons, "SablonId", "SablonId", cvOlustur.Sablon);
            return View(cvOlustur);
        }

        // POST: CvOlustur/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("KayıtId,KullaniciId,Ad,Soyad,Sablon,Yetenekler,Egitimler,Kurslar,Isler,Basarilar,Portfolio,Diller,OzelBolum")] CvOlustur cvOlustur)
        {
            if (id != cvOlustur.KayıtId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cvOlustur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CvOlusturExists(cvOlustur.KayıtId))
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
            ViewData["KullaniciId"] = new SelectList(_context.KisiselBilgi, "KullaniciId", "KullaniciId", cvOlustur.KullaniciId);
            ViewData["Sablon"] = new SelectList(_context.Sablons, "SablonId", "SablonId", cvOlustur.Sablon);
            return View(cvOlustur);
        }

        // GET: CvOlustur/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.CvOlusturs == null)
            {
                return NotFound();
            }

            var cvOlustur = await _context.CvOlusturs
                .Include(c => c.Kullanici)
                .Include(c => c.SablonNavigation)
                .FirstOrDefaultAsync(m => m.KayıtId == id);
            if (cvOlustur == null)
            {
                return NotFound();
            }

            return View(cvOlustur);
        }

        // POST: CvOlustur/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.CvOlusturs == null)
            {
                return Problem("Entity set 'cvweb2Context.CvOlusturs'  is null.");
            }
            var cvOlustur = await _context.CvOlusturs.FindAsync(id);
            if (cvOlustur != null)
            {
                _context.CvOlusturs.Remove(cvOlustur);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CvOlusturExists(long id)
        {
          return (_context.CvOlusturs?.Any(e => e.KayıtId == id)).GetValueOrDefault();
        }
    }
}
