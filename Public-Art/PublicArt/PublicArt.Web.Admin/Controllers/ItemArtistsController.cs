using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using PublicArt.DAL;
using PublicArt.Web.Admin.ViewModels;

namespace PublicArt.Web.Admin.Controllers
{
    [RoutePrefix("ItemArtists")]
    public class ItemArtistsController : Controller
    {
        private readonly PublicArtEntities db = new PublicArtEntities();

        [HttpPost]
        [Route("")]
        public async Task<ActionResult> Create(
            [Bind(Include = "ItemId,ArtistId,Notes")] ItemArtistCreateViewModel viewModel)
        {
            var itemArtist = await db.ItemArtists.FindAsync(viewModel.ItemId, viewModel.ArtistId);

            if (itemArtist != null) return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);

            var itemExists = await db.Items.AnyAsync(i => i.ItemId == viewModel.ItemId);
            var artistExists = await db.Artists.AnyAsync(a => a.ArtistId == viewModel.ArtistId);

            if (!(itemExists && artistExists)) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            itemArtist = new ItemArtist
            {
                ArtistId = viewModel.ArtistId,
                ItemId = viewModel.ItemId,
                Notes = viewModel.Notes
            };

            db.ItemArtists.Add(itemArtist);

            await db.SaveChangesAsync();

            return new HttpStatusCodeResult(HttpStatusCode.NoContent);
        }

        [HttpPost]
        [Route("Delete")]
        public async Task<ActionResult> Delete(int itemId, int artistId)
        {
            var itemArtist = await db.ItemArtists.FindAsync(itemId, artistId);

            if (itemArtist == null) return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            db.ItemArtists.Remove(itemArtist);
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