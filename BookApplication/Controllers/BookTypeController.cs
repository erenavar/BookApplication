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
            return View(objBookTypeList);
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(BookType bookType)
        {
            if (ModelState.IsValid) { 
            _applicationDbContext.BookTypes.Add(bookType);
            _applicationDbContext.SaveChanges();
            return RedirectToAction("Index","BookType");
            }
            return View();
        }

        public IActionResult Update(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            BookType? bookTypeDb = _applicationDbContext.BookTypes.Find(id);
            if(bookTypeDb == null)
            {
                return NotFound();
            }
            return View(bookTypeDb);
        }
        [HttpPost]
        public IActionResult Update(BookType bookType)
        {
            if (ModelState.IsValid)
            {
                _applicationDbContext.BookTypes.Add(bookType);
                _applicationDbContext.SaveChanges();
                return RedirectToAction("Index", "BookType");
            }
            return View();
        }

    }
}
