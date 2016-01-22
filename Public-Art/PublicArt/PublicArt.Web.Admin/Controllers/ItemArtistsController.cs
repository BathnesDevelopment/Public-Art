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

namespace PublicArt.Web.Admin.Controllers
{
    public class ItemArtistsController : Controller
    {
        private PublicArtEntities db = new PublicArtEntities();

        // GET: ItemArtists
        public async Task<ActionResult> Index()
        {
            var itemArtists = db.ItemArtists.Include(i => i.Artist).Include(i => i.Item);
            return View(await itemArtists.ToListAsync());
        }

        // GET: ItemArtists/Create
        public ActionResult Create()
        {
            ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "Name");
            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "Reference");
            return View();
        }

        // POST: ItemArtists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ItemId,ArtistId,Notes,rowguid,ModifiedDate")] ItemArtist itemArtist)
        {
            if (ModelState.IsValid)
            {
                db.ItemArtists.Add(itemArtist);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ArtistId = new SelectList(db.Artists, "ArtistId", "Name", itemArtist.ArtistId);
            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "Reference", itemArtist.ItemId);
            return View(itemArtist);
        }

        // GET: ItemArtists/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemArtist itemArtist = await db.ItemArtists.FindAsync(id);
            if (itemArtist == null)
            {
                return HttpNotFound();
            }
            return View(itemArtist);
        }

        // POST: ItemArtists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ItemArtist itemArtist = await db.ItemArtists.FindAsync(id);
            db.ItemArtists.Remove(itemArtist);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
