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
    public class SablonController : Controller
    {
        private readonly cvweb2Context _context;

        public SablonController()
        {
            _context = new cvweb2Context();
        }

        // GET: Sablon
        public async Task<IActionResult> Index()
        {
              return _context.Sablons != null ? 
                          View(await _context.Sablons.ToListAsync()) :
                          Problem("Entity set 'cvweb2Context.Sablons'  is null.");
        }

        // GET: Sablon/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Sablons == null)
            {
                return NotFound();
            }

            var sablon = await _context.Sablons
                .FirstOrDefaultAsync(m => m.SablonId == id);
            if (sablon == null)
            {
                return NotFound();
            }

            return View(sablon);
        }

        // GET: Sablon/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sablon/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SablonId,SablonAdi,OnizlemeResim,Text")] Sablon sablon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sablon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sablon);
        }

        // GET: Sablon/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Sablons == null)
            {
                return NotFound();
            }

            var sablon = await _context.Sablons.FindAsync(id);
            if (sablon == null)
            {
                return NotFound();
            }
            return View(sablon);
        }

        // POST: Sablon/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("SablonId,SablonAdi,OnizlemeResim,Text")] Sablon sablon)
        {
            if (id != sablon.SablonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sablon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SablonExists(sablon.SablonId))
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
            return View(sablon);
        }

        // GET: Sablon/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Sablons == null)
            {
                return NotFound();
            }

            var sablon = await _context.Sablons
                .FirstOrDefaultAsync(m => m.SablonId == id);
            if (sablon == null)
            {
                return NotFound();
            }

            return View(sablon);
        }

        // POST: Sablon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Sablons == null)
            {
                return Problem("Entity set 'cvweb2Context.Sablons'  is null.");
            }
            var sablon = await _context.Sablons.FindAsync(id);
            if (sablon != null)
            {
                _context.Sablons.Remove(sablon);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SablonExists(long id)
        {
          return (_context.Sablons?.Any(e => e.SablonId == id)).GetValueOrDefault();
        }
    }
}
