using LMMProject.Data;
using LMMProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMMProject.Controllers
{
    public class UserCurriculumController : Controller
    {
        private readonly AppDbContext _context;
        public UserCurriculumController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string option, string search)
        {
            List<Curriculum> curriculum;
            if (option.Equals("code"))
            {
                curriculum=_context.Curriculum.Include(p=>p.Decision).Where(p=>p.CurriculumCode.Contains(search)).ToList();
            }
            else
            {
                curriculum = _context.Curriculum.Include(p => p.Decision).Where(p => (p.NameEn.Contains(search)||p.NameVn.Equals(search))).ToList();
            }
            if (curriculum.Count()==0)
            {
                TempData["error"] = "Sorry: Curriculum not found !";
            }
            return View(curriculum);
        }
    }
}
