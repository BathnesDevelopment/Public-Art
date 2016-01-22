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
    public class ItemCategoriesController : Controller
    {
        private PublicArtEntities db = new PublicArtEntities();

        // GET: ItemCategories
        public async Task<ActionResult> Index()
        {
            var itemCategories = db.ItemCategories.Include(i => i.Category).Include(i => i.Item);
            return View(await itemCategories.ToListAsync());
        }

        // GET: ItemCategories/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Description");
            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "Reference");
            return View();
        }

        // POST: ItemCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ItemId,CategoryId,rowguid,ModifiedDate")] ItemCategory itemCategory)
        {
            if (ModelState.IsValid)
            {
                db.ItemCategories.Add(itemCategory);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Description", itemCategory.CategoryId);
            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "Reference", itemCategory.ItemId);
            return View(itemCategory);
        }

        // GET: ItemCategories/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemCategory itemCategory = await db.ItemCategories.FindAsync(id);
            if (itemCategory == null)
            {
                return HttpNotFound();
            }
            return View(itemCategory);
        }

        // POST: ItemCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ItemCategory itemCategory = await db.ItemCategories.FindAsync(id);
            db.ItemCategories.Remove(itemCategory);
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
