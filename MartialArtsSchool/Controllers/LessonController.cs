using MartialArtsSchool.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MartialArtsSchool.Controllers
{
    public class LessonController : Controller
    {
        private readonly MarArtDbContext _db;

        public LessonController(MarArtDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Lesson> lessons = _db.Lessons;
            return View(lessons);
        }

        //GET CREATE
        public IActionResult Create()
        {
            return View();
        }

        //POST CREATE
        [HttpPost]
        public IActionResult Create(Lesson obj)
        {
            if (ModelState.IsValid)
            {
                _db.Lessons.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Lesson created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET VIEW
        public IActionResult View(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Lessons.Include(l => l.IdMemebers).SingleOrDefault(l => l.IdLesson == id);

            ViewBag.LessonList = new SelectList(_db.Lessons, "IdLesson", "Name");
            // poczytać

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }
        // bez metody post, bo nic nie edytuję

        //GET EDIT
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Lessons.Find(id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        //POST EDIT
        [HttpPost]
        public IActionResult Edit(Lesson obj)
        {
            if (ModelState.IsValid)
            {
                _db.Lessons.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Lessons updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Lessons.Find(id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        //POST DELETE
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Lessons.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Lessons.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Lesson deleted successfully";
            return RedirectToAction("Index");

        }

        //GET VIEW
        public IActionResult ViewMembers(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var ter = _db.Lessons.Find(id);
            IEnumerable<Member> categoryFromDb2 = _db.Lessons.Find(id).IdMemebers;
  
            if (categoryFromDb2 == null)
            {
                return NotFound();
            }

            return View(categoryFromDb2);
        }

       
    }
}
