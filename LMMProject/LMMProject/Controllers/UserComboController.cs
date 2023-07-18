using LMMProject.Data;
using LMMProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMMProject.Controllers
{
    public class UserComboController : Controller
    {
        private readonly AppDbContext _context;

        public UserComboController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> ListCombo(int? id)
        {
            Curriculum curri = _context.Curriculum.FirstOrDefault(p => p.CurriculumId == id);
            ViewBag.Currii = curri;
            var listCombo = _context.Combo.Include(p => p.Curriculum).Where(pro => pro.CurriculumId == id).ToList();
            return View(listCombo);
        }
        public async Task<IActionResult> DetailCombo(int? id)
        {
            Combo combsub = _context.Combo.FirstOrDefault(p => p.ComboId == id);
            ViewBag.Combosub = combsub;
            var listSubject = _context.Combo_Subject.Include(a => a.Subject).Include(b => b.Combo).Where(pro => pro.ComboId == id).ToList();
            return View(listSubject);
        }
    }
}
