using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PublicArt.Web.Admin.ViewModels
{
    public class ArtistIndexViewModel
    {
        public int ArtistId { get; set; }

        public string Name { get; set; }

        public string WebsiteUrl { get; set; }

        public string WebsiteUrlShort { get; set; }

        public string Dates { get; set; }

        public string BiographyShort { get; set; }

        public int ItemsCount { get; set; }
    }
}