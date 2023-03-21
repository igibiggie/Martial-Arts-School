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
    }
}
