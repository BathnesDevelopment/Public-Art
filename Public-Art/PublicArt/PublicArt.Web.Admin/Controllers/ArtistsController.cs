using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PublicArt.DAL;
using PublicArt.Util.Extensions;
using PublicArt.Web.Admin.ViewModels;

namespace PublicArt.Web.Admin.Controllers
{
    public class ArtistsController : Controller
    {
        private readonly PublicArtEntities _db = new PublicArtEntities();

        // GET: Artists
        public ActionResult Index()
        {
            var artistViewModels = _db.Artists.AsEnumerable().Select(a => new ArtistIndexViewModel
            {
                ArtistId = a.ArtistId,
                Name = a.Name,
                WebsiteUrl = a.WebsiteURL,
                WebsiteUrlShort = a.WebsiteURL?.TrimUrl(30),
                Dates = (a.StartYear.HasValue || a.EndYear.HasValue) ? $"{a.StartYear?.ToString() ?? "?"}-{a.EndYear?.ToString() ?? "?"}" : null,
                BiographyShort = a.Biography?.ShortenIfTooLong(150) ?? "No biography",
                ItemsCount = a.ItemArtists.Count
            });

            return View(artistViewModels);
        }

        // GET: Artists/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = await _db.Artists.FindAsync(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        // GET: Artists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Artists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ArtistId,Name,Biography,WebsiteURL,StartYear,EndYear,rowguid,ModifiedDate")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                _db.Artists.Add(artist);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(artist);
        }

        // GET: Artists/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = await _db.Artists.FindAsync(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        // POST: Artists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ArtistId,Name,Biography,WebsiteURL,StartYear,EndYear,rowguid,ModifiedDate")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(artist).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(artist);
        }

        // GET: Artists/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = await _db.Artists.FindAsync(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        // POST: Artists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Artist artist = await _db.Artists.FindAsync(id);
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
