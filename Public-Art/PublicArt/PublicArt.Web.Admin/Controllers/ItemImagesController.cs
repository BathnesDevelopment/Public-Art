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
    public class ItemImagesController : Controller
    {
        private PublicArtEntities db = new PublicArtEntities();

        // GET: ItemImages
        public async Task<ActionResult> Index()
        {
            var itemImages = db.ItemImages.Include(i => i.Item).Include(i => i.Image);
            return View(await itemImages.ToListAsync());
        }

        // GET: ItemImages/Create
        public ActionResult Create()
        {
            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "Reference");
            ViewBag.stream_id = new SelectList(db.Images, "stream_id", "name");
            return View();
        }

        // POST: ItemImages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ItemId,stream_id,Order,Caption,rowguid,ModifiedDate")] ItemImage itemImage)
        {
            if (ModelState.IsValid)
            {
                db.ItemImages.Add(itemImage);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "Reference", itemImage.ItemId);
            ViewBag.stream_id = new SelectList(db.Images, "stream_id", "name", itemImage.stream_id);
            return View(itemImage);
        }

        // GET: ItemImages/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemImage itemImage = await db.ItemImages.FindAsync(id);
            if (itemImage == null)
            {
                return HttpNotFound();
            }
            return View(itemImage);
        }

        // POST: ItemImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ItemImage itemImage = await db.ItemImages.FindAsync(id);
            db.ItemImages.Remove(itemImage);
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
