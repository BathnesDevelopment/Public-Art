using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using PublicArt.DAL;
using PublicArt.Util.Extensions;
using PublicArt.Web.Admin.ViewModels;

namespace PublicArt.Web.Admin.Controllers
{
    [RoutePrefix("Artists")]
    public class ArtistsController : Controller
    {
        private readonly PublicArtEntities _db = new PublicArtEntities();

        [Route]
        public ActionResult Index()
        {
            var artistViewModels = _db.Artists.OrderBy(a => a.Name).AsEnumerable().Select(a => new ArtistIndexViewModel
            {
                ArtistId = a.ArtistId,
                Name = a.Name,
                WebsiteUrl = a.WebsiteURL,
                WebsiteUrlShort = a.WebsiteURL?.TrimUrl(30),
                Dates =
                    (a.StartYear.HasValue || a.EndYear.HasValue)
                        ? $"{a.StartYear?.ToString() ?? "?"}-{a.EndYear?.ToString() ?? "?"}"
                        : null,
                BiographyShort = a.Biography?.ShortenIfTooLong(150) ?? "No biography",
                ItemsCount = a.ItemArtists.Count
            });

            return View(artistViewModels);
        }

        [Route("New")]
        public ActionResult Create()
        {
            return View();
        }

        [Route("New")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(
            [Bind(Include = "Name,Biography,WebsiteURL,StartYear,EndYear")] Artist artist)
        {
            // TODO: Use viewmodel
            if (ModelState.IsValid)
            {
                _db.Artists.Add(artist);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(artist);
        }

        [Route("{id}")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var artist = await _db.Artists.FindAsync(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        [Route("{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(
            [Bind(Include = "ArtistId,Name,Biography,WebsiteURL,StartYear,EndYear")] Artist artist)
        {
            // TODO: Use viewmodel
            if (ModelState.IsValid)
            {
                _db.Entry(artist).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(artist);
        }

        [Route("{id}/Delete")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var artist = await _db.Artists.FindAsync(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        [Route("{id}/Delete")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var artist = await _db.Artists.FindAsync(id);
            _db.Artists.Remove(artist);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}