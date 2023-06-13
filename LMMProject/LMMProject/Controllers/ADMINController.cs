﻿using LMMProject.Data;
using LMMProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMMProject.Controllers
{
    public class ADMINController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _Accessor;
        public ADMINController(AppDbContext context, IHttpContextAccessor accessor)
        {
            _context = context;
            _Accessor = accessor;
        }
        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult Infor()
        {
            string userName=_Accessor.HttpContext.Session.GetString("Username");
            var Account = _context.Account.Include(p => p.Role).FirstOrDefault(pro => pro.UserName.Equals(userName));
            return View(Account);
        }
        [HttpPost]
        public async Task<IActionResult> Infor(Account account)
        {
            var accountChange=_context.Account.Include(p => p.Role).FirstOrDefault(pro => pro.UserName.Equals(account.UserName));
            accountChange.UserName=account.UserName;
            accountChange.Fullname=account.Fullname;
            accountChange.Address=account.Address;
            accountChange.Phone=account.Phone;
            accountChange.Gender=account.Gender;
            accountChange.Birthday=account.Birthday;
           _context.Account.Update(accountChange);
           _context.SaveChanges();
            return RedirectToAction("Infor");
        }

        public IActionResult ListOfCurriculum()
        {
            var listCurriculum = _context.Curriculum.Include(p => p.Decision).ToList();
            return View(listCurriculum);
        }
    }
}
