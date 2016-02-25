using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PublicArt.Web.Admin.ViewModels
{
    public class ArtistCreateViewModel
    {
        [Display(Name = "Name")]
        [Required]
        [StringLength(300)]
        public string Name { get; set; }

        [Display(Name = "Biography")]
        [StringLength(4000)]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Biography { get; set; }

        [Display(Name = "Website")]
        [Url]
        [StringLength(2083)]
        [DataType(DataType.Url)]
        public string WebsiteUrl { get; set; }

        [Display(Name = "Start Year")]
        [Range(1000, 2200)]
        public short? StartYear { get; set; }

        [Display(Name = "End Year")]
        [Range(1000, 2200)]
        public short? EndYear { get; set; }
    }
}