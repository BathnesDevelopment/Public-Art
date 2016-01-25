using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PublicArt.Web.Admin.ViewModels
{
    public class ItemIndexViewModel
    {
        [Key]
        public int ItemId { get; set; }

        [Display(Name = "Reference", ShortName = "Ref.")]
        public string Reference { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Artist(s)")]
        public IEnumerable<ItemIndexArtistsViewModel> Artists { get; set; }

        [Display(Name = "Categories")]
        public IDictionary<int, string> Categories { get; set; }

        [Display(Name = "Image")]
        public Guid ThumbnailGuid { get; set; }

        [Display(Name = "Modified")]
        public DateTime ModifiedDate { get; set; }
    }

    public class ItemIndexArtistsViewModel
    {
        [Key]
        public int ArtistId { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Notes")]
        public string Notes { get; set; }
    }
}