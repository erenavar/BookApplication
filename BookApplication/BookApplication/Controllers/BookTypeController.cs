using BookApplication.Models;
using BookApplication.Utility;
using Microsoft.AspNetCore.Mvc;

namespace BookApplication.Controllers
{
    public class BookTypeController : Controller
    {

        private readonly IBookTypeRepository _bookTypeRepository;

        public BookTypeController(IBookTypeRepository context)
        {
            _bookTypeRepository = context;
        }
        public IActionResult Index()
        {
            List<BookType> objBookTypeList = _bookTypeRepository.GetAll().ToList();
            return View(objBookTypeList);
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(BookType bookType)
        {
            if (ModelState.IsValid) 
                { 
            _bookTypeRepository.Add(bookType);
            _bookTypeRepository.Save();
            TempData["successful"] = "The new book type created successfully.";
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
            BookType? bookTypeDb = _bookTypeRepository.Get(i => i.Id == id);
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
                _bookTypeRepository.Update(bookType);
                _bookTypeRepository.Save();
                TempData["successful"] = "The new book type edit successfully.";

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
            BookType? bookTypeDb = _bookTypeRepository.Get(i => i.Id == id);
            if(bookTypeDb == null)
            {
                return NotFound();
            }
            return View(bookTypeDb);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            BookType? bookType = _bookTypeRepository.Get(i => i.Id == id);
            if(bookType == null)
            {
                return NotFound();
            }
            _bookTypeRepository.Remove(bookType);
            _bookTypeRepository.Save();
            TempData["successful"] = "The book type deleted successfully.";

            return RedirectToAction("Index", "BookType");
        }
    }
}
