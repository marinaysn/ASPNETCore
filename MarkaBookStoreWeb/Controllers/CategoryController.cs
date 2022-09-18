using MarkaBookStore.DataAccess;
using MarkaBookStore.DataAccess.Repository.IRepository;
using MarkaBookStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace MarkaBookStore.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _uow;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> obj = _uow.Cat.GetAll();

            return View(obj);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Custom Error", "Name and Display Order should not be the same!");
            }
            if (ModelState.IsValid)
            {
                _uow.Cat.Add(obj);
                _uow.Save();
                TempData["success"] = "Category is successfully created";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //return View();
            var CategoryFromDb = _uow.Cat.GetById((int)id);
            var CategoryFromDbFirst = _uow.Cat.GetFirstOrDefault(x => x.Id == id);

            if (CategoryFromDb == null)
            {
                return NotFound();
            }
            return View(CategoryFromDbFirst);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Custom Error", "Name and Display Order should not be the same!");
            }
            if (ModelState.IsValid)
            {
                _uow.Cat.Update(obj);
                _uow.Save();
                TempData["success"] = "Category is successfully Updated";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //return View();
            var CategoryFromDb = _uow.Cat.GetById((int)id);

            var CategoryFromDbFirst = _uow.Cat.GetFirstOrDefault(x => x.Id == id);


            if (CategoryFromDb == null)
            {
                return NotFound();
            }

            _uow.Cat.Remove(CategoryFromDbFirst);
            _uow.Save();
            TempData["success"] = "Category is successfully Deleted";
            return RedirectToAction("Index");
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Category obj)
        {

            if (ModelState.IsValid)
            {
                _uow.Cat.Remove(obj);
                _uow.Save();
                TempData["success"] = "Category is successfully Deleted";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

    }
}
