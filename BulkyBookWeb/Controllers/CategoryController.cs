using Microsoft.AspNetCore.Mvc;
using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AplicationDBContext _db; //Local DB Object
        public CategoryController(AplicationDBContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

        //get
        public IActionResult Create()
        {
            return View();
        }

        //get
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "the display order and name cannot be the same");
            }
            if (ModelState.IsValid)
            {

                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

           
                }
    }
}

