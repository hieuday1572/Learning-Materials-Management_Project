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
    public class USERSubjectController : Controller
    {
        private readonly AppDbContext _context;

        public USERSubjectController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Subjects
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Subject.Include(s => s.Status);
            return View(await appDbContext.ToListAsync());
        }

      