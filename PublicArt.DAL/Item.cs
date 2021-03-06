//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PublicArt.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Item
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Item()
        {
            this.ItemArtists = new HashSet<ItemArtist>();
            this.ItemCategories = new HashSet<ItemCategory>();
            this.ItemImages = new HashSet<ItemImage>();
        }
    
        public int ItemId { get; set; }
        public string Reference { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Nullable<short> Date { get; set; }
        public Nullable<short> UnveilingYear { get; set; }
        public string UnveilingDetails { get; set; }
        public string Statement { get; set; }
        public string Material { get; set; }
        public string Inscription { get; set; }
        public string History { get; set; }
        public string Notes { get; set; }
        public string WebsiteUrl { get; set; }
        public Nullable<short> Height { get; set; }
        public Nullable<short> Width { get; set; }
        public Nullable<short> Depth { get; set; }
        public Nullable<short> Diameter { get; set; }
        public string SurfaceCondition { get; set; }
        public string StructuralCondition { get; set; }
        public string Address { get; set; }
        public System.Data.Entity.Spatial.DbGeography Location { get; set; }
        public bool Published { get; set; }
        public System.Guid rowguid { get; set; }
        public System.DateTime ModifiedDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemArtist> ItemArtists { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemCategory> ItemCategories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemImage> ItemImages { get; set; }
    }
}
