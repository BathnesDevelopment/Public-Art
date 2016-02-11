using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
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

        [HttpPost]
        [Route("Upload/{itemId:int}")]
        public async Task<ActionResult> Upload(int itemId, HttpPostedFileBase file)
        {
            if (file == null || file.ContentLength == 0)
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);

            if (file.ContentType != "image/jpeg")
                return new HttpStatusCodeResult(HttpStatusCode.NotImplemented);

            var item = await db.Items.FindAsync(itemId);
            if (item == null) return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);

            byte[] bytes = null;
            using (var reader = new BinaryReader(file.InputStream))
            {
                bytes = reader.ReadBytes(file.ContentLength);
            }

            var itemImage = db.ItemImages.Add(new ItemImage
            {
                Item = item,
                file_stream = bytes,
                Primary = !item.ItemImages.Any()
            });
            await db.SaveChangesAsync();

            // ReSharper disable once AssignNullToNotNullAttribute
            Request.Headers.Add("Location", Url.Action("Image", new {id = itemImage.stream_id}));

            return new HttpStatusCodeResult(HttpStatusCode.Created);
        }

        [HttpPost]
        [Route("{id}.jpg/Delete")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var itemImage = await db.ItemImages.FindAsync(id);

            if (itemImage == null) return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            db.ItemImages.Remove(itemImage);
            await db.SaveChangesAsync();

            return new HttpStatusCodeResult(HttpStatusCode.OK);
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