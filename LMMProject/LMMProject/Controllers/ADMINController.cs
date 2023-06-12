using Microsoft.AspNetCore.Mvc;

namespace LMMProject.Controllers
{
    public class ADMINController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
