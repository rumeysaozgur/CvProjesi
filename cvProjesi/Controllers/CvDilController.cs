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
    public class CvDilController : Controller
    {
        private readonly cvweb2Context _context;

        public CvDilController()
        {
            _context = new cvweb2Context();
        }

        // GET: CvDil
        public async Task<IActionResult> Index()
        {
            var cvweb2Context = _context.CvDils.Include(c => c.Dil).Include(c => c.Kayit);
            return View(await cvweb2Context.ToListAsync());
        }

        // GET: CvDil/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.CvDils == null)
            {
                return NotFound();
            }

            var cvDil = await _context.CvDils
                .Include(c => c.Dil)
                .Include(c => c.Kayit)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cvDil == null)
            {
                return NotFound();
            }

            return View(cvDil);
        }

        // GET: CvDil/Create
        public IActionResult Create()
        {
            ViewData["DilId"] = new SelectList(_context.CvDils, "Id", "Id");
            ViewData["KayitId"] = new SelectList(_context.CvOlusturs, "KayıtId", "KayıtId");
            return View();
        }

        // POST: CvDil/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,KayitId,DilId")] CvDil cvDil)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cvDil);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DilId"] = new SelectList(_context.CvDils, "Id", "Id", cvDil.DilId);
            ViewData["KayitId"] = new SelectList(_context.CvOlusturs, "KayıtId", "KayıtId", cvDil.KayitId);
            return View(cvDil);
        }

        // GET: CvDil/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.CvDils == null)
            {
                return NotFound();
            }

            var cvDil = await _context.CvDils.FindAsync(id);
            if (cvDil == null)
            {
                return NotFound();
            }
            ViewData["DilId"] = new SelectList(_context.CvDils, "Id", "Id", cvDil.DilId);
            ViewData["KayitId"] = new SelectList(_context.CvOlusturs, "KayıtId", "KayıtId", cvDil.KayitId);
            return View(cvDil);
        }

        // POST: CvDil/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,KayitId,DilId")] CvDil cvDil)
        {
            if (id != cvDil.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cvDil);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CvDilExists(cvDil.Id))
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
            ViewData["DilId"] = new SelectList(_context.CvDils, "Id", "Id", cvDil.DilId);
            ViewData["KayitId"] = new SelectList(_context.CvOlusturs, "KayıtId", "KayıtId", cvDil.KayitId);
            return View(cvDil);
        }

        // GET: CvDil/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.CvDils == null)
            {
                return NotFound();
            }

            var cvDil = await _context.CvDils
                .Include(c => c.Dil)
                .Include(c => c.Kayit)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cvDil == null)
            {
                return NotFound();
            }

            return View(cvDil);
        }

        // POST: CvDil/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.CvDils == null)
            {
                return Problem("Entity set 'cvweb2Context.CvDils'  is null.");
            }
            var cvDil = await _context.CvDils.FindAsync(id);
            if (cvDil != null)
            {
                _context.CvDils.Remove(cvDil);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CvDilExists(long id)
        {
          return (_context.CvDils?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
