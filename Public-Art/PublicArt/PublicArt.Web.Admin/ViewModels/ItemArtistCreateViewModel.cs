using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PublicArt.Web.Admin.ViewModels
{
    public class ItemArtistCreateViewModel
    {
        public int ItemId { get; set; }

        public int ArtistId { get; set; }

        public string Notes { get; set; }
    }
}