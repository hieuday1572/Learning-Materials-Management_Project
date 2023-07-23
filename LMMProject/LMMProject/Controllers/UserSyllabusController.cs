using LMMProject.Data;
using LMMProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace LMMProject.Controllers
{
    public class UserSyllabusController : Controller
    {
        private readonly AppDbContext _context;

        public UserSyllabusController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Syllabus
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string option, string search)
        {
           // HttpContext.Session.SetString("option", option);
            //HttpContext.Session.SetString("search", search);

            List<Syllabus> syllabus;
            if (search != null)
            {
                if (option.Equals("code"))
                {
                    syllabus = await _context.Syllabus.Where(p => p.SubjectCode.Contains(search.Trim())).ToListAsync();
                }
                else
                {
                    syllabus = await _context.Syllabus
                        .Where(p => p.SyllabusNameEn.Contains(search) || p.SyllabusNameVn.Equals(search.Trim()))
                        .ToListAsync();
                }

                if (syllabus.Count() == 0)
                {
                    TempData["error"] = "Sorry: Syllabus not found!";
                }
                return View(syllabus);
            }
            TempData["error"] = "Sorry: Syllabus not found!";
            return View();
        }




        // GET: Syllabus/Details/5
        public async Task<IActionResult> Details(int? id, string? iid)
        {
            if (id == null)
            {
                return NotFound();
            }

            var syllabus = await _context.Syllabus
                .Include(s => s.Decision)
                .Include(s => s.Assessments)
                .Include(e => e.Subject)
                .FirstOrDefaultAsync(m => m.SyllabusId == id);
            if (syllabus == null)
            {
                return NotFound();
            }
            var mate = _context.Material.Include(p => p.Subject).Where(p => p.SubjectCode.Equals(syllabus.SubjectCode)).ToList();
            ViewBag.matte = mate;
            var add_material = _context.MaterialOfTeacher.Include(p => p.Account).Include(p => p.Subject).Where(p => p.SubjectCode.Equals(syllabus.SubjectCode)).Where(p=>p.Status.Equals("approved")).ToList();
            ViewBag.add_material = add_material;
            return View(syllabus);

        }

    }
}
