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
        public readonly IWebHostEnvironment _webHostEnvironment;

        public BookController(IBookRepository bookRepository, IBookTypeRepository bookTypeRepository,IWebHostEnvironment webHostEnvironment)
        {
            _bookRepository = bookRepository;
            _bookTypeRepository = bookTypeRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Book> objBookList = _bookRepository.GetAll().ToList();
          
            return View(objBookList);
        }

        public IActionResult AddEdit(int? id)
        {
            IEnumerable<SelectListItem> BookTypeList = _bookTypeRepository.GetAll().Select(t => new SelectListItem
            {
                Text = t.Name,
                Value = t.Id.ToString()
            });
            ViewBag.BookTypeList = BookTypeList;
            if(id == 0 || id == null)
            {
                return View();
            }else
            {
                Book? bookDb = _bookRepository.Get(i => i.Id == id);
                if (bookDb == null)
                {
                    return NotFound();
                }
                return View(bookDb);
            }

        }
        [HttpPost]
        public IActionResult AddEdit(Book book,IFormFile? file)
        {
            if (ModelState.IsValid) 
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string bookPath = Path.Combine(wwwRootPath, @"img");
                using (var fileStream = new FileStream(Path.Combine(bookPath, file.FileName), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                book.PicUrl = @"\img\" + file.FileName;

                if(book.Id == 0)
                {
                _bookRepository.Add(book);
                 TempData["successful"] = "The new book created successfully.";
                } else
                {
                    _bookRepository.Update(book);
                    TempData["successful"] = "The book was updated successfully.";
                }

                _bookRepository.Save();
                return RedirectToAction("Index","Book");
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
