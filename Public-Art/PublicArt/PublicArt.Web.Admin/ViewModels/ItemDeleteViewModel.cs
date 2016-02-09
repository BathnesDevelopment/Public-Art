using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PublicArt.Web.Admin.ViewModels
{
    public class ItemDeleteViewModel
    {
        [ReadOnly(true)]
        [Key]
        public int ItemId { get; set; }

        [ReadOnly(true)]
        [Display(Name = "Ref.")]
        public string Reference { get; set; }

        [ReadOnly(true)]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [ReadOnly(true)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [ReadOnly(true)]
        [Display(Name = "Image")]
        public Guid? PrimaryImage { get; set; }
    }
}