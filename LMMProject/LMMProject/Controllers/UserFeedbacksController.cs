using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LMMProject.Data;
using LMMProject.Models;
using static Microsoft.AspNetCore.Razor.Language.TagHelperMetadata;
using CloudinaryDotNet;

namespace LMMProject.Controllers
{
    public class UserFeedbacksController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _Accessor;

        public UserFeedbacksController(AppDbContext context)
        {
            _context = context;
        }

        // GET: UserFeedbacks
        public async Task<IActionResult> Index()
        {
            string loggedInUserName = HttpContext.Session.GetString("Username");

            if (loggedInUserName == null)
            {
                // Redirect to login page or handle unauthorized access.
                // For simplicity, I will redirect to the login page.
                return RedirectToAction("Index", "Login");
            }

            // Filter feedbacks by UserNameFrom
            var userFeedbacks = await _context.feedback
                .Where(f => f.UserNameFrom == loggedInUserName)
                .ToListAsync();

            return View(userFeedbacks);
        }

        // GET: UserFeedbacks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.feedback == null)
            {
                return NotFound();
            }

            var feedback = await _context.feedback
                .Include(f => f.Account)
                .FirstOrDefaultAsync(m => m.FeedbackId == id);
            if (feedback == null)
            {
                return NotFound();
            }

            return View(feedback);
        }

        // GET: UserFeedbacks/Create
        public IActionResult Create(string id)
        {
            string loggedInUserName = HttpContext.Session.GetString("Username");
            ViewData["UserNameTo"] = new SelectList(_context.Account, "UserName", "UserName");
            ViewData["UserNameFrom"] = loggedInUserName; // Lưu giá trị UserName vào ViewData
            return View();
        }

        // POST: UserFeedbacks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FeedbackId,Content,UserNameTo,UserNameFrom,Title,CreateDate")] Feedback feedback)
        {    
            if (ModelState.IsValid)
            {
                _context.Add(feedback);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserNameTo"] = new SelectList(_context.Account, "UserName", "UserName", feedback.UserNameTo);
            return View(feedback);
        }

        // GET: UserFeedbacks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.feedback == null)
            {
                return NotFound();
            }

            var feedback = await _context.feedback.FindAsync(id);
            if (feedback == null)
            {
                return NotFound();
            }
            ViewData["UserNameTo"] = new SelectList(_context.Account, "UserName", "UserName", feedback.UserNameTo);
            return View(feedback);
        }

        // POST: UserFeedbacks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FeedbackId,Content,UserNameTo,UserNameFrom,Title,CreateDate")] Feedback feedback)
        {
            if (id != feedback.FeedbackId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(feedback);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeedbackExists(feedback.FeedbackId))
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
            ViewData["UserNameTo"] = new SelectList(_context.Account, "UserName", "UserName", feedback.UserNameTo);
            return View(feedback);
        }

        // GET: UserFeedbacks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.feedback == null)
            {
                return NotFound();
            }

            var feedback = await _context.feedback
                .Include(f => f.Account)
                .FirstOrDefaultAsync(m => m.FeedbackId == id);
            if (feedback == null)
            {
                return NotFound();
            }

            return View(feedback);
        }

        // POST: UserFeedbacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.feedback == null)
            {
                return Problem("Entity set 'AppDbContext.feedback'  is null.");
            }
            var feedback = await _context.feedback.FindAsync(id);
            if (feedback != null)
            {
                _context.feedback.Remove(feedback);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FeedbackExists(int id)
        {
            return (_context.feedback?.Any(e => e.FeedbackId == id)).GetValueOrDefault();
        }
    }
}
