using Hotel.ATR.Web.First.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.ATR.Web.First.Controllers
{
    public class TeamController : Controller
    {
        private AppDbContext db;
        public TeamController(AppDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            List<Team> teams = db.Teams.ToList();

            return View(teams);
        }
    }
}
