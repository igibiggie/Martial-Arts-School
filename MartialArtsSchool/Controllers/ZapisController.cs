using Microsoft.AspNetCore.Mvc;

namespace MartialArtsSchool.Controllers
{
    public class ZapisController : Controller
    {
        private readonly MarArtDbContext _db;

        public ZapisController(MarArtDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
