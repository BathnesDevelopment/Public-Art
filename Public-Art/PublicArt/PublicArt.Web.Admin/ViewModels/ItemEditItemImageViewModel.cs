using System;
using System.ComponentModel.DataAnnotations;

namespace PublicArt.Web.Admin.ViewModels
{
    public class ItemEditItemImageViewModel
    {
        [Key]
        public Guid stream_id { get; set; }

        [Display(Name = "Primary")]
        public bool Primary { get; set; }

        [Display(Name = "Caption")]
        [StringLength(2000)]
        public string Caption { get; set; }
    }
}