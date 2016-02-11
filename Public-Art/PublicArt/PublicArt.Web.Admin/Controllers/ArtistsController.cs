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
                    a.StartYear.HasValue || a.EndYear.HasValue
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
            [Bind(Include = "Name,Biography,WebsiteURL,StartYear,EndYear")] ArtistCreateViewModel artistViewModel)
        {
            if (await _db.Artists.AnyAsync(a => a.Name.Equals(artistViewModel.Name)))
                ModelState.AddModelError("Name", "An artist with this name already exists");

            if (!ModelState.IsValid)
                return View(artistViewModel);

            var artist = new Artist
            {
                Name = artistViewModel.Name,
                Biography = artistViewModel.Biography,
                WebsiteURL = artistViewModel.WebsiteUrl,
                StartYear = artistViewModel.StartYear,
                EndYear = artistViewModel.EndYear
            };

            _db.Artists.Add(artist);
            await _db.SaveChangesAsync();

            return new RedirectResult(Url.Action("Index") + "#" + artist.ArtistId);
        }

        [Route("{id:int}")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var artist = await _db.Artists.FindAsync(id);
            if (artist == null) return HttpNotFound();

            var artistViewModel = new ArtistEditViewModel
            {
                ArtistId = artist.ArtistId,
                Name = artist.Name,
                Biography = artist.Biography,
                WebsiteUrl = artist.WebsiteURL,
                StartYear = artist.StartYear,
                EndYear = artist.EndYear
            };

            return View(artistViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("{id:int}")]
        public async Task<ActionResult> Edit(
            [Bind(Include = "ArtistId,Name,Biography,WebsiteURL,StartYear,EndYear")] ArtistEditViewModel artistViewModel)
        {
            var artist = await _db.Artists.FindAsync(artistViewModel.ArtistId);

            if (artist == null) return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            if (
                await
                    _db.Artists.AnyAsync(
                        a => a.Name.Equals(artistViewModel.Name) && a.ArtistId != artistViewModel.ArtistId))
                ModelState.AddModelError("Name", "An artist with this name already exists");

            if (!ModelState.IsValid) return View(artistViewModel);

            // TODO: Implement automapper for viewmodels
            artist.Name = artistViewModel.Name;
            artist.Biography = artistViewModel.Biography;
            artist.WebsiteURL = artistViewModel.WebsiteUrl;
            artist.StartYear = artistViewModel.StartYear;
            artist.EndYear = artistViewModel.EndYear;

            await _db.SaveChangesAsync();

            return new RedirectResult(Url.Action("Index") + "#" + artist.ArtistId);
        }

        [Route("{id:int}/Delete")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var artist = await _db.Artists.FindAsync(id);
            if (artist == null) return HttpNotFound();

            var artistViewModel = new ArtistDeleteViewModel
            {
                ArtistId = artist.ArtistId,
                Name = artist.Name,
                Biography = artist.Biography
            };

            return View(artistViewModel);
        }

        [Route("{id:int}/Delete")]
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