using MartialArtsSchool.Models;
using Microsoft.AspNetCore.Mvc;

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
    }
}
