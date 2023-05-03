using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProductManagement.Data;
using ProductManagement.Models;

namespace ProductManagement.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDBContext _db;

        public CartController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Cart()
        {
            Models.Cart c = new Cart();
            c.Id = 0;
            return View("Index",c);
        }
        public IActionResult Index(int? id)
        {
            if(id == null || id ==  0) { return NotFound(); }
            var profromdb = _db.Products.Find(id);
            if(profromdb == null) { return NotFound(); }

            Models.Cart c = new Cart();
            c.Id = profromdb.Id;
            c.Name = profromdb.Name;
            c.Description = profromdb.Description;
            c.Price = profromdb.Price;
            c.Quantity = 1;
            return View(c);
        }

        public IActionResult Plus(int? id,int Quan)
        {
            if (id == null || id == 0) { return NotFound(); }
            var profromdb = _db.Products.Find(id);
            if (profromdb == null) { return NotFound(); }

            Models.Cart c = new Cart();
            c.Id = profromdb.Id;
            c.Name = profromdb.Name;
            c.Description = profromdb.Description;
            c.Price = profromdb.Price;
            c.Quantity = Quan+1;
            return View("Index", c);
        }

        public IActionResult Minus(int? id, int Quan)
        {
            if (id == null || id == 0) { return NotFound(); }
            var profromdb = _db.Products.Find(id);
            if (profromdb == null) { return NotFound(); }

            Models.Cart c = new Cart();
            c.Id = profromdb.Id;
            c.Name = profromdb.Name;
            c.Description = profromdb.Description;
            c.Price = profromdb.Price;
            c.Quantity = Quan - 1;
            return View("Index", c);
        }
    }
}
