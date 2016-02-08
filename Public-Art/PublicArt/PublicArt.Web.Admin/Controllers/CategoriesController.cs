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
using PublicArt.Web.Admin.ViewModels;

namespace PublicArt.Web.Admin.Controllers
{
    [RoutePrefix("Categories")]
    public class CategoriesController : Controller
    {
        private readonly PublicArtEntities _db = new PublicArtEntities();

        [Route("all.json")]
        public async Task<ActionResult> GetAll()
        {
            var categories = await _db.Categories.Select(c => c.Description).ToListAsync();

            return Json(categories, JsonRequestBehavior.AllowGet);
        }


        // POST: Categories/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            Category category = await _db.Categories.FindAsync(id);
            _db.Categories.Remove(category);
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
