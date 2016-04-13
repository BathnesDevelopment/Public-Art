using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PublicArt.Web.Admin.ViewModels
{
    public class ArtistDeleteViewModel
    {
        [Key]
        [ReadOnly(true)]
        public int ArtistId { get; set; }

        [Display(Name = "Name")]
        [ReadOnly(true)]
        public string Name { get; set; }

        [Display(Name = "Biography")]
        [ReadOnly(true)]
        public string Biography { get; set; }
    }
}