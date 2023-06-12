using LMMProject.Data;
using LMMProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI;

namespace LMMProject.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDbContext _context;       

        public LoginController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var account = new Account();
            return View(account);
        }
        [HttpPost]
        public async Task<IActionResult> Index(Account account)
        {
            if (!ModelState.IsValid)
            {
                return View(account);
            }
            Account user = await _context.Accounts.Include(p => p.Role).FirstOrDefaultAsync(pro => pro.UserName.Equals(account.UserName));
            if (user != null)
            {
                if (user.Password.Equals(account.Password))      
                {
                    return RedirectToAction("DashBoard", "ADMIN");
                }
                TempData["Error"] = "Wrong: please try again!";
                return View(account);
            }
            TempData["Error"] = "Wrong: please try again!";
            return View(account);

        }
    }
}
