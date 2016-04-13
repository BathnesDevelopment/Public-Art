using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using PublicArt.DAL;

namespace PublicArt.Web.Admin.Controllers
{
    [RoutePrefix("ItemCategories")]
    public class ItemCategoriesController : Controller
    {
        private readonly PublicArtEntities _db = new PublicArtEntities();

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> Create(int itemId, string categoryName)
        {
            var item = await _db.Items.FindAsync(itemId);

            // Item doesn't exist - error
            if (item == null) return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            var category = await _db.Categories.FirstOrDefaultAsync(c => c.Description == categoryName);

            if (category == null)
            {
                // No category exists with this name so create it
                category = new Category
                {
                    Description = categoryName
                };

                _db.Categories.Add(category);

                await _db.SaveChangesAsync();
            }

            // If category association already exists just return OK
            if (item.ItemCategories.Any(c => c.CategoryId == category.CategoryId))
                return new HttpStatusCodeResult(HttpStatusCode.NoContent);

            var itemCategory = new ItemCategory
            {
                ItemId = item.ItemId,
                CategoryId = category.CategoryId
            };
            _db.ItemCategories.Add(itemCategory);

            await _db.SaveChangesAsync();

            return new HttpStatusCodeResult(HttpStatusCode.NoContent);
        }

        // POST: ItemCategories/Delete/5
        [HttpPost]
        [Route("Delete")]
        public async Task<ActionResult> Delete(int itemId, int categoryId)
        {
            var itemCategory = await _db.ItemCategories.FindAsync(itemId, categoryId);
            if (itemCategory == null) return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            _db.ItemCategories.Remove(itemCategory);
            await _db.SaveChangesAsync();

            return new HttpStatusCodeResult(HttpStatusCode.NoContent);
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