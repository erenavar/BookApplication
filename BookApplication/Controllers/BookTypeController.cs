using BookApplication.Models;
using BookApplication.Utility;
using Microsoft.AspNetCore.Mvc;

namespace BookApplication.Controllers
{
    public class BookTypeController : Controller
    {

        private readonly ApplicationDbContext _applicationDbContext;

        public BookTypeController(ApplicationDbContext context)
        {
            _applicationDbContext = context;
        }
        public IActionResult Index()
        {
            List<BookType> objBookTypeList = _applicationDbContext.BookTypes.ToList();
            return View();
        }
    }
}
