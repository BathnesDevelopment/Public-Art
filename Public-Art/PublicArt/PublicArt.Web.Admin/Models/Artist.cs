//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PublicArt.Web.Admin.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Artist
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Artist()
        {
            this.ItemArtists = new HashSet<ItemArtist>();
        }
    
        public int ArtistId { get; set; }
        public string Name { get; set; }
        public string Biography { get; set; }
        public string WebsiteURL { get; set; }
        public Nullable<short> StartYear { get; set; }
        public Nullable<short> EndYear { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public System.Guid rowguid { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemArtist> ItemArtists { get; set; }
    }
}
