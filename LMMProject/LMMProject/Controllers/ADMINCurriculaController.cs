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
    public class ADMINCurriculaController : Controller
    {
        private readonly AppDbContext _context;

        public ADMINCurriculaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Curricula
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Curriculum.Include(c => c.Decision);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Curricula/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Curriculum == null)
            {
                return NotFound();
            }

            var curriculum = await _context.Curriculum
                .Include(c => c.Decision)
                .FirstOrDefaultAsync(m => m.CurriculumId == id);
            if (curriculum == null)
            {
                return NotFound();
            }

            return View(curriculum);
        }

        // GET: Curricula/Create
        public IActionResult Create()
        {
            ViewData["DecisionNo"] = new SelectList(_context.Decision, "DecisionNo", "DecisionNo");
            return View();
        }

        // POST: Curricula/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CurriculumId,CurriculumCode,NameVn,NameEn,Decription,DecisionNo,TotalCredit,IsActive")] Curriculum curriculum)
        {
            
            if (ModelState.IsValid)
            {
                Curriculum checkCode=_context.Curriculum.Include(p => p.Decision).FirstOrDefault(pro => pro.CurriculumCode.Equals(curriculum.CurriculumCode));
                if (checkCode == null)
                {
                    _context.Add(curriculum);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["Error"] = "Wrong: Curriculum is already exist !";
                }
            }
            ViewData["DecisionNo"] = new SelectList(_context.Decision, "DecisionNo", "DecisionNo", curriculum.DecisionNo);
            return View(curriculum);
        }

        // GET: Curricula/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Curriculum == null)
            {
                return NotFound();
            }

            var curriculum = await _context.Curriculum.FindAsync(id);
            if (curriculum == null)
            {
                return NotFound();
            }
            ViewData["DecisionNo"] = new SelectList(_context.Decision, "DecisionNo", "DecisionNo", curriculum.DecisionNo);
            return View(curriculum);
        }

        // POST: Curricula/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CurriculumId,CurriculumCode,NameVn,NameEn,Decription,DecisionNo,TotalCredit,IsActive")] Curriculum curriculum)
        {
            if (id != curriculum.CurriculumId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(curriculum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CurriculumExists(curriculum.CurriculumId))
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
            ViewData["DecisionNo"] = new SelectList(_context.Decision, "DecisionNo", "DecisionNo", curriculum.DecisionNo);
            return View(curriculum);
        }

        // GET: Curricula/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Curriculum == null)
            {
                return NotFound();
            }

            var curriculum = await _context.Curriculum
                .Include(c => c.Decision)
                .FirstOrDefaultAsync(m => m.CurriculumId == id);
            if (curriculum == null)
            {
                return NotFound();
            }

            return View(curriculum);
        }

        // POST: Curricula/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Curriculum == null)
            {
                return Problem("Entity set 'AppDbContext.Curriculum'  is null.");
            }
            var curriculum = await _context.Curriculum.FindAsync(id);
            if (curriculum != null)
            {
                _context.Curriculum.Remove(curriculum);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CurriculumExists(int id)
        {
          return (_context.Curriculum?.Any(e => e.CurriculumId == id)).GetValueOrDefault();
        }
    }
}
