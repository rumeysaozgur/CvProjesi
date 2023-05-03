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
    public class CvProfilController : Controller
    {
        private readonly cvweb2Context _context;

        public CvProfilController()
        {
            _context = new cvweb2Context();
        }

        // GET: CvProfil
        public async Task<IActionResult> Index()
        {
            var cvweb2Context = _context.CvProfils.Include(c => c.CvProfil1Navigation).Include(c => c.Kayit);
            return View(await cvweb2Context.ToListAsync());
        }

        // GET: CvProfil/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.CvProfils == null)
            {
                return NotFound();
            }

            var cvProfil = await _context.CvProfils
                .Include(c => c.CvProfil1Navigation)
                .Include(c => c.Kayit)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cvProfil == null)
            {
                return NotFound();
            }

            return View(cvProfil);
        }

        // GET: CvProfil/Create
        public IActionResult Create()
        {
            ViewData["CvProfil1"] = new SelectList(_context.Profillers, "ProfilId", "ProfilId");
            ViewData["KayitId"] = new SelectList(_context.CvOlusturs, "KayıtId", "KayıtId");
            return View();
        }

        // POST: CvProfil/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,KayitId,CvProfil1")] CvProfil cvProfil)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cvProfil);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CvProfil1"] = new SelectList(_context.Profillers, "ProfilId", "ProfilId", cvProfil.CvProfil1);
            ViewData["KayitId"] = new SelectList(_context.CvOlusturs, "KayıtId", "KayıtId", cvProfil.KayitId);
            return View(cvProfil);
        }

        // GET: CvProfil/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.CvProfils == null)
            {
                return NotFound();
            }

            var cvProfil = await _context.CvProfils.FindAsync(id);
            if (cvProfil == null)
            {
                return NotFound();
            }
            ViewData["CvProfil1"] = new SelectList(_context.Profillers, "ProfilId", "ProfilId", cvProfil.CvProfil1);
            ViewData["KayitId"] = new SelectList(_context.CvOlusturs, "KayıtId", "KayıtId", cvProfil.KayitId);
            return View(cvProfil);
        }

        // POST: CvProfil/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,KayitId,CvProfil1")] CvProfil cvProfil)
        {
            if (id != cvProfil.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cvProfil);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CvProfilExists(cvProfil.Id))
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
            ViewData["CvProfil1"] = new SelectList(_context.Profillers, "ProfilId", "ProfilId", cvProfil.CvProfil1);
            ViewData["KayitId"] = new SelectList(_context.CvOlusturs, "KayıtId", "KayıtId", cvProfil.KayitId);
            return View(cvProfil);
        }

        // GET: CvProfil/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.CvProfils == null)
            {
                return NotFound();
            }

            var cvProfil = await _context.CvProfils
                .Include(c => c.CvProfil1Navigation)
                .Include(c => c.Kayit)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cvProfil == null)
            {
                return NotFound();
            }

            return View(cvProfil);
        }

        // POST: CvProfil/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.CvProfils == null)
            {
                return Problem("Entity set 'cvweb2Context.CvProfils'  is null.");
            }
            var cvProfil = await _context.CvProfils.FindAsync(id);
            if (cvProfil != null)
            {
                _context.CvProfils.Remove(cvProfil);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CvProfilExists(long id)
        {
          return (_context.CvProfils?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
