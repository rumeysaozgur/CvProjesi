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
    public class CvKursController : Controller
    {
        private readonly cvweb2Context _context;

        public CvKursController()
        {
            _context = new cvweb2Context();
        }

        // GET: CvKurs
        public async Task<IActionResult> Index()
        {
            var cvweb2Context = _context.CvKurs.Include(c => c.Kayit).Include(c => c.Kurs);
            return View(await cvweb2Context.ToListAsync());
        }

        // GET: CvKurs/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.CvKurs == null)
            {
                return NotFound();
            }

            var cvKur = await _context.CvKurs
                .Include(c => c.Kayit)
                .Include(c => c.Kurs)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cvKur == null)
            {
                return NotFound();
            }

            return View(cvKur);
        }

        // GET: CvKurs/Create
        public IActionResult Create()
        {
            ViewData["KayitId"] = new SelectList(_context.CvOlusturs, "KayıtId", "KayıtId");
            ViewData["KursId"] = new SelectList(_context.Kurslars, "KursId", "KursId");
            return View();
        }

        // POST: CvKurs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,KayitId,KursId")] CvKur cvKur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cvKur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KayitId"] = new SelectList(_context.CvOlusturs, "KayıtId", "KayıtId", cvKur.KayitId);
            ViewData["KursId"] = new SelectList(_context.Kurslars, "KursId", "KursId", cvKur.KursId);
            return View(cvKur);
        }

        // GET: CvKurs/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.CvKurs == null)
            {
                return NotFound();
            }

            var cvKur = await _context.CvKurs.FindAsync(id);
            if (cvKur == null)
            {
                return NotFound();
            }
            ViewData["KayitId"] = new SelectList(_context.CvOlusturs, "KayıtId", "KayıtId", cvKur.KayitId);
            ViewData["KursId"] = new SelectList(_context.Kurslars, "KursId", "KursId", cvKur.KursId);
            return View(cvKur);
        }

        // POST: CvKurs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,KayitId,KursId")] CvKur cvKur)
        {
            if (id != cvKur.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cvKur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CvKurExists(cvKur.Id))
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
            ViewData["KayitId"] = new SelectList(_context.CvOlusturs, "KayıtId", "KayıtId", cvKur.KayitId);
            ViewData["KursId"] = new SelectList(_context.Kurslars, "KursId", "KursId", cvKur.KursId);
            return View(cvKur);
        }

        // GET: CvKurs/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.CvKurs == null)
            {
                return NotFound();
            }

            var cvKur = await _context.CvKurs
                .Include(c => c.Kayit)
                .Include(c => c.Kurs)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cvKur == null)
            {
                return NotFound();
            }

            return View(cvKur);
        }

        // POST: CvKurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.CvKurs == null)
            {
                return Problem("Entity set 'cvweb2Context.CvKurs'  is null.");
            }
            var cvKur = await _context.CvKurs.FindAsync(id);
            if (cvKur != null)
            {
                _context.CvKurs.Remove(cvKur);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CvKurExists(long id)
        {
          return (_context.CvKurs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
