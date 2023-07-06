﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LMMProject.Data;
using LMMProject.Models;
using MySqlX.XDevAPI;
using CloudinaryDotNet.Actions;
using static Microsoft.AspNetCore.Razor.Language.TagHelperMetadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LMMProject.Controllers
{
    public class ADMINSubjectController : Controller
    {
        private readonly AppDbContext _context;

        public ADMINSubjectController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Subjects
        public async Task<IActionResult> Index()
        {
            IEnumerable<Subject> appDbContext = await _context.Subject.Include(s => s.Status).ToListAsync();
            return View(appDbContext);
        }

        // GET: Subjects/Create
        public IActionResult Create()
        {
            ViewData["SubjectCode"] = new SelectList(_context.Status, "SubjectCode", "SubjectCode");
            return View();
        }
        //GET: POST:Subject/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubjectCode,SubjectNameVn,SubjectNameEn,PreRequisite,StatusId")] Subject subject)
        {
            try
            {
                if (SubjectExists(subject.SubjectCode))
                {
                    return View(subject);
                }
                Subject sub = new Subject();
                sub.SubjectCode = subject.SubjectCode;
                sub.SubjectNameVn = subject.SubjectNameVn;
                sub.SubjectNameEn = subject.SubjectNameEn;
                sub.PreRequisite = subject.PreRequisite;
                sub.StatusId = subject.StatusId;
                _context.Subject.AddAsync(sub);
                await _context.SaveChangesAsync();


            }
            catch (Exception ex)
            {
                throw ex;
            }
            ViewData["StatusId"] = new SelectList(_context.Status, "StatusId", "StatusId", subject.StatusId);
            return RedirectToAction(nameof(Index));

        }

        // GET: Subjects/Edit/5
        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null || _context.Subject == null)
            {
                return NotFound();
            }

            var subject = await _context.Subject.FindAsync(id);
            if (subject == null)
            {
                return NotFound();
            }
            ViewData["StatusId"] = new SelectList(_context.Status, "StatusId", "StatusName", subject.StatusId);
            return View(subject);
        }

        // POST: Subjects/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit( [Bind("SubjectCode,SubjectNameVn,SubjectNameEn,PreRequisite,StatusId")] Subject subject)
        {
           
            
                try
                {
                var sub = await _context.Subject.SingleOrDefaultAsync(s => s.SubjectCode.Equals(subject.SubjectCode));
                if (sub == null)
                {
                    return NotFound();
                }
                    sub.SubjectNameVn = subject.SubjectNameVn;
                    sub.SubjectNameEn = subject.SubjectNameEn;
                    sub.PreRequisite = subject.PreRequisite;
                    sub.StatusId = subject.StatusId;
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    if (!SubjectExists(subject.SubjectCode))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            ViewData["StatusId"] = new SelectList(_context.Status, "StatusId", "StatusId", subject.StatusId);
            return RedirectToAction(nameof(Index));
        }


        // GET: Subjects/Delete/5
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null || _context.Subject == null)
            {
                return NotFound();
            }

            var subject = await _context.Subject
                .Include(s => s.Status)
                .FirstOrDefaultAsync(m => m.SubjectCode == id);
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }

        // POST: Subjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var subject = await _context.Subject.Include(s => s.Status).FirstOrDefaultAsync(s => s.SubjectCode == id);
            if (subject == null)
            {
                return NotFound();
            }

            _context.Subject.RemoveRange(subject);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        private bool SubjectExists(string id)
        {
            bool isExist = (_context.Subject?.Any(e => e.SubjectCode == id)).GetValueOrDefault();
            return isExist;
        }


    }
}
