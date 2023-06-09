using MartialArtsSchool.Models;
using Microsoft.AspNetCore.Mvc;

namespace MartialArtsSchool.Controllers
{
    public class MemberController : Controller
    {
        private readonly MarArtDbContext _db;

        public MemberController(MarArtDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Member> members = _db.Members;
            return View(members);
        }

        //GET CREATE
        public IActionResult Create()
        {
            return View();
        }

        //POST CREATE
        [HttpPost]
        public IActionResult Create(Member obj)
        {
            if (ModelState.IsValid)
            {
                _db.Members.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Member created successfully";
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
            var categoryFromDb = _db.Members.Find(id);

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
            var categoryFromDb = _db.Members.Find(id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        //POST EDIT
        [HttpPost]
        public IActionResult Edit(Member obj)
        {
            if (ModelState.IsValid)
            {
                _db.Members.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Members updated successfully";
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
            var categoryFromDb = _db.Members.Find(id);

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
            var obj = _db.Members.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Members.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Member deleted successfully";
            return RedirectToAction("Index");

        }

    }
}
