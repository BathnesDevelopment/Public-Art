using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using PublicArt.DAL;
using PublicArt.Util.Imaging;

namespace PublicArt.Web.Admin.Controllers
{
    [RoutePrefix("Images")]
    public class ItemImagesController : Controller
    {
        private readonly PublicArtEntities db = new PublicArtEntities();

        // GET: Images/<guid>.jpg
        [Route("{id}.jpg")]
        public async Task<ActionResult> Image(Guid id)
        {
            var image = await db.ItemImages.FindAsync(id);

            if (image == null)
            {
                return HttpNotFound();
            }

            return File(image.file_stream, "image/jpg");
        }

        // GET: Images/Thumb/<guid>.jpg?w=100
        [Route("Thumb/{id}.jpg")]
        // TODO: Parameterize default thumbnail magnitude
        // TODO: Sanitize w parameter input to prevent abuse
        public async Task<ActionResult> Thumb(Guid id, int w = 100)
        {
            // Try to fetch thumbnail from db
            var thumb = await db.ImageThumbnails.FindAsync(id, w);
            if (thumb != null) return File(thumb.file_stream, "image/jpg");

            // Thumb doesnt exist so fetch main image
            var image = await db.ItemImages.FindAsync(id);
            if (image == null) return HttpNotFound();

            // Create new thumbnail from full image
            thumb = new ImageThumbnail
            {
                stream_id = image.stream_id,
                magnitude = w,
                file_stream = await Thumbnailer.CreateThumbAsync(image.file_stream, w)
            };

            // Save to db
            db.ImageThumbnails.Add(thumb);
            //db.Entry(image).State = EntityState.Unchanged;
            await db.SaveChangesAsync();

            // Return the new thumbnail image data
            return File(thumb.file_stream, "image/jpg");
        }

        // POST: Images/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Create")]
        public async Task<ActionResult> Create(
            [Bind(Include = "ItemId,Primary,Caption,file_stream")] ItemImage itemImage)
        {
            if (!ModelState.IsValid) return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);

            db.ItemImages.Add(itemImage);
            await db.SaveChangesAsync();

            // ReSharper disable once AssignNullToNotNullAttribute
            Request.Headers.Add("Location", Url.Action("Image", new { id = itemImage.stream_id }));

            return new HttpStatusCodeResult(HttpStatusCode.Created);
        }

        // POST: Images/<guid>.jpg/Delete/
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("{id}.jpg/Delete")]
        public async Task<ActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid) return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);

            var itemImage = await db.ItemImages.FindAsync(id);
            db.ItemImages.Remove(itemImage);
            await db.SaveChangesAsync();

            return new HttpStatusCodeResult(HttpStatusCode.NoContent);
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