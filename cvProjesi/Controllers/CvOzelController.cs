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
    public class CvOzelController : Controller
    {
        private readonly cvweb2Context _context;

        public CvOzelController()
        {
            _context = new cvweb2Context();
        }

        // GET: CvOzel
        public async Task<IActionResult> Index()
        {
            var cvweb2Context = _context.CvOzels.Include(c => c.Kayit).Include(c => c.Ozel);
            return View(await cvweb2Context.ToListAsync());
        }

        // GET: CvOzel/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.CvOzels == null)
            {
                return NotFound();
            }

            var cvOzel = await _context.CvOzels
                .Include(c => c.Kayit)
                .Include(c => c.Ozel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cvOzel == null)
            {
                return NotFound();
            }

            return View(cvOzel);
        }

        // GET: CvOzel/Create
        public IActionResult Create()
        {
            ViewData["KayitId"] = new SelectList(_context.CvOlusturs, "KayıtId", "KayıtId");
            ViewData["OzelId"] = new SelectList(_context.OzelBolums, "OzelId", "OzelId");
            return View();
        }

        // POST: CvOzel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,KayitId,OzelId")] CvOzel cvOzel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cvOzel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KayitId"] = new SelectList(_context.CvOlusturs, "KayıtId", "KayıtId", cvOzel.KayitId);
            ViewData["OzelId"] = new SelectList(_context.OzelBolums, "OzelId", "OzelId", cvOzel.OzelId);
            return View(cvOzel);
        }

        // GET: CvOzel/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.CvOzels == null)
            {
                return NotFound();
            }

            var cvOzel = await _context.CvOzels.FindAsync(id);
            if (cvOzel == null)
            {
                return NotFound();
            }
            ViewData["KayitId"] = new SelectList(_context.CvOlusturs, "KayıtId", "KayıtId", cvOzel.KayitId);
            ViewData["OzelId"] = new SelectList(_context.OzelBolums, "OzelId", "OzelId", cvOzel.OzelId);
            return View(cvOzel);
        }

        // POST: CvOzel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,KayitId,OzelId")] CvOzel cvOzel)
        {
            if (id != cvOzel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cvOzel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CvOzelExists(cvOzel.Id))
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
            ViewData["KayitId"] = new SelectList(_context.CvOlusturs, "KayıtId", "KayıtId", cvOzel.KayitId);
            ViewData["OzelId"] = new SelectList(_context.OzelBolums, "OzelId", "OzelId", cvOzel.OzelId);
            return View(cvOzel);
        }

        // GET: CvOzel/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.CvOzels == null)
            {
                return NotFound();
            }

            var cvOzel = await _context.CvOzels
                .Include(c => c.Kayit)
                .Include(c => c.Ozel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cvOzel == null)
            {
                return NotFound();
            }

            return View(cvOzel);
        }

        // POST: CvOzel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.CvOzels == null)
            {
                return Problem("Entity set 'cvweb2Context.CvOzels'  is null.");
            }
            var cvOzel = await _context.CvOzels.FindAsync(id);
            if (cvOzel != null)
            {
                _context.CvOzels.Remove(cvOzel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CvOzelExists(long id)
        {
          return (_context.CvOzels?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
