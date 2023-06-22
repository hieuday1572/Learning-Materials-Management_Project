using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LMMProject.Data;
using LMMProject.Models;

namespace LMMProject.Controllers
{
    public class ADMINComboController : Controller
    {
        private readonly AppDbContext _context;

        public ADMINComboController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ADMINCombo
        public async Task<IActionResult> Index(int? id)
        {
            Curriculum curri = _context.Curriculum.FirstOrDefault(p => p.CurriculumId == id);
            ViewBag.Curriculum = curri;
            var listCombo = _context.Combo.Include(p => p.Curriculum).Where(pro => pro.CurriculumId == id).ToList();
            return View(listCombo);  
        }

        // GET: ADMINCombo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            Combo combsub = _context.Combo.FirstOrDefault(p => p.ComboId == id);
            ViewBag.Combosub = combsub;
            var listSubject = _context.Combo_Subject.Include(a => a.Subject).Include(b => b.Combo).Where(pro => pro.id == id).ToList();
            return View(listSubject);
        }

        // GET: ADMINCombo/Create
        public IActionResult Create()
        {
            ViewData["CurriculumId"] = new SelectList(_context.Curriculum, "CurriculumId");
            return View();
        }

        // POST: ADMINCombo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ComboId,ComboNameVn,ComboNameEn,Note,Tag,CurriculumId")] Combo combo)
        {
            if (ModelState.IsValid)
            {
                    _context.Add(combo);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index)); 
            }
            ViewData["CurriculumId"] = new SelectList(_context.Curriculum, "CurriculumId", "CurriculumCode", combo.CurriculumId);
            return View(combo);
        }

        // GET: ADMINCombo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Combo == null)
            {
                return NotFound();
            }

            var combo = await _context.Combo.FindAsync(id);
            if (combo == null)
            {
                return NotFound();
            }
            ViewData["CurriculumId"] = new SelectList(_context.Curriculum, "CurriculumId", "CurriculumCode", combo.CurriculumId);
            return View(combo);
        }

        // POST: ADMINCombo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ComboId,ComboNameVn,ComboNameEn,Note,Tag,CurriculumId")] Combo combo)
        {
            if (id != combo.ComboId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(combo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComboExists(combo.ComboId))
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
            ViewData["CurriculumId"] = new SelectList(_context.Curriculum, "CurriculumId", "CurriculumCode", combo.CurriculumId);
            return View(combo);
        }

        // GET: ADMINCombo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Combo == null)
            {
                return NotFound();
            }
            var curriculum = await _context.Curriculum
                .FirstOrDefaultAsync(m => m.CurriculumId == id);
            var combo = await _context.Combo
                .Include(c => c.Curriculum)
                .FirstOrDefaultAsync(m => m.ComboId == id);
            if (combo == null)
            {
                return NotFound();
            }

            return View(combo);
        }

        // POST: ADMINCombo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Combo == null)
            {
                return Problem("Entity set 'AppDbContext.Combo'  is null.");
            }
            ViewData["Combo"] = new SelectList(_context.Combo);
            var combo = await _context.Combo.FindAsync(id);
            var comboS = await _context.Combo_Subject.FindAsync(id);
            if (combo != null)
            {
                _context.Combo.RemoveRange(combo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComboExists(int id)
        {
          return (_context.Combo?.Any(e => e.ComboId == id)).GetValueOrDefault();
        }
    }
}
