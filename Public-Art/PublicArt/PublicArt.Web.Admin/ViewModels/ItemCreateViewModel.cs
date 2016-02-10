using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PublicArt.Util.DataAnnotations;

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

        [Display(Name="Artist")]
        public int? ArtistId { get; set; }

        [Display(Name = "Artist Notes")]
        [StringLength(1000)]
        [RequiredIfPropertyPopulated("ArtistId")]
        public string ArtistNotes { get; set; }

        [Display(Name = "Description")]
        [StringLength(4000)]
        [DataType(DataType.MultilineText)]
        [Required]
        public string Description { get; set; }
        
        public IDictionary<int, string> ArtistsDictionary { get; set; }
    }
}