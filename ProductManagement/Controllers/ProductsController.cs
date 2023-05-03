using ProductManagement.Data;
using ProductManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace ProductManagement.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDBContext _db;

        public ProductsController(ApplicationDBContext db) {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Products> objproduct = _db.Products;
            return View(objproduct);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Products obj)
        {
            if(ModelState.IsValid)
            {
                _db.Products.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Product Created Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) { return NotFound(); }
            var profromdb = _db.Products.Find(id);
            if (profromdb == null) {return NotFound();}

            return View(profromdb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Products obj)
        {
            if (ModelState.IsValid)
            {
                _db.Products.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Product Updated Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0) { return NotFound(); }
            var profromdb = _db.Products.Find(id);
            if (profromdb == null) { return NotFound(); }

            return View(profromdb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Products.Find(id);
            if (obj == null) { return NotFound(); }

            _db.Products.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Product Deleted Successfully";


            return RedirectToAction("Index");
        }



    }
}
