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
    public class CvEgitimController : Controller
    {
        private readonly cvweb2Context _context;

        public CvEgitimController()
        {
            _context = new cvweb2Context();
        }

        // GET: CvEgitim
        public async Task<IActionResult> Index()
        {
            var cvweb2Context = _context.CvEgitims.Include(c => c.Egitim).Include(c => c.Kayit);
            return View(await cvweb2Context.ToListAsync());
        }

        // GET: CvEgitim/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.CvEgitims == null)
            {
                return NotFound();
            }

            var cvEgitim = await _context.CvEgitims
                .Include(c => c.Egitim)
                .Include(c => c.Kayit)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cvEgitim == null)
            {
                return NotFound();
            }

            return View(cvEgitim);
        }

        // GET: CvEgitim/Create
        public IActionResult Create()
        {
            ViewData["EgitimId"] = new SelectList(_context.Egitimlers, "EgitimId", "EgitimId");
            ViewData["KayitId"] = new SelectList(_context.CvOlusturs, "KayıtId", "KayıtId");
            return View();
        }

        // POST: CvEgitim/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,KayitId,EgitimId")] CvEgitim cvEgitim)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cvEgitim);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EgitimId"] = new SelectList(_context.Egitimlers, "EgitimId", "EgitimId", cvEgitim.EgitimId);
            ViewData["KayitId"] = new SelectList(_context.CvOlusturs, "KayıtId", "KayıtId", cvEgitim.KayitId);
            return View(cvEgitim);
        }

        // GET: CvEgitim/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.CvEgitims == null)
            {
                return NotFound();
            }

            var cvEgitim = await _context.CvEgitims.FindAsync(id);
            if (cvEgitim == null)
            {
                return NotFound();
            }
            ViewData["EgitimId"] = new SelectList(_context.Egitimlers, "EgitimId", "EgitimId", cvEgitim.EgitimId);
            ViewData["KayitId"] = new SelectList(_context.CvOlusturs, "KayıtId", "KayıtId", cvEgitim.KayitId);
            return View(cvEgitim);
        }

        // POST: CvEgitim/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,KayitId,EgitimId")] CvEgitim cvEgitim)
        {
            if (id != cvEgitim.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cvEgitim);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CvEgitimExists(cvEgitim.Id))
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
            ViewData["EgitimId"] = new SelectList(_context.Egitimlers, "EgitimId", "EgitimId", cvEgitim.EgitimId);
            ViewData["KayitId"] = new SelectList(_context.CvOlusturs, "KayıtId", "KayıtId", cvEgitim.KayitId);
            return View(cvEgitim);
        }

        // GET: CvEgitim/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.CvEgitims == null)
            {
                return NotFound();
            }

            var cvEgitim = await _context.CvEgitims
                .Include(c => c.Egitim)
                .Include(c => c.Kayit)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cvEgitim == null)
            {
                return NotFound();
            }

            return View(cvEgitim);
        }

        // POST: CvEgitim/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.CvEgitims == null)
            {
                return Problem("Entity set 'cvweb2Context.CvEgitims'  is null.");
            }
            var cvEgitim = await _context.CvEgitims.FindAsync(id);
            if (cvEgitim != null)
            {
                _context.CvEgitims.Remove(cvEgitim);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CvEgitimExists(long id)
        {
            return (_context.CvEgitims?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
