using LMMProject.Data;
using Microsoft.AspNetCore.Mvc;

namespace LMMProject.Controllers
{
    public class RoleController : Controller
    {
        private AppDbContext _context;
        public RoleController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var Role = _context.role.ToList();
            return View(Role);
        }
    }
}
