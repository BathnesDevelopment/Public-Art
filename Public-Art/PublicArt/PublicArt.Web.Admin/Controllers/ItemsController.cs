using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using PublicArt.DAL;
using PublicArt.Util.Extensions;
using PublicArt.Util.Spatial;
using PublicArt.Web.Admin.ViewModels;

namespace PublicArt.Web.Admin.Controllers
{
    [RoutePrefix("Items")]
    public class ItemsController : Controller
    {
        private readonly PublicArtEntities _db = new PublicArtEntities();

        // GET: Items
        [Route]
        public async Task<ActionResult> Index()
        {
            var items = await _db.Items.ToListAsync();
            var viewModels = items.Select(x => new ItemIndexViewModel
            {
                ItemId = x.ItemId,
                ThumbnailGuid = x.ItemImages.Where(i => i.Primary).Select(i => i.stream_id).FirstOrDefault(),
                Reference = x.Reference,
                Title = x.Title.ShortenIfTooLong(40),
                Date = x.Date,
                Artists = x.ItemArtists.Select(a => new ItemIndexArtistViewModel
                {
                    ArtistId = a.ArtistId,
                    Name = a.Artist.Name,
                    Notes = a.Notes
                }),
                Categories = x.ItemCategories.ToDictionary(c => c.CategoryId, c => c.Category.Description),
                ModifiedDate = x.ModifiedDate
            });
            return View(viewModels);
        }

        // GET: Items/Create
        [Route("New")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("New")]
        public async Task<ActionResult> Create(
            [Bind(Include = "Reference,Title,Description")] ItemCreateViewModel itemViewModel)
        {
            if (await _db.Items.AnyAsync(i => i.Reference == itemViewModel.Reference))
                ModelState.AddModelError("Reference", "Item reference already exists.");

            if (!ModelState.IsValid) return View(itemViewModel);

            var item = new Item
            {
                Reference = itemViewModel.Reference,
                Title = itemViewModel.Title,
                Description = itemViewModel.Description,
                Published = false
            };

            _db.Items.Add(item);
            await _db.SaveChangesAsync();

            return RedirectToAction("Edit", new {id = item.ItemId});
        }

        // GET: Items/5
        [Route("{id:int}")]
        public async Task<ActionResult> Edit(int id)
        {
            var item = await _db.Items.FindAsync(id);

            if (item == null)
            {
                return HttpNotFound();
            }

            var viewModel = new ItemEditViewModel
            {
                ItemId = item.ItemId,
                Reference = item.Reference,
                Title = item.Title,
                Description = item.Description,
                Date = item.Date,
                UnveilingYear = item.UnveilingYear,
                UnveilingDetails = item.UnveilingDetails,
                Statement = item.Statement,
                Material = item.Material,
                Inscription = item.Inscription,
                History = item.History,
                Notes = item.Notes,
                WebsiteUrl = item.WebsiteUrl,
                Height = item.Height,
                Width = item.Width,
                Depth = item.Depth,
                Diameter = item.Diameter,
                SurfaceCondition = item.SurfaceCondition,
                StructuralCondition = item.StructuralCondition,
                Address = item.Address,
                Latitude = item.Location?.Latitude,
                Longitude = item.Location?.Longitude,
                Published = item.Published,
                ModifiedDate = item.ModifiedDate,
                Artists = item.ItemArtists.Select(a => new ItemEditArtistViewModel
                {
                    ArtistId = a.ArtistId,
                    Name = a.Artist.Name,
                    Notes = a.Notes
                }),
                Categories = item.ItemCategories.ToDictionary(c => c.CategoryId, c => c.Category.Description),
                Images = item.ItemImages.Select(i => new ItemEditItemImageViewModel
                {
                    stream_id = i.stream_id,
                    Primary = i.Primary,
                    Caption = i.Caption
                }),
                ArtistDictionary =
                    await _db.Artists.OrderBy(a => a.Name).ToDictionaryAsync(a => a.ArtistId, a => a.Name)
            };

            return View(viewModel);
        }

        // POST: Items/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("{id:int}")]
        public async Task<ActionResult> Edit(
            [Bind(
                Include =
                    "ItemId,Reference,Title,Description,Date,UnveilingYear,UnveilingDetails,Statement,Material,Inscription,History,Notes,WebsiteURL,Height,Width,Depth,Diameter,SurfaceCondition,StructuralCondition,Address,Latitude,Longitude,Published,Artists,Categories,Images"
                )] ItemEditViewModel itemViewModel)
        {
            if (!ModelState.IsValid) return View(itemViewModel);

            var item = await _db.Items.FindAsync(itemViewModel.ItemId);

            // TODO: Implement automapper for viewmodels
            //item.Reference = itemViewModel.Reference;
            item.Title = itemViewModel.Title;
            item.Description = itemViewModel.Description;
            item.Date = itemViewModel.Date;
            item.UnveilingYear = itemViewModel.UnveilingYear;
            item.UnveilingDetails = itemViewModel.UnveilingDetails;
            item.Statement = itemViewModel.Statement;
            item.Material = itemViewModel.Material;
            item.Inscription = itemViewModel.Inscription;
            item.History = itemViewModel.History;
            item.Notes = itemViewModel.Notes;
            item.WebsiteUrl = itemViewModel.WebsiteUrl;
            item.Height = itemViewModel.Height;
            item.Width = itemViewModel.Width;
            item.Depth = itemViewModel.Depth;
            item.Diameter = itemViewModel.Diameter;
            item.SurfaceCondition = itemViewModel.SurfaceCondition;
            item.StructuralCondition = itemViewModel.StructuralCondition;
            item.Address = itemViewModel.Address;
            item.Location = itemViewModel.Latitude.HasValue && itemViewModel.Longitude.HasValue
                ? Geography.CreateFromLatLng(itemViewModel.Longitude.Value, itemViewModel.Latitude.Value)
                : null;
            item.Published = itemViewModel.Published;

            await _db.SaveChangesAsync();

            foreach (var img in itemViewModel.Images)
            {
                var itemImage = item.ItemImages.First(i => i.stream_id == img.stream_id);
                itemImage.Caption = img.Caption;
            }

            await _db.SaveChangesAsync();

            // Set primary
            _db.SetPrimaryItemImage(item.ItemId, itemViewModel.Images.First(i => i.Primary).stream_id);

            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [Route("{id:int}/Delete")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var item = await _db.Items.FindAsync(id);

            if (item == null) return HttpNotFound();

            var viewModel = new ItemDeleteViewModel
            {
                ItemId = item.ItemId,
                Title = item.Title,
                Reference = item.Reference,
                Description = item.Description,
                PrimaryImage = item.ItemImages.FirstOrDefault(i => i.Primary)?.stream_id
            };

            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("{id:int}/Delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var item = await _db.Items.FindAsync(id);
            _db.Items.Remove(item);
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