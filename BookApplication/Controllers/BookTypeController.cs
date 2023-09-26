using Microsoft.AspNetCore.Mvc;

namespace BookApplication.Controllers
{
    public class BookTypeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
