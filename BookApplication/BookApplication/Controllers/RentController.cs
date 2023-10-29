using BookApplication.Models;
using BookApplication.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookApplication.Controllers
{
    [Authorize(Roles = UserRoles.Role_Admin)]

    public class RentController : Controller
    {

        private readonly IRentRepository _rentRepository;
        private readonly IBookRepository _bookRepository;
        public readonly IWebHostEnvironment _webHostEnvironment;

        public RentController(IRentRepository rentRepository, IBookRepository bookRepository,IWebHostEnvironment webHostEnvironment)
        {
            _rentRepository = rentRepository;
            _bookRepository = bookRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            
            List<Rent> objRentList = _rentRepository.GetAll(includeProps:"Book").ToList();       
            return View(objRentList);
        }

        public IActionResult AddEdit(int? id)
        {
            IEnumerable<SelectListItem> BookList = _bookRepository.GetAll().Select(t => new SelectListItem
            {
                Text = t.Name,
                Value = t.Id.ToString()
            });
            ViewBag.BookList = BookList;
            if(id == 0 || id == null)
            {
                return View();
            }else
            {
                Rent? rentDb = _rentRepository.Get(i => i.Id == id);
                if (rentDb == null)
                {
                    return NotFound();
                }
                return View(rentDb);
            }

        }
        [HttpPost]
        public IActionResult AddEdit(Rent rent)
        {
            if (ModelState.IsValid) 
            {
              
              

                if(rent.Id == 0)
                {
                _rentRepository.Add(rent);
                 TempData["successful"] = "The rent created successfully.";
                } else
                {
                    _rentRepository.Update(rent);
                    TempData["successful"] = "The rented was updated successfully.";
                }

                _rentRepository.Save();
                return RedirectToAction("Index","Rent");
            }
            return View();
        }


        public IActionResult Delete(int? id)
        {
            IEnumerable<SelectListItem> BookList = _bookRepository.GetAll().Select(t => new SelectListItem
            {
                Text = t.Name,
                Value = t.Id.ToString()
            });
            ViewBag.BookList = BookList;


            if (id == null || id == 0)
            {
                return NotFound();
            }
            Rent? rentDb = _rentRepository.Get(i => i.Id == id);
            if(rentDb == null)
            {
                return NotFound();
            }
            return View(rentDb);
        }


        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Rent? rent = _rentRepository.Get(i => i.Id == id);
            if(rent == null)
            {
                return NotFound();
            }
            _rentRepository.Remove(rent);
            _rentRepository.Save();
            TempData["successful"] = "The record deleted successfully.";

            return RedirectToAction("Index", "Rent");
        }
    }
}
