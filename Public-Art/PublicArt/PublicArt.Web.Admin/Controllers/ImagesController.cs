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
    public class ImagesController : Controller
    {
        private PublicArtEntities db = new PublicArtEntities();

        // GET: Images
        public async Task<ActionResult> Index()
        {
            return View(await db.Images.ToListAsync());
        }

        // GET: Images/<guid>.jpg
        [Route("Images/{id}.jpg")]
        public async Task<ActionResult> View(Guid id)
        {
            var image = await db.Images.FindAsync(id);

            if (image == null)
            {
                return HttpNotFound();
            }

            return File(image.file_stream, "image/jpg");
        }

        // GET: Images/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Images/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "stream_id,file_stream,name,is_directory,unc_path")] Image image)
        {
            if (ModelState.IsValid)
            {
                image.stream_id = Guid.NewGuid();
                db.Images.Add(image);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(image);
        }

        // GET: Images/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Image image = await db.Images.FindAsync(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            return View(image);
        }

        // POST: Images/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Image image = await db.Images.FindAsync(id);
            db.Images.Remove(image);
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
