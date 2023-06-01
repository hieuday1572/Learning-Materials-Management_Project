using LMMProject.Data;
using LMMProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace LMMProject.Controllers
{
    public class AccountController : Controller
    {
        private AppDbContext _context;
        public AccountController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        { 
            var Accounts = _context.account.ToList();
            return View(Accounts); 
        }
    }
}
