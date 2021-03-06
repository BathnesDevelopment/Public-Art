﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using PublicArt.Util.DataAnnotations;

namespace PublicArt.Web.Admin.ViewModels
{
    public class ItemEditViewModel
    {
        [Key]
        public int ItemId { get; set; }

        [Display(Name = "Reference")]
        [StringLength(6)]
        public string Reference { get; set; }

        [Display(Name = "Title")]
        [StringLength(600)]
        [Required]
        public string Title { get; set; }

        [Display(Name = "Description")]
        [StringLength(4000)]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        [Required]
        public string Description { get; set; }

        [Display(Name = "Created")]
        [Range(1000, 2200)]
        public short? Date { get; set; }

        [Display(Name = "Unveiled")]
        [Range(1000, 2200)]
        public short? UnveilingYear { get; set; }

        [Display(Name = "Unveiling Details")]
        [StringLength(4000)]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string UnveilingDetails { get; set; }

        [Display(Name = "Statement")]
        [StringLength(4000)]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Statement { get; set; }

        [Display(Name = "Material")]
        [StringLength(1000)]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Material { get; set; }

        [Display(Name = "Inscription")]
        [StringLength(1000)]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Inscription { get; set; }

        [Display(Name = "History")]
        [StringLength(4000)]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string History { get; set; }

        [Display(Name = "Notes")]
        [StringLength(4000)]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Notes { get; set; }

        [Display(Name = "Website")]
        [Url]
        [StringLength(2083)]
        [DataType(DataType.Url)]
        public string WebsiteUrl { get; set; }

        [Display(Name = "Height")]
        [Range(0, 10000)]
        public short? Height { get; set; }

        [Display(Name = "Width")]
        [Range(0, 10000)]
        public short? Width { get; set; }

        [Display(Name = "Depth")]
        [Range(0, 10000)]
        public short? Depth { get; set; }

        [Display(Name = "Diameter")]
        [Range(0, 10000)]
        public short? Diameter { get; set; }

        [Display(Name = "Surface Condition")]
        [StringLength(2000)]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string SurfaceCondition { get; set; }

        [Display(Name = "Structural Condition")]
        [StringLength(2000)]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string StructuralCondition { get; set; }

        [Display(Name = "Address")]
        [StringLength(2000)]
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Address { get; set; }

        [Display(Name = "Latitude")]
        [Range(-90.0, 90.0)]
        [RequiredIfPropertyPopulated("Longitude")]
        public double? Latitude { get; set; }

        [Display(Name = "Longitude")]
        [Range(-180.0, 180.0)]
        [RequiredIfPropertyPopulated("Latitude")]
        public double? Longitude { get; set; }

        [Display(Name = "Published")]
        public bool Published { get; set; }

        [Display(Name = "Modified")]
        [ReadOnly(true)]
        public DateTime ModifiedDate { get; set; }

        [Display(Name = "Artist(s)")]
        public IEnumerable<ItemEditArtistViewModel> Artists { get; set; }

        [Display(Name = "Categories")]
        public IDictionary<int, string> Categories { get; set; }

        [Display(Name = "Images")]
        public IEnumerable<ItemEditItemImageViewModel> Images { get; set; }

        public IDictionary<int, string> ArtistsDictionary { get; set; }
    }
}