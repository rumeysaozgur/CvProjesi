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
    public class CvBasariController : Controller
    {
        private readonly cvweb2Context _context;

        public CvBasariController()
        {
            _context = new cvweb2Context();
        }

        // GET: CvBasari
        public async Task<IActionResult> Index()
        {
            var cvweb2Context = _context.CvBasaris.Include(c => c.Basari).Include(c => c.Kayit);
            return View(await cvweb2Context.ToListAsync());
        }

        // GET: CvBasari/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.CvBasaris == null)
            {
                return NotFound();
            }

            var cvBasari = await _context.CvBasaris
                .Include(c => c.Basari)
                .Include(c => c.Kayit)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cvBasari == null)
            {
                return NotFound();
            }

            return View(cvBasari);
        }

        // GET: CvBasari/Create
        public IActionResult Create()
        {
            ViewData["BasariId"] = new SelectList(_context.Basarilars, "BasariId", "BasariId");
            ViewData["KayitId"] = new SelectList(_context.CvOlusturs, "KayıtId", "KayıtId");
            return View();
        }

        // POST: CvBasari/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,KayitId,BasariId")] CvBasari cvBasari)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cvBasari);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BasariId"] = new SelectList(_context.Basarilars, "BasariId", "BasariId", cvBasari.BasariId);
            ViewData["KayitId"] = new SelectList(_context.CvOlusturs, "KayıtId", "KayıtId", cvBasari.KayitId);
            return View(cvBasari);
        }

        // GET: CvBasari/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.CvBasaris == null)
            {
                return NotFound();
            }

            var cvBasari = await _context.CvBasaris.FindAsync(id);
            if (cvBasari == null)
            {
                return NotFound();
            }
            ViewData["BasariId"] = new SelectList(_context.Basarilars, "BasariId", "BasariId", cvBasari.BasariId);
            ViewData["KayitId"] = new SelectList(_context.CvOlusturs, "KayıtId", "KayıtId", cvBasari.KayitId);
            return View(cvBasari);
        }

        // POST: CvBasari/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,KayitId,BasariId")] CvBasari cvBasari)
        {
            if (id != cvBasari.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cvBasari);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CvBasariExists(cvBasari.Id))
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
            ViewData["BasariId"] = new SelectList(_context.Basarilars, "BasariId", "BasariId", cvBasari.BasariId);
            ViewData["KayitId"] = new SelectList(_context.CvOlusturs, "KayıtId", "KayıtId", cvBasari.KayitId);
            return View(cvBasari);
        }

        // GET: CvBasari/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.CvBasaris == null)
            {
                return NotFound();
            }

            var cvBasari = await _context.CvBasaris
                .Include(c => c.Basari)
                .Include(c => c.Kayit)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cvBasari == null)
            {
                return NotFound();
            }

            return View(cvBasari);
        }

        // POST: CvBasari/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.CvBasaris == null)
            {
                return Problem("Entity set 'cvweb2Context.CvBasaris'  is null.");
            }
            var cvBasari = await _context.CvBasaris.FindAsync(id);
            if (cvBasari != null)
            {
                _context.CvBasaris.Remove(cvBasari);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CvBasariExists(long id)
        {
          return (_context.CvBasaris?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
