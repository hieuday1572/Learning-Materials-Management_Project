using LMMProject.Data;
using LMMProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace LMMProject.Controllers;

public class SearchSessionController : Controller
{
    private readonly AppDbContext _context;

    public SearchSessionController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index(string message = "")
    {
        return View(new SearchSessionModel()
        {
            Message = message
        });
    }

    public IActionResult Search(string subjectCode)
    {
        if (string.IsNullOrEmpty(subjectCode))
        {
            return Redirect("/SearchSession/Index?message=Subject Code is requried.");
        }

        var data = _context.Session
            .Where(s => string.IsNullOrEmpty(subjectCode) || s.SubjectCode.Contains(subjectCode))
            .ToList();

        if (data?.Count == 0)
        {
            return Redirect($"/SearchSession/Index?message={subjectCode} do not exists.");
        }

        return View(data);
    }
}