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

        public IActionResult Edit(int? id)
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
        public IActionResult Edit(BookType bookType)
        {
            if (ModelState.IsValid)
            {
                _applicationDbContext.BookTypes.Update(bookType);
                _applicationDbContext.SaveChanges();
                return RedirectToAction("Index", "BookType");
            }
            return View();
        }


        public IActionResult Delete(int? id)
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
        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            BookType? bookType = _applicationDbContext.BookTypes.Find(id);
            if(bookType == null)
            {
                return NotFound();
            }
            _applicationDbContext.BookTypes.Remove(bookType);
            _applicationDbContext.SaveChanges();
            return RedirectToAction("Index", "BookType");
        }
    }
}
