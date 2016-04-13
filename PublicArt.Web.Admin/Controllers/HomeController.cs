using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;
using PublicArt.DAL;

namespace PublicArt.Web.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly PublicArtEntities _db = new PublicArtEntities();

        public async Task<ActionResult> Index()
        {
            ViewBag.ArtistCount = await _db.Artists.CountAsync();
            ViewBag.ItemCount = await _db.Items.CountAsync();
            return View();
        }
    }
}