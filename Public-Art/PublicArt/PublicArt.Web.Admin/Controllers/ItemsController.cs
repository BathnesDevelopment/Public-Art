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
using PublicArt.Util.Extensions;
using PublicArt.Util.Spatial;

namespace PublicArt.Web.Admin.Controllers
{
    [RoutePrefix("Items")]
    public class ItemsController : Controller
    {
        private PublicArtEntities db = new PublicArtEntities();

        // GET: Items
        [Route]
        public async Task<ActionResult> Index()
        {
            var items = await db.Items.ToListAsync();
            var viewModels = items.Select(x => new ItemIndexViewModel()
            {
                ItemId = x.ItemId,
                ThumbnailGuid = x.ItemImages.OrderBy(i => i.Order).Select(i => i.stream_id).FirstOrDefault(),
                Reference = x.Reference,
                Title = x.Title.ShortenIfTooLong(40),
                Date = x.Date,
                Artists = x.ItemArtists.Select(a => new ItemIndexArtistsViewModel()
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
        [Route("Create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Create")]
        public async Task<ActionResult> Create([Bind(Include = "ItemId,Reference,Title,Description,Date,UnveilingYear,UnveilingDetails,Statement,Material,Inscription,History,Notes,WebsiteURL,Height,Width,Depth,Diameter,SurfaceCondition,StructuralCondition,Address,Location,Archived,rowguid,ModifiedDate")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Items.Add(item);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(item);
        }

        // GET: Items/5
        [Route("{id:int}")]
        public async Task<ActionResult> Edit(int id)
        {
            Item item = await db.Items.FindAsync(id);

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
                WebsiteUrl = item.WebsiteURL,
                Height = item.Height,
                Width = item.Width,
                Depth = item.Depth,
                Diameter = item.Diameter,
                SurfaceCondition = item.SurfaceCondition,
                StructuralCondition = item.StructuralCondition,
                Address = item.Address,
                Latitude = item.Location?.Latitude,
                Longitude = item.Location?.Longitude,
                Archived = item.Archived,
                ModifiedDate = item.ModifiedDate,
                Artists = item.ItemArtists.Select(a => new ItemIndexArtistsViewModel()
                {
                    ArtistId = a.ArtistId,
                    Name = a.Artist.Name,
                    Notes = a.Notes
                }),
                Categories = item.ItemCategories.ToDictionary(c => c.CategoryId, c => c.Category.Description),
                Images = item.ItemImages.ToDictionary(i => i.stream_id, i => i.Caption)
            };

            return View(viewModel);
        }

        // POST: Items/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("{id:int}")]
        public async Task<ActionResult> Edit([Bind(Include = "ItemId,Reference,Title,Description,Date,UnveilingYear,UnveilingDetails,Statement,Material,Inscription,History,Notes,WebsiteURL,Height,Width,Depth,Diameter,SurfaceCondition,StructuralCondition,Address,Latitude,Longitude,Archived,Artists,Categories,Images")] ItemEditViewModel itemViewModel)
        {
            if (ModelState.IsValid)
            {
                var item = await db.Items.FindAsync(itemViewModel.ItemId);

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
                item.WebsiteURL = itemViewModel.WebsiteUrl;
                item.Height = itemViewModel.Height;
                item.Width = itemViewModel.Width;
                item.Depth = itemViewModel.Depth;
                item.Diameter = itemViewModel.Diameter;
                item.SurfaceCondition = itemViewModel.SurfaceCondition;
                item.StructuralCondition = itemViewModel.StructuralCondition;
                item.Address = itemViewModel.Address;
                item.Archived = itemViewModel.Archived;

                item.Location = (itemViewModel.Latitude.HasValue && itemViewModel.Longitude.HasValue)
                    ? Geography.CreateFromLatLng(itemViewModel.Latitude.Value, itemViewModel.Longitude.Value)
                    : null;

                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(itemViewModel);
        }

        // GET: Items/5/Delete
        [Route("{id:int}/Delete")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = await db.Items.FindAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/5/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("{id:int}/Delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Item item = await db.Items.FindAsync(id);
            db.Items.Remove(item);
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
