using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PublicArt.Web.Admin.ViewModels
{
    public class ItemCreateViewModel
    {
        [Display(Name = "Reference")]
        [StringLength(6)]
        [Required]
        public string Reference { get; set; }

        [Display(Name = "Title")]
        [StringLength(600)]
        [Required]
        public string Title { get; set; }

        [Display(Name = "Description")]
        [StringLength(4000)]
        [DataType(DataType.MultilineText)]
        [Required]
        public string Description { get; set; }
    }
}