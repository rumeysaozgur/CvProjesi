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
    public class CvIsController : Controller
    {
        private readonly cvweb2Context _context;

        public CvIsController()
        {
            _context = new cvweb2Context();
        }

        // GET: CvIs
        public async Task<IActionResult> Index()
        {
            var cvweb2Context = _context.CvIs.Include(c => c.IsıdNavigation).Include(c => c.Kayit);
            return View(await cvweb2Context.ToListAsync());
        }

        // GET: CvIs/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.CvIs == null)
            {
                return NotFound();
            }

            var cvI = await _context.CvIs
                .Include(c => c.IsıdNavigation)
                .Include(c => c.Kayit)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cvI == null)
            {
                return NotFound();
            }

            return View(cvI);
        }

        // GET: CvIs/Create
        public IActionResult Create()
        {
            ViewData["Isıd"] = new SelectList(_context.IsDeneyimis, "IsId", "IsId");
            ViewData["KayitId"] = new SelectList(_context.CvOlusturs, "KayıtId", "KayıtId");
            return View();
        }

        // POST: CvIs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,KayitId,Isıd")] CvI cvI)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cvI);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Isıd"] = new SelectList(_context.IsDeneyimis, "IsId", "IsId", cvI.Isıd);
            ViewData["KayitId"] = new SelectList(_context.CvOlusturs, "KayıtId", "KayıtId", cvI.KayitId);
            return View(cvI);
        }

        // GET: CvIs/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.CvIs == null)
            {
                return NotFound();
            }

            var cvI = await _context.CvIs.FindAsync(id);
            if (cvI == null)
            {
                return NotFound();
            }
            ViewData["Isıd"] = new SelectList(_context.IsDeneyimis, "IsId", "IsId", cvI.Isıd);
            ViewData["KayitId"] = new SelectList(_context.CvOlusturs, "KayıtId", "KayıtId", cvI.KayitId);
            return View(cvI);
        }

        // POST: CvIs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,KayitId,Isıd")] CvI cvI)
        {
            if (id != cvI.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cvI);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CvIExists(cvI.Id))
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
            ViewData["Isıd"] = new SelectList(_context.IsDeneyimis, "IsId", "IsId", cvI.Isıd);
            ViewData["KayitId"] = new SelectList(_context.CvOlusturs, "KayıtId", "KayıtId", cvI.KayitId);
            return View(cvI);
        }

        // GET: CvIs/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.CvIs == null)
            {
                return NotFound();
            }

            var cvI = await _context.CvIs
                .Include(c => c.IsıdNavigation)
                .Include(c => c.Kayit)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cvI == null)
            {
                return NotFound();
            }

            return View(cvI);
        }

        // POST: CvIs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.CvIs == null)
            {
                return Problem("Entity set 'cvweb2Context.CvIs'  is null.");
            }
            var cvI = await _context.CvIs.FindAsync(id);
            if (cvI != null)
            {
                _context.CvIs.Remove(cvI);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CvIExists(long id)
        {
          return (_context.CvIs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
