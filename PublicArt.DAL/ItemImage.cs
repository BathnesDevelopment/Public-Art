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
    
    public partial class ItemImage
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ItemImage()
        {
            this.ImageThumbnails = new HashSet<ImageThumbnail>();
        }
    
        public int ItemId { get; set; }
        public System.Guid stream_id { get; set; }
        public byte[] file_stream { get; set; }
        public bool Primary { get; set; }
        public string Caption { get; set; }
        public System.DateTime ModifiedDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ImageThumbnail> ImageThumbnails { get; set; }
        public virtual Item Item { get; set; }
    }
}