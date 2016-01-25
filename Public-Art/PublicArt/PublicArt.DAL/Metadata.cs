using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;

namespace PublicArt.DAL
{
    public class ArtistMetadata
    {
    }

    public class CategoryMetadata
    {
    }

    public class ImageMetadata
    {
    }

    public class ItemMetadata
    {
        [StringLength(2000)] [Display(Name = "Address")] public string Address;

        [Display(Name = "Archived")] public bool Archived;

        [Display(Name = "Date")] public short? Date;

        [Display(Name = "Depth (cm)")] [Range(0, 32767)] public short? Depth;

        [StringLength(4000)] [Display(Name = "Description", ShortName = "Desc")] [Required] public string Description;

        [Display(Name = "Diameter (cm)")] [Range(0, 32767)] public short? Diameter;

        [Display(Name = "Height (cm)")] [Range(0, 32767)] public short? Height;

        [StringLength(4000)] [Display(Name = "History")] public string History;

        [StringLength(1000)] [Display(Name = "Inscription")] public string Inscription;

        [Key] public int ItemId;

        [Display(Name = "Location")] public DbGeography Location;

        [StringLength(1000)] [Display(Name = "Material")] public string Material;

        [Display(Name = "Modified Date")] public DateTime ModifiedDate;

        [StringLength(4000)] [Display(Name = "Notes")] public string Notes;

        [StringLength(6)] [Display(Name = "Reference", ShortName = "Ref")] [Required] public string Reference;

        public Guid rowguid;

        [StringLength(4000)] [Display(Name = "Statement")] public string Statement;

        [StringLength(2000)] [Display(Name = "Structural Condition")] public string StructuralCondition;

        [StringLength(2000)] [Display(Name = "Surface Condition")] public string SurfaceCondition;

        [StringLength(600)] [Display(Name = "Title")] [Required] public string Title;

        [StringLength(4000)] [Display(Name = "Unveiling Details")] public string UnveilingDetails;

        [Display(Name = "Unveiling Year")] public short? UnveilingYear;

        [StringLength(2083)] [Display(Name = "Website")] [Url] public string WebsiteURL;

        [Display(Name = "Width (cm)")] [Range(0, 32767)] public short? Width;
    }

    public class ItemArtistMetadata
    {
    }

    public class ItemCategoryMetadata
    {
    }

    public class ItemImageMetadata
    {
    }
}