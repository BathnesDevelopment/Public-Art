using System;

namespace PublicArt.Web.Admin.ViewModels
{
    public class ItemIndexViewModel
    {
        public int ItemId { get; set; }

        public string Reference { get; set; }

        public string Title { get; set; }

        // Artists viewmodel
        //public TYPE Type { get; set; }

        public Guid ThumbnailGuid { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}