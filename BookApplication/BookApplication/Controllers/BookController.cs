using BookApplication.Models;
using BookApplication.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookApplication.Controllers
{
    public class BookController : Controller
    {

        private readonly IBookRepository _bookRepository;
        private readonly IBookTypeRepository _bookTypeRepository;

        public BookController(IBookRepository bookRepository, IBookTypeRepository bookTypeRepository)
        {
            _bookRepository = bookRepository;
            _bookTypeRepository = bookTypeRepository;
        }
        public IActionResult Index()
        {
            List<Book> objBookList = _bookRepository.GetAll().ToList();
          
            return View(objBookList);
        }

        public IActionResult Add()
        {
            IEnumerable<SelectListItem> BookTypeList = _bookTypeRepository.GetAll().Select(t => new SelectListItem
            {
                Text = t.Name,
                Value = t.Id.ToString()
            });
            ViewBag.BookTypeList = BookTypeList;
            return View();
        }
        [HttpPost]
        public IActionResult Add(Book book)
        {
            if (ModelState.IsValid) 
                { 
            _bookRepository.Add(book);
            _bookRepository.Save();
            TempData["successful"] = "The new book created successfully.";
            return RedirectToAction("Index","Book");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            Book? bookDb = _bookRepository.Get(i => i.Id == id);
            if(bookDb == null)
            {
                return NotFound();
            }
            return View(bookDb);
        }
        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                _bookRepository.Update(book);
                _bookRepository.Save();
                TempData["successful"] = "The new book edit successfully.";

                return RedirectToAction("Index", "Book");
            }
            return View();
        }


        public IActionResult Delete(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            Book? bookDb = _bookRepository.Get(i => i.Id == id);
            if(bookDb == null)
            {
                return NotFound();
            }
            return View(bookDb);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Book? book = _bookRepository.Get(i => i.Id == id);
            if(book == null)
            {
                return NotFound();
            }
            _bookRepository.Remove(book);
            _bookRepository.Save();
            TempData["successful"] = "The book deleted successfully.";

            return RedirectToAction("Index", "Book");
        }
    }
}
