using crud_mvc.DataContext;
using crud_mvc.Models;

using Microsoft.AspNetCore.Mvc;

namespace crud_mvc.Controllers
{
    public class ItemController1 : Controller
    {
        private readonly ApplicationDbContext _db;


        public ItemController1(ApplicationDbContext db)
        {
            _db = db;
        }




        // GET:
        public IActionResult Index()
        {
            IEnumerable<item_model> objItemlist = _db.Items.ToList();
            return View(objItemlist);
        }

       // GET: 
        public IActionResult add()
        {
            return View();
        }
        //POST:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult add(item_model obj)
        {
            if (ModelState.IsValid)
            {
                _db.Items.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(obj);
        }

        // GET:
        public IActionResult edit(int? id)
        {
            var itemFromDb = _db.Items.Find(id);
            if (itemFromDb == null)
            {
                return NotFound();
            }
            return View(itemFromDb);
        }
        // POST:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult edit( item_model obj)
        {
            if (ModelState.IsValid)
            {
                _db.Items.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(obj);
        }

        // GET:
        public IActionResult delete(int? id)
        {
            var itemFromDb = _db.Items.Find(id);
            if (itemFromDb == null)
            {
                return NotFound();
            }
            return View(itemFromDb);
        }
        // POST:
        [HttpPost,ActionName("delete")]
        [ValidateAntiForgeryToken]
        public IActionResult deletePOST(int? id)
        {
            var obj = _db.Items.Find(id);
            if (obj == null) 
            {
                return NotFound();
            }
            _db.Items.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("index");
        }
        
    }
}

