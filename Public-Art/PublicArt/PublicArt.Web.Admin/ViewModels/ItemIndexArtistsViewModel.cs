using System.ComponentModel.DataAnnotations;

namespace PublicArt.Web.Admin.ViewModels
{
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