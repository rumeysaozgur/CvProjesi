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
    public class CvYetenekController : Controller
    {
        private readonly cvweb2Context _context;

        public CvYetenekController()
        {
            _context = new cvweb2Context();
        }

        // GET: CvYetenek
        public async Task<IActionResult> Index()
        {
            var cvweb2Context = _context.CvYeteneks.Include(c => c.Kayit).Include(c => c.Yetenek);
            return View(await cvweb2Context.ToListAsync());
        }

        // GET: CvYetenek/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.CvYeteneks == null)
            {
                return NotFound();
            }

            var cvYetenek = await _context.CvYeteneks
                .Include(c => c.Kayit)
                .Include(c => c.Yetenek)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cvYetenek == null)
            {
                return NotFound();
            }

            return View(cvYetenek);
        }

        // GET: CvYetenek/Create
        public IActionResult Create()
        {
            ViewData["KayitId"] = new SelectList(_context.CvOlusturs, "KayıtId", "KayıtId");
            ViewData["YetenekId"] = new SelectList(_context.Yeteneklers, "YetenekId", "YetenekId");
            return View();
        }

        // POST: CvYetenek/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,KayitId,YetenekId")] CvYetenek cvYetenek)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cvYetenek);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KayitId"] = new SelectList(_context.CvOlusturs, "KayıtId", "KayıtId", cvYetenek.KayitId);
            ViewData["YetenekId"] = new SelectList(_context.Yeteneklers, "YetenekId", "YetenekId", cvYetenek.YetenekId);
            return View(cvYetenek);
        }

        // GET: CvYetenek/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.CvYeteneks == null)
            {
                return NotFound();
            }

            var cvYetenek = await _context.CvYeteneks.FindAsync(id);
            if (cvYetenek == null)
            {
                return NotFound();
            }
            ViewData["KayitId"] = new SelectList(_context.CvOlusturs, "KayıtId", "KayıtId", cvYetenek.KayitId);
            ViewData["YetenekId"] = new SelectList(_context.Yeteneklers, "YetenekId", "YetenekId", cvYetenek.YetenekId);
            return View(cvYetenek);
        }

        // POST: CvYetenek/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,KayitId,YetenekId")] CvYetenek cvYetenek)
        {
            if (id != cvYetenek.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cvYetenek);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CvYetenekExists(cvYetenek.Id))
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
            ViewData["KayitId"] = new SelectList(_context.CvOlusturs, "KayıtId", "KayıtId", cvYetenek.KayitId);
            ViewData["YetenekId"] = new SelectList(_context.Yeteneklers, "YetenekId", "YetenekId", cvYetenek.YetenekId);
            return View(cvYetenek);
        }

        // GET: CvYetenek/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.CvYeteneks == null)
            {
                return NotFound();
            }

            var cvYetenek = await _context.CvYeteneks
                .Include(c => c.Kayit)
                .Include(c => c.Yetenek)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cvYetenek == null)
            {
                return NotFound();
            }

            return View(cvYetenek);
        }

        // POST: CvYetenek/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.CvYeteneks == null)
            {
                return Problem("Entity set 'cvweb2Context.CvYeteneks'  is null.");
            }
            var cvYetenek = await _context.CvYeteneks.FindAsync(id);
            if (cvYetenek != null)
            {
                _context.CvYeteneks.Remove(cvYetenek);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CvYetenekExists(long id)
        {
          return (_context.CvYeteneks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
