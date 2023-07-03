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
    public class ADMINSessionController : Controller
    {
        private readonly AppDbContext _context;

        public ADMINSessionController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Sessions
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Session.Include(s => s.Subject);
            return View(await appDbContext.ToListAsync());
        }
        // GET: Sessions/Create
        public IActionResult Create()
        {
            ViewData["SubjectCode"] = new SelectList(_context.Subject, "SubjectCode", "SubjectCode");
            return View();
        }

        // POST: Sessions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SessionId,Topic,LearningTeachingType,StudentMaterials,ConstructiveQuestion,SubjectCode")] Session session)
        {
            try
            {
                if (SessionExists(session.SessionId)){
                    return View(session);
                }
                Session ses = new Session();
                ses.SessionId = session.SessionId;
                ses.Topic = session.Topic;
                ses.LearningTeachingType = session.LearningTeachingType;
                ses.StudentMaterials = session.StudentMaterials;
                ses.ConstructiveQuestion = session.ConstructiveQuestion;
                ses.SubjectCode = session.SubjectCode;
            }
            catch(Exception ex)
            {
                throw ex;
            }

            ViewData["SubjectCode"] = new SelectList(_context.Subject, "SubjectCode", "SubjectCode", session.SubjectCode);
            return RedirectToAction(nameof(Index));
        }

        // GET: Sessions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Session == null)
            {
                return NotFound();
            }

            var session = await _context.Session.FindAsync(id);
            if (session == null)
            {
                return NotFound();
            }
            ViewData["SubjectCode"] = new SelectList(_context.Subject, "SubjectCode", "SubjectCode", session.SubjectCode);
            return View(session);
        }

        // POST: Sessions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit( [Bind("SessionId,Topic,LearningTeachingType,StudentMaterials,ConstructiveQuestion,SubjectCode")] Session session)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var ses = await _context.Session.SingleOrDefaultAsync(s => s.SessionId.Equals(session.SessionId));
                    if(ses == null)
                    {
                        return NotFound();
                    }
                    ses.Topic = session.Topic;
                    ses.LearningTeachingType = ses.LearningTeachingType;
                    ses.StudentMaterials = ses.StudentMaterials;
                    ses.ConstructiveQuestion = ses.ConstructiveQuestion;
                    ses.SubjectCode = ses.SubjectCode;
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    if (!SessionExists(session.SessionId))
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
            ViewData["SubjectCode"] = new SelectList(_context.Subject, "SubjectCode", "SubjectCode", session.SubjectCode);
            return View(session);
        }

        // GET: Sessions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Session == null)
            {
                return NotFound();
            }

            var session = await _context.Session
                .Include(s => s.Subject)
                .FirstOrDefaultAsync(m => m.SessionId == id);
            if (session == null)
            {
                return NotFound();
            }

            return View(session);
        }

        // POST: Sessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var session = await _context.Session.Include(s => s.Subject).FirstOrDefaultAsync(s => s.SessionId == id);
            if(session == null)
            {
                return NotFound();
            }
            _context.Session.RemoveRange(session);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SessionExists(int id)
        {
          return (_context.Session?.Any(e => e.SessionId == id)).GetValueOrDefault();
        }
    }
}
